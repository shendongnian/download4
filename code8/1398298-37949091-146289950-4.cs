    [Fact]
    public async void Test_My_Method()
    {
       IMyService service = new MyService(...);
       var result = await service.MyMethodToTest("");  
    }
