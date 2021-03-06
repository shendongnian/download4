    public class FileInfoNameLengthEqualityComparer : EqualityComparer<FileInfo>
    {
        public override bool Equals(FileInfo x, FileInfo y)
        {
            if (x == y)
                return true;
    
            if (x == null || y == null)
                return false;
    
            // 2 files are equal if their names and lengths are identical.
            return x.Name == y.Name && x.Length == y.Length;
        }
    
        public override int GetHashCode(FileInfo obj)
        {
            return obj == null
                   ? 0  : obj.Name.GetHashCode() ^ obj.Length.GetHashCode();
        }
    }
 
