    class MyClass {
        public event EventHandler MyEvent;
    
        public void Method() {
            OnEvent();
        }
    
        private void OnEvent() {
            if (MyEvent != null) {
                MyEvent(this, EventArgs.Empty);
            }
        }
        void Event_Hander()
        {
            Consol.WriteLine("Executed!");
        }
    }
