    // http://stackoverflow.com/q/38065626/
    // http://stackoverflow.com/a/28087521/
    // http://stackoverflow.com/a/33697745/
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using Extensions.Config;
    using Extensions.Log.Config;
    using Extensions.Log.Logger;
    using iTextSharp.text.pdf;
    using iTextSharp.text.pdf.parser;
    using log4net;
    using log4net.Config;
    namespace Examplify.PdfUtil
    {
        internal class Program
        {
            public static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            public static void Main(string[] args)
            {
                XmlConfigurator.ConfigureAndWatch(new FileInfo(Log4NetConfig.Settings.Path));
                var dir = Settings.TestDirectory;
                var file = Settings.TestFile;
                Log.Info($"File to Process: {file}");
                using (var reader = new PdfReader(file.FullName))
                {
                    var parser = new PdfReaderContentParser(reader);
                    var listener = new SimpleMixedExtractionStrategy(file, dir);
                    parser.ProcessContent(1, listener);
                    var x = listener.GetResultantText().Split('\n');
                }
            }
        }
        public class SimpleMixedExtractionStrategy : LocationTextExtractionStrategy
        {
            public static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            public DirectoryInfo OutputPath { get; }
            public FileInfo OutputFile { get; }
            private static readonly LineSegment UNIT_LINE = new LineSegment(new Vector(0, 0, 1), new Vector(1, 0, 1));
            private int _counter;
            public SimpleMixedExtractionStrategy(FileInfo outputFile, DirectoryInfo outputPath)
            {
                OutputPath = outputPath;
                OutputFile = outputFile;
            }
            public override void RenderImage(ImageRenderInfo renderInfo)
            {
                try
                {
                    var image = renderInfo.GetImage();
                    if (image == null) return;
                    var number = _counter++;
                    var imageFile = new FileInfo($"{OutputFile.FullName}-{number}.{image.GetFileType()}");
                    imageFile.ByteArrayToFile(image.GetImageAsBytes());
                    var segment = UNIT_LINE.TransformBy(renderInfo.GetImageCTM());
                    var location = new TextChunk("[" + imageFile + "]", segment.GetStartPoint(), segment.GetEndPoint(), 0f);
                    var locationalResultField = typeof(LocationTextExtractionStrategy).GetField("locationalResult", BindingFlags.NonPublic | BindingFlags.Instance);
                    var LocationalResults = (List<TextChunk>)locationalResultField.GetValue(this);
                    LocationalResults.Add(location);
                }
                catch (Exception ex)
                {
                    Log.Debug($"{ex.Message}");
                    Log.Verbose($"{ex.StackTrace}");
                }
            }
            //private FieldInfo _locationalResultField;
            //private List<TextChunk> GetLocationalResult() => (List<TextChunk>) _locationalResultField.GetValue(this);
        }
        public static class ByteArrayExtensions
        {
            public static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            public static bool ByteArrayToFile(this FileInfo fileName, byte[] byteArray)
            {
                try
                {
                    // Open file for reading
                    var fileStream = new FileStream(fileName.FullName, FileMode.Create, FileAccess.Write);
                    // Writes a block of bytes to this stream using data from a byte array.
                    fileStream.Write(byteArray, 0, byteArray.Length);
                    // close file stream
                    fileStream.Close();
                    return true;
                }
                catch (Exception exception)
                {
                    // Error
                    Log.Error($"Exception caught in process: {exception.Message}", exception);
                }
                // error occured, return false
                return false;
            }
        }
    }
