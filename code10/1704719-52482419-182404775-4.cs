    [Test]
    [TestCase("test",TestName="Test1")]
    [TestCase("test2",TestName="Test2")]
    Testing_Method(string param)
    {
       //somestuff
       using (ApprovalTests.NamersApprovalResults.ForScenario(param))
       {
           ObjectApprover.VerifyJson(someObject); 
       }
    }
