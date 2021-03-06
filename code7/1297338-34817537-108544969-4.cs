    using System.IO.Compression;
    using System.Web;
    using System.Web.Mvc;
    using System;
    using System.Linq;
    using System.IO;
    using System.Net.Mime;
    namespace Whatever
    {
        public class ZipFileResult : FileResult
        {
            /// <summary>
            /// Folder inside zip which will contains the files.
            /// (<c>FileDownloadName</c> without its extension will be used
            /// by default if there is more than one file in the zip.
            /// </summary>
            /// <value>
            /// <c>string.Empty</c> for not having a folder inside the zip.
            /// <c>null</c> for using <c>FileDownloadName</c> without its extension 
            /// if there is more than one file in the zip.
            /// </value>
            /// <remarks>If <c>FileDownloadName</c> is <c>null</c> or empty, the 
            /// name "files" will be used instead.</remarks>
            public string ZipFolder { get; set; }
            private readonly ZipFileResultEntry[] _files;
            public ZipFileResult(params ZipFileResultEntry[] files)
                : base(MediaTypeNames.Application.Zip)
            {
                _files = files;
            }
            public ZipFileResult(params string[] filesPaths)
                : this(filesPaths == null ? null : 
                    filesPaths.Select(fp => ZipFileResultEntry
                        .Create(Path.GetFileName(fp), fp)).ToArray())
            {
            }
            public override void ExecuteResult(ControllerContext context)
            {
                FileResultUtils.ExecuteResultWithHeadersRestoredOnFailure(
                    context, base.ExecuteResult);
            }
            protected override void WriteFile(HttpResponseBase response)
            {
                // By default, response is fully buffered in memory and sent
                // once completed. On big zipped content, this would cause troubles.
                // If un-buffering response is required (<c>response.BufferOutput = 
                // false;</c>), beware, it may emit very small packets,
                // causing download time to dramatically raise. To avoid this,
                // it would then required to use a BufferedStream with a
                // reasonnable buffer size (256kb for instance).
                // http://stackoverflow.com/q/26010915/1178314
                // The BufferedStream should encapsulate response.OutputStream. 
                // PositionWrapperStream must then Dispose it (current
                // implementation will not), so long for this causing OutputStream
                // to get closed (BufferedStream do not have any option for
                // telling it not to close its underlying stream, and it is 
                // sealed...).
                using (var outputStream = 
                    new PositionWrapperStream(response.OutputStream))
                using (var zip = new ZipArchive(outputStream, 
                    ZipArchiveMode.Create, true))
                {
                    if (_files != null)
                    {
                        var archiveDir = ZipFolder ??
                            (_files.Length <= 1 ? string.Empty :
                                string.IsNullOrEmpty(FileDownloadName) ? 
                                    "files" : 
                                    Path.ChangeExtension(FileDownloadName, null));
                        foreach (var file in _files)
                        {
                            if (file == null)
                                continue;
                            file.WriteEntry(zip, archiveDir);
                        }
                    }
                }
            }
            // Workaround bug ZipArchive requiring Position while creating.
            // Taken from http://stackoverflow.com/a/21513194/1178314
            class PositionWrapperStream : Stream
            {
                private Stream _wrapped;
                private int _pos = 0;
                public PositionWrapperStream(Stream wrapped)
                {
                    _wrapped = wrapped;
                }
                public override bool CanSeek { get { return false; } }
                public override bool CanWrite { get { return true; } }
                public override bool CanRead { get { return false; } }
                public override long Position
                {
                    get { return _pos; }
                    set { throw new NotSupportedException(); }
                }
                public override long Length { get { return _pos; } }
                public override void Write(byte[] buffer, int offset, int count)
                {
                    _pos += count;
                    _wrapped.Write(buffer, offset, count);
                }
                public override void Flush()
                {
                    _wrapped.Flush();
                }
                protected override void Dispose(bool disposing)
                {
                    // Fcd : not closing _wrapped ourselves, MVC handle that.
                    _wrapped = null;
                    base.Dispose(disposing);
                }
                // all the other required methods can throw NotSupportedException
                public override int Read(byte[] buffer, int offset, int count)
                {
                    throw new NotSupportedException();
                }
                public override void SetLength(long value)
                {
                    throw new NotSupportedException();
                }
                public override long Seek(long offset, SeekOrigin origin)
                {
                    throw new NotSupportedException();
                }
            }
        }
        public abstract class ZipFileResultEntry
        {
            /// <summary>
            /// Filename to use inside the zip.
            /// </summary>
            public string Filename { get; private set; }
            internal ZipFileResultEntry(string filename)
            {
                Filename = filename;
            }
            internal abstract void WriteEntry(ZipArchive zip, string directory);
            /// <summary>
            /// Create a file to zip in response from an uncompressed file.
            /// </summary>
            /// <param name="filename">Filename to use inside the zip.</param>
            /// <param name="path">Full path to uncompressed file on 
            /// server.</param>
            public static ZipFileResultEntry Create(string filename, string path)
            {
                return new FileSystemEntry(filename, path);
            }
            /// <summary>
            /// Create a text file to zip in response using a callback.
            /// </summary>
            /// <param name="filename">Filename to use inside the zip.</param>
            /// <param name="writer">Callback responsible of writing
            /// uncompressed file content in zip stream.</param>
            public static ZipFileResultEntry CreateText(string filename, 
                Action<StreamWriter> writer)
            {
                return new TextCallbackEntry(filename, writer);
            }
            private class FileSystemEntry : ZipFileResultEntry
            {
                private readonly string SystemPath;
                public FileSystemEntry(string filename, string path)
                    : base(filename)
                {
                    SystemPath = path;
                }
                internal override void WriteEntry(ZipArchive zip, string directory)
                {
                    zip.CreateEntryFromFile(SystemPath, 
                        Path.Combine(directory, Filename));
                }
            }
            private class TextCallbackEntry : ZipFileResultEntry
            {
                private readonly Action<StreamWriter> Writer;
                public TextCallbackEntry(string filename, 
                    Action<StreamWriter> writer)
                    : base(filename)
                {
                    if (writer == null)
                        throw new ArgumentNullException("writer");
                    Writer = writer;
                }
                internal override void WriteEntry(ZipArchive zip, string directory)
                {
                    var entry = zip.CreateEntry(Path.Combine(directory, Filename));
                    using (var sw = new StreamWriter(entry.Open()))
                    {
                        Writer(sw);
                    }
                }
            }
        }
    }
