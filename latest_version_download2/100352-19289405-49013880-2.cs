    StreamReader sr = new StreamReader(@"C:\CSV\test.csv")
    StreamWriter sw = new StreamWriter(@"C:\CSV\testOut.csv")
    while (sr.Peek() >= 0) 
    {
        string line = sr.ReadLine(); 
    
    
    try
    {
           string[] rowsArray = line.Split(';');
           string row = rowsArray[0];
           string resultIBAN = client.BBANtoIBAN(row);
           if (resultIBAN != string.Empty)
           {
               line +=";"+ resultIBAN;
           }
           else
           {
                line +=";"+"Accountnumber is not correct.";
           }
          
     }
     catch (Exception msg)
     {
         Console.WriteLine(msg);
     }
     sw.WriteLine(line) 
     }
    sr.Close();
    sw.Close();
