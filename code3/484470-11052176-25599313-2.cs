    List<string> list = new List<string>() { 
        "Liverpool - 1", 
        "Liverpool - 2", 
        "Liverpool - 10", 
        "Liverpool - 11", 
        "Liverpool - 3", 
        "Liverpool - 20" };
    var sortedList = list.CustomSort().ToArray();    
    public static class MyExtensions
    {
        public static IEnumerable<string> CustomSort(this IEnumerable<string> list)
        {
            int maxLen = list.Select(s => s.Length).Max();
            return list.Select(s => new
            {
                OrgStr = s,
                SortStr = Regex.Replace(s, @"(\d+)|(\D+)", m => m.Value.PadLeft(maxLen, char.IsDigit(m.Value[0]) ? ' ' : '\xffff'))
            })
                    .OrderBy(x => x.SortStr)
                    .Select(x => x.OrgStr);
        }
    }
