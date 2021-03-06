    [Function(Name = "import.usp_MyData_ProcessImportAppend", IsComposable = false)]
    public Int32 ProcessGradingImport(string loadId)
    {
        ProcessLoadId(loadId, (MethodInfo)(MethodBase.GetCurrentMethod(), new object[] { loadId });
    }
    
    [Function(Name = "import.usp_MyData_ProcessImportUpdate", IsComposable = false)]
    public Int32 ProcessGradingImportUpdate(string loadId)
    {
        ProcessLoadId(loadId, (MethodInfo)(MethodBase.GetCurrentMethod(), new object[] { loadId });
    }
    
    [Function(Name = "import.usp_MyData_ProcessImportOverwrite", IsComposable = false)]
    public Int32 ProcessGradingImportOverwrite(string loadId)
    {
        ProcessLoadId(loadId, (MethodInfo)(MethodBase.GetCurrentMethod(), new object[] { loadId });
    }
    
    public Int32 ProcessLoadId(string loadId, MethodInfo method, object[] parameters)
    {
        // Validate parameter
        if (String.IsNullOrEmpty(loadId)) throw new ArgumentNullException("loadId");
    
        // Initialise the result and the procedure parametes
        Int32 result = 0;
    
        // Call the procedure, and return the result
        IExecuteResult executionResult = ExecuteMethodCall(this, methodInfo, parameters);
        if (executionResult != null) result = (int)executionResult.ReturnValue;
        return result;
    }
