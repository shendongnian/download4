    if (File.Exists(binaryFilePath))
    {
        
        
        while (true)
        {
            Program.DisplayMessage("The file: " + binaryFileName + " exist. You  want to overwrite it? Y/N");
            string overwrite = Console.ReadLine();
            if (overwrite.ToUpper() == "Y")
            {
                WriteBinaryFile(frameCodes, binaryFilePath);
                break;
            } 
            else if (overwrite.ToUpper() == "N")
            {
                throw new IOException();
                overwrite = null;
                break;
            } 
            else if (overwrite.ToUpper() != "Y" && overwrite.ToUpper() != "N")
            {
                Program.DisplayMessage("!!Please Select a Valid Option!!");
                overwrite = Console.ReadLine();
            }
        }
    }
