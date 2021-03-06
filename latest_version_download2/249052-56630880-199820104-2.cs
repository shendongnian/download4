    class Program
    {
        public sealed class NaturalStringComparer : IComparer<string>
        {
            [DllImport("shlwapi.dll", CharSet = CharSet.Unicode)]
            public static extern int StrCmpLogicalW(string psz1, string psz2);
            public int Compare(string a, string b) => StrCmpLogicalW(a, b);
        }
    
        static void Main()
        {
            var stringList = new List<string>();
    
            var index = 0;
            while (index < 12)
            {
                stringList.Add($"{index,-15} {"Model",-35} {"35GB",-20}");
                index++;
            }
    
            stringList.Sort(new NaturalStringComparer());
    
            foreach (var s in stringList)
            {
                Console.WriteLine(s);
            }
        }
    }
