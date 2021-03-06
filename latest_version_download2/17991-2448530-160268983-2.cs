    // The delegate type. This one is already defined in the library, in the System namespace
    // the `void (object, EventArgs)` signature is also the recommended pattern
    public delegate void Eventhandler(object sender, Eventargs args);  
    // your publishing class
    class Foo  
    {
        public event EventHandler Changed;    // the Event
    
        protected virtual void OnChanged()    // the Trigger method, called to raise the event
        {
            // make a copy to be more thread-safe
            EventHandler handler = Changed;   
            if (handler != null)
            {
                // invoke the subscribed event-handler(s)
                handler(this, EventArgs.Empty);  
            }
        }
        // an example of raising the event
        void SomeMethod()
        {
           if (...)        // on some condition
             OnChanged();  // raise the event
        }
    }
