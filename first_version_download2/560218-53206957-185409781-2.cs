    var status = TestContext.CurrentContext.Result.Status;
    
    switch (TestContext.CurrentContext.Result.Status)
    {
        case TestStatus.Inconclusive:
            break;
        case TestStatus.Skipped:
            break;
        case TestStatus.Passed:
            break;
        case TestStatus.Failed:
            break;
    }
