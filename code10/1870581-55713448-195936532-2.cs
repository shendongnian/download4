    public void Main()
    {
        try{
    
            Excel.Application xlApp;
            xlApp = new Excel.ApplicationClass();
    
            //...rest of code here
    
            Dts.TaskResult = (int)ScriptResult.Success;
    
        }catch(Exception ex){
    
            Dts.FireError(0,"An error occured", ex.Message,String.Empty, 0);
            Dts.TaskResult = (int)ScriptResult.Failure;
    
        }
    
    
    }
