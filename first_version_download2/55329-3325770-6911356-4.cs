    List<Test> FirstTests = ...
    List<Test> SecondTests = ...
    List<Test> Result = FirstTests.FindAll(delegate(Test item)
    {
        return SecondTests.Contains(item);
    });
