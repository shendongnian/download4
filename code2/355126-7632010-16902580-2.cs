    public class SortItem<T> : IComparable<T> where T : IComparable
    {
        private static int _ComparisonCount = 0;
        public static int ComparisonCount
        {
            private set
            {
                _ComparisonCount = value;
            }
            get
            {
                return _ComparisonCount;
            }
        }
    
        public void ResetComparisonCount()
        {
            _ComparisonCount = 0;
        }
    
        #region IComparable<T> Members
    
        public int CompareTo(T other)
        {
            ComparisonCount++;
            return this.CompareTo(other);
        }
    
        #endregion
    }
