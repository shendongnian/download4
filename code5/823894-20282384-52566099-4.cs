    public int lData
    {
        get { return BitConverter.ToInt32(uData, 0); }
        set { uData = BitConverter.GetBytes(value); }
    }
    public int iData
    {
        get { return BitConverter.ToInt32(uData, 0); }
        set { uData = BitConverter.GetBytes(value); }
    }
    // etc.
