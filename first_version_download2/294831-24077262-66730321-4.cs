    using System;
    using System.Collections.Generic;
    using System.Linq;
    using s = System.String;
    using sc = System.StringComparison;
    
    namespace Test
    {
        class Test
        {
            private sc cic = sc.InvariantCultureIgnoreCase;
    
            public class c
            {
                public s i;
            }
    
            private void Test(s i)
            {
                List<c> l = new List<c>();
    
                l.FirstOrDefault(
                    c => s.Equals(
                             c.i, 
                             i,
                             cic));
            }
        }
    }
:-)
