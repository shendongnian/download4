    Try creating scriptfile as a separate command:
    Command myCommand = new Command(scriptfile);
    then you can add parameters with
    CommandParameter testParam = new CommandParameter("key","value");
    myCommand.Parameters.Add(testParam);
    and finally
    pipeline.Commands.Add(myCommand);
    
    Here is the complete, edited code:
    RunspaceConfiguration runspaceConfiguration = RunspaceConfiguration.Create();
    
    Runspace runspace = RunspaceFactory.CreateRunspace(runspaceConfiguration);
    runspace.Open();
    
    RunspaceInvoke scriptInvoker = new RunspaceInvoke(runspace);
    
    Pipeline pipeline = runspace.CreatePipeline();
    
    //Here's how you add a new script with arguments
    Command myCommand = new Command(scriptfile);
    CommandParameter testParam = new CommandParameter("key","value");
    myCommand.Parameters.Add(testParam);
    
    pipeline.Commands.Add(myCommand);
    
    // Execute PowerShell script
    results = pipeline.Invoke();
