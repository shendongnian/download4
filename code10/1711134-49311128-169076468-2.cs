    public static class Program
    {
        static void Main(string[] args)
        {
            var foo = new[] {
                new MyClass { a = "1", b = "2"},
                new MyClass { a = "1", b = "3"},
                new MyClass { a = "2", b = "4"},
                new MyClass { a = "2", b = "5"} };
            var ans = foo.GroupBy(x => x.a);
            IEnumerable<IEnumerable<MyClass>> ans2 = ans;
            IEnumerable<IEnumerable<MyClass>> result = ans2.ToArray();
        }
        private class MyClass
        {
            public string a;
            public string b;
        }
    }
