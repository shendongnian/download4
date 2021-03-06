    public static List<List<T>> SplitOn<T>(List<T> main, Func<T, bool> splitOn)
    {
        int groupIndex = 0;
    
        return main.Select( item => new 
                                 { 
                                   Group = (splitOn.Invoke(item) ? ++groupIndex : groupIndex), 
                                   Value = item 
                                 })
                    .GroupBy( it2 => it2.Group)
                    .Select(x => x.Select(v => v.Value).ToList())
                    .ToList();
    }
