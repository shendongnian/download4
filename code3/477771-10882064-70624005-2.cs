    class A
    {
        private List<int> myList;
        public void SomeMethodA()
		{
           lock (myList)
           {
               //...
           }
        }
		
        public void SomeMethodB()
        {
            myList.Add(1);
        }
				
        public void SomeMethodC()
        {
            lock (myList)
		    {
                myList.Add(2);
            }
        }
    }
