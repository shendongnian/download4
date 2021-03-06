    using (PowerShell psRunspace = PowerShell.Create())
            {
                psRunspace.AddCommand("Get-Process");
                psRunspace.AddParameter("ComputerName", computerName);
                    
                Collection<PSObject> outputObj = psRunspace.Invoke();
                foreach (PSObject obj in outputObj)
                {
                    var objProperties = obj.Properties;
                    var objMethods = obj.Methods;
                    var baseObj = obj.BaseObject;
                    if (baseObj is System.Diagnostic.Process) 
                    {
                        var p = (System.Diagnostic.Process)baseObj;
                        //you can now access all members of this object normally
                        //Do something here with p.Properties or p.Methods etc...
                    }
                }
