    public class MyClass
    {
        private readonly IEnumerator<Frame> _enumerator;
		
        public MyClass(SortedSet<Frame> frames)
        {
            _enumerator = frames.GetEnumerator();
        }
        
        public Frame GetNextFrame()
        {
            // If there is no next item, loop back to the beginning 
            // you probably won't want this, but a call to MoveNext() is required
            // it's up to you what to do if there is no next item.
            if(!_enumerator.MoveNext())
                _enumerator.Reset();
            
            return _enumerator.Current;
        }
    }
