    interface IMan
    {
    int Val {get;}
    }
    
    And then have your different types implement this:
    class Man1 : IMan
    {
    public int Val {get;} = 1;
    public string SomethingElse {get;set;}
    }
    
    class Man2 : IMan
    {
    public int Val {get;} = 2;
    public boolean AmICool {get;set;}
    }
