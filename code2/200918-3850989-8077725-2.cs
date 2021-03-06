    class MultiDict<TKey, TValue>  // no (collection) base class
    {
       private Dictionary<TKey, List<TValue>> _data;
    
       public void Add(TKey k, TValue v)
       {
          // can be a optimized a little with TryGetValue, this is for clarity
          if (_data.ContainsKey(k))
             _data[k].Add(v)
          else
            _data.Add(k, new List<TValue>() { v}) ;
       }
       // more members
    }
