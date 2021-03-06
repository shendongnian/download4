    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Context context = new Context();
                List<int> listAffId = new List<int>() { 547 };
                var query = (from a in context.A where listAffId.Contains(a.A_ID)
                             join b in context.B on a.B_ID equals b.B_ID
                             select new { a = a, b = b})
                             .GroupBy(x => x.a.A_ID)
                             .Select(x => new { x = x, max = x.Max(y => y.a.VALUE_DATE)})
                             .Select(x => new {
                                 affId = x.x.Key,
                                 status = x.x.Where(y => y.a.VALUE_DATE == x.max).Select(y => y.b.STATUS).FirstOrDefault()
                             }).ToList();
            }
        }
        public class Context
        {
            public List<TableA> A { get; set; }
            public List<TableB> B { get; set; }
        }
        public class TableA
        {
            public int A_ID { get; set; }
            public int B_ID { get; set; }
            public DateTime VALUE_DATE { get; set; }
        }
        public class TableB
        {
            public int B_ID { get; set; }
            public string STATUS { get; set; }
        }
    }
