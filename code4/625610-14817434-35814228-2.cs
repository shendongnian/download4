    using (new WaitCursor())
    {
        // very long task
        Search.ExecuteSearch(enumSrchType.NextPage);
    }
    public class WaitCursor : IDisposable
    {
        private Cursor _previousCursor;
        public WaitCursor()
        {
            _previousCursor = Mouse.OverrideCursor;
            Mouse.OverrideCursor = Cursors.Wait;
        }
        #region IDisposable Members
        public void Dispose()
        {
            Mouse.OverrideCursor = _previousCursor;
        }
        #endregion
    }
