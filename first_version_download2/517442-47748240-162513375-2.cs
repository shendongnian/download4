    class MainClass
    {
        static void Main()
        {
            dynamic a;
            bool flag = true;
    
    
            if (flag)
                a = new Test1();
            else
                a = new Test2();
    
    
            if (a is Test1)
            {
                a = (Test1)a;
                a.True_1();        //So, there will be no error anymore
            }
    
            else
            {
                a = (Test2)a;
                a.True_2();
            }
        }
    }
