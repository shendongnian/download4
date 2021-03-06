    string folderPath = Dts.Variables["User::errorDirectory"].Value.ToString();
            var FileNames = new List<string>();
            var FilePaths = new List<string>();
            DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
            FileInfo[] files = directoryInfo.GetFiles();
            var lineCount = 0;
            foreach (FileInfo fileInfo in files)
            {
                using (var reader = fileInfo.OpenText()) //this line caused error
                {
                    while (reader.Read() != null)
                    {
                        lineCount++;
                    }
                }
            }
            if (lineCount > 1)
            {
                Dts.TaskResult = (int)ScriptResults.Success;
            }
            else
            {
                Dts.TaskResult = (int)ScriptResults.Failure;
            }
