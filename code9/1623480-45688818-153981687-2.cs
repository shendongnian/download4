    private int myNum;
    public int MyNumber
    {
        get { return myNum; }
        set { DoSomething(); }
    }
    public void DoSomething()
    {
        Randon rnd = new Random();
        myNum = rnd.Next(1,13);
    }
