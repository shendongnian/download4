                    Process process = new System.Diagnostics.Process();
                ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.RedirectStandardInput = false;
                startInfo.CreateNoWindow = true;
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = false;
                startInfo.UseShellExecute = false;
                startInfo.FileName = "adb.exe";
                startInfo.Arguments = "shell getprop ro.build.version.release";
                process = Process.Start(startInfo);
                device.Invoke((MethodInvoker)(() => device.Text = process.StandardOutput.ReadToEnd()));
                Process p = new System.Diagnostics.Process();
                ProcessStartInfo si = new System.Diagnostics.ProcessStartInfo();
                si.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                si.RedirectStandardInput = false;
                si.CreateNoWindow = true;
                si.RedirectStandardOutput = true;
                si.RedirectStandardError = false;
                si.UseShellExecute = false;
                si.FileName = "adb.exe";
                si.Arguments = "shell getprop ro.product.model";
                p = Process.Start(si);
                AV.Invoke((MethodInvoker)(() => AV.Text = p.StandardOutput.ReadToEnd()));
                Process pr = new System.Diagnostics.Process();
                ProcessStartInfo siy = new System.Diagnostics.ProcessStartInfo();
                siy.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                siy.RedirectStandardInput = false;
                siy.CreateNoWindow = true;
                siy.RedirectStandardOutput = true;
                siy.RedirectStandardError = false;
                siy.UseShellExecute = false;
                siy.FileName = "adb.exe";
                siy.Arguments = "shell getprop ro.product.name";
                pr = Process.Start(siy);
                name.Invoke((MethodInvoker)(() => name.Text = pr.StandardOutput.ReadToEnd()));
