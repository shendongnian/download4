    public delegate void StringDelegate(string message);
    private void ShowMessageBox( string message )
    {
        if (this.InvokeRequired)
        {
            this.Invoke( new StringDelegate( ShowMessageBox, message ));
            return;
        }
        MessageBox.Show( message );
    }
