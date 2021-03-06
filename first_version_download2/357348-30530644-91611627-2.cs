    public class MyClass
    {
        [System.ComponentModel.DisplayName("my test method")]
        public bool TestMethod(string input)
        {
            return input == "OK";
        }
    
        [System.ComponentModel.DisplayName("my second method")]
        public string TestMethod2(string input)
        {
            return input;
        }
    
        public void Invoke(string displayName)
        {
            // find method
            var methodInfo = (from e in this.GetType().GetMethods()
                              let attributes = e.GetCustomAttributes(typeof(System.ComponentModel.DisplayNameAttribute)).Cast<System.ComponentModel.DisplayNameAttribute>().ToArray()
                              where attributes.Length != 0 && attributes.Any(x => string.Equals(x.DisplayName, displayName, StringComparison.InvariantCultureIgnoreCase))
                              select e).FirstOrDefault();
            if (methodInfo != null)
            {
                Console.WriteLine("Invoke {0} method: {1}", methodInfo.Name, methodInfo.Invoke(this, new object[] { "OK" }));
            }
        }
    }
