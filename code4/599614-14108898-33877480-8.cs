    var testResult = response as Dictionary<string, object>;
                
    if(testResult == null) throw new Exception("Unhandle error occur while running QUnit."); 
    Console.WriteLine("Test complete in " + (long)testResult["runtime"] + " ms.");
    Console.WriteLine("---------------------------");
    Console.WriteLine("total: " + (long)testResult["total"]);
    Console.WriteLine("passed: " + (long)testResult["passed"]);
    Console.WriteLine("failed: " + (long)testResult["failed"]);
