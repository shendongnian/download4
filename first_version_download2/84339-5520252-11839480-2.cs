    After some great help from steinar this is what worked for me:
            public void ExecuteCommand(string command)
        {
            int ExitCode;
            ProcessStartInfo ProcessInfo;
            Process process;
            ProcessInfo = new ProcessStartInfo(Application.StartupPath + "\\txtmanipulator\\txtmanipulator.bat", command);
            ProcessInfo.CreateNoWindow = true;
            ProcessInfo.UseShellExecute = false;
            ProcessInfo.WorkingDirectory = Application.StartupPath + "\\txtmanipulator";
            // *** Redirect the output ***
            ProcessInfo.RedirectStandardError = true;
            ProcessInfo.RedirectStandardOutput = true;
            process = Process.Start(ProcessInfo);
            process.WaitForExit();
            
            // *** Read the streams ***
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            ExitCode = process.ExitCode;
            MessageBox.Show("output>>" + (String.IsNullOrEmpty(output) ? "(none)" : output));
            MessageBox.Show("error>>" + (String.IsNullOrEmpty(error) ? "(none)" : error));
            MessageBox.Show("ExitCode: " + ExitCode.ToString(), "ExecuteCommand");
            process.Close();
        }
