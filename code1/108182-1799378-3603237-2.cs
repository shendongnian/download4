    class C
    {
        private int m_bar;
        public int Bar { get { return m_bar; } set { m_bar = value; }}
        void foo(out int x)
        {
            x = 2;
            Console.WriteLine(Bar);
        }
        void DoStuff()
        {
            foo(out m_bar); //outputs 2
            Bar = 0;
            //pretend this works
            foo(out Bar); //outputs 0
            Console.WriteLine(Bar); // outputs 2
        }
    }
