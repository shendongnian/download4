    class NullableExample
    {
        static void Main()
        {
            int? num = null;
            if (num.HasValue == true)
            {
                System.Console.WriteLine("num = " + num.Value);
            }
            else
            {
                System.Console.WriteLine("num = Null");
            }
    
            //y is set to zero
            int y = num.GetValueOrDefault();
    
            // num.Value throws an InvalidOperationException if num.HasValue is false
            try
            {
                y = num.Value;
            }
            catch (System.InvalidOperationException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
    }
