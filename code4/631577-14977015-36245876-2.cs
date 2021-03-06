    public class FooComparer : IComparer<Foo>
    {
        public int Compare(Foo x, Foo y)
        {
            // if the names are different, compare by name
            if (!string.Equals(x.Name, y.Name))
            {
                return string.Compare(x.Name, y.Name);
            }
    
            // if the dates are different, compare by date
            if (!DateTime.Equals(x.Date, y.Date))
            {
                return DateTime.Compare(x.Date, y.Date);
            }
    
            // finally compare by the counter
            return x.Counter.CompareTo(y.Counter);
        }
    }
