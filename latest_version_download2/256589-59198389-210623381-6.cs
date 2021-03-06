    public enum GDriveFileType
    {
        User,
        Group,
        Domain,
        Anyone
    }
----------
    public class Program
    {
        private static IGDriveApiV3Wrapper _gDriveApiV3Wrapper;
        private readonly string _gDriveUploadDestinationFolderId;
        public Program(IGDriveApiV3Wrapper gDriveApiV3Wrapper, string gDriveUploadDestinationFolderId = null)
        {
            _gDriveApiV3Wrapper = gDriveApiV3Wrapper;
            _gDriveUploadDestinationFolderId = gDriveUploadDestinationFolderId;
        }
        public string Upload(string filePath)
        {
                string fileId = _gDriveApiV3Wrapper.UploadFile(filePath, _gDriveUploadDestinationFolderId);
                _gDriveApiV3Wrapper.SetFilePermissions(fileId, GDriveFileRole.Reader, GDriveFileType.Anyone);
                GDriveFile gDriveFile = _gDriveApiV3Wrapper.GetFileInfo(fileId);
                return gDriveFile.WebViewLink;
        }
    }
