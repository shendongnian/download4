    try
    {
        SendData("!GetLocation!");
        string data = GetData();
    }
    catch (System.IO.IOException ex)
    {
        if (ex.Message.IndexOf("Unable to read"))
        {
         // GetData error
        }
        else if (ex.Message.IndexOf("Unable to write"))
        {
         // SendData error
        }
        else
        {
           //Other IO errors
        }
    
    }
    catch(Exception exc)
    {
        // Unspected errors
    }
