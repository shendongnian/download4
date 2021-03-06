    process.Start();
    int timeout = ... // some normal value in milliseconds
    process.WaitForExit(timeout);
    try
    {
       //ExitCode throws if the process is hanging
       return (CommandErrorCode)cygwingProcess.ExitCode;
    }
    catch (InvalidOperationException ioex)
    {
       return CommandErrorCode.InternalError;
    }
