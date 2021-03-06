    string line = String.Empty;
    
    List<String> statementBlocks = new List<String>();
    
    System.IO.StreamReader file = new System.IO.StreamReader("C:\\temp\\annoying_text_file.sql");
    
    StringBuilder blockCollector = new StringBuilder();
    
    //read the file a line at a time
    while((line = file.ReadLine()) != null)
    {
      //If the line has content, then we append it to our string builder 
      if(!String.IsNullOrWhitespace(line) || line != Environment.NewLine)
      {
          blockCollector.AppendLine(line);
      }
      else
      {
           //we've hit a blank line - dump it to the list and reinitialize the stringbuilder
           statementBlocks.Add(blockCollector.ToString();
           statementBlocks = new StringBuilder();
      }
      
    }
    
    //Tidy up
    file.Close();
    
    
    foreach(string statementBlock in statementBlocks)
    {
      if(!String.IsNullOrEmpty(statementBlock))
      {
          if(statememtBlock.StartsWith("-->"))
          {
            //Code to split out the arguments; if they are delimited with : then you can just string.split this line
            //string[] paramsAndValues = line.Replace("-->", String.Empty).Split(Char.Parse(":"))
            // then for each string in here it's paramName(DataType)=Value, which is also splittable.
          }
          else
          {
          //Do whatever you want with this valid block (including writing it to another file!)
          }
      }    
    }
