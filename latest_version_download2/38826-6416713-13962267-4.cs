    public class LoginPanel : Panel
    {
        // A property returning a valid connection when
        // connected, null otherwise.
        public SqlConnection connection { get; set;}
        ...
        // An event that clients can use to be notified whenever 
        // a connection is made.
        public event EventHandler Connected;
        // Invoke the Connected event; called whenever a successful 
        // connection is made
        protected virtual void OnConnected(EventArgs e) 
        {
           if (Connected!= null)
              Connected(this, e);
        }
    }
