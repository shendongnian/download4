    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("My Button Text: " + Class1.MyCountSAOValue().ToString());
        }
    }
    public static class Class1
    {
        //public static int countSAO;
        // simulate reading lines from file
        public static List<String> SAO_Num = new List<String>() {
            "test1",
            "test2",
            "test3",
            "test4",
            "test5",
            "test6",
            "test7",
            "test8",
            "test9",
            "test10"
        };
        public static int MyCountSAOValue()
        {
            //countSAO = SAO_Num.Count;
            //return countSAO;
            return SAO_Num?.Count ?? 0;
        }
    }
