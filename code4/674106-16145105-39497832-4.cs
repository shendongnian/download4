    /// <summary>
    /// Static class to make creation easier. If possible though, use the extension
    /// method in SmartEnumerableExt.
    /// </summary>
    public static class SmartEnumerable
    {
        /// <summary> method to make life easier.</summary>
        /// <typeparam name="T">Type of enumerable</typeparam>
        /// <param name="source">Source enumerable</param>
        /// <returns>A new SmartEnumerable of the appropriate type</returns>
        
        public static SmartEnumerable<T> Create<T>(IEnumerable<T> source)
        {
            return new SmartEnumerable<T>(source);
        }
    }
    /// <summary>Wrapper methods for SmartEnumerable[T].</summary>
    
    public static class SmartEnumerableExt
    {
        /// <summary>Extension method to make life easier.</summary>
        /// <typeparam name="T">Type of enumerable</typeparam>
        /// <param name="source">Source enumerable</param>
        /// <returns>A new SmartEnumerable of the appropriate type</returns>
        public static SmartEnumerable<T> AsSmartEnumerable<T>(this IEnumerable<T> source)
        {
            return new SmartEnumerable<T>(source);
        }
    }
    /// <summary>
    /// Type chaining an IEnumerable&lt;T&gt; to allow the iterating code
    /// to detect the first and last entries simply.
    /// </summary>
    /// <typeparam name="T">Type to iterate over</typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification="This is too general to end in 'Collection'")]
    
    public class SmartEnumerable<T>: IEnumerable<SmartEnumerable<T>.Entry>
    {
        /// <summary>Enumerable to which we proxy</summary>
        readonly IEnumerable<T> _enumerable;
        /// <summary>Constructor.</summary>
        /// <param name="enumerable">Collection to enumerate. Must not be null.</param>
        
        public SmartEnumerable(IEnumerable<T> enumerable)
        {
            if (enumerable==null)
            {
                throw new ArgumentNullException("enumerable");
            }
            this._enumerable = enumerable;
        }
        /// <summary>
        /// Returns an enumeration of Entry objects, each of which knows
        /// whether it is the first/last of the enumeration, as well as the
        /// current value.
        /// </summary>
        public IEnumerator<Entry> GetEnumerator()
        {
            using (IEnumerator<T> enumerator = _enumerable.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                {
                    yield break;
                }
                bool isFirst = true;
                bool isLast  = false;
                int  index   = 0;
                while (!isLast)
                {
                    T current = enumerator.Current;
                    isLast = !enumerator.MoveNext();
                    yield return new Entry(isFirst, isLast, current, index++);
                    isFirst = false;
                }
            }
        }
        /// <summary>Non-generic form of GetEnumerator.</summary>
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        /// <summary>
        /// Represents each entry returned within a collection,
        /// containing the value and whether it is the first and/or
        /// the last entry in the collection's. enumeration
        /// </summary>
        public class Entry
        {
            internal Entry(bool isFirst, bool isLast, T value, int index)
            {
                this._isFirst = isFirst;
                this._isLast  = isLast;
                this._value   = value;
                this._index   = index;
            }
            /// <summary>The value of the entry.</summary>
            
            public T Value
            {
                get
                {
                    return _value;
                }
            }
            /// <summary>Whether or not this entry is first in the collection's enumeration.</summary>
            
            public bool IsFirst
            {
                get
                {
                    return _isFirst;
                }
            }
            /// <summary>Whether or not this entry is last in the collection's enumeration.</summary>
            
            public bool IsLast
            {
                get
                {
                    return _isLast;
                }
            }
            /// <summary>The 0-based index of this entry (i.e. how many entries have been returned before this one)</summary>
            
            public int Index
            {
                get
                {
                    return _index;
                }
            }
            readonly bool _isFirst;
            readonly bool _isLast;
            readonly T    _value;
            readonly int  _index;
        }
    }
