    //define aspect to log method call
    public class MyLoggingAspect : Aspect
    {
        //define method name console log with additional whatever information if defined.
        override protected IEnumerable<Advice<T>> Advise<T>(MethodInfo method)
        {
            //get year attribute
            var year = method.GetCustomAttributes(typeof(YearAttribute)).Cast<YearAttribute>().FirstOrDefault();
            
            if (year == null)
            {
                yield return Advice<T>.Basic.After(() => Console.WriteLine(methode.Name));
            }
            else //Year attribute is defined, we can add whatever information to log.
            {
                var whatever = year.whatever;
                yield return Advice<T>.Basic.After(() => Console.WriteLine("{0}/whatever={1}", method.Name, whatever));
            }
        }
    }
    public class A
    {
        [Year(whatever = 2.0)]
        public void SampleMethod()
        {
        }
    }
    var logging = new MyLoggingAspect();
    //Attach logging to A class.
    logging.Manage<A>();
    //Call sample method
    new A().SampleMethod();
    //console : SampleMethod/whatever=2.0
