    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Threading;
    
    namespace Echo
    {
        class Program
        {
            private static void Read(StreamReader reader)
            {
                new Thread(() =>
                {
                    while (true)
                    {
                        int current;
                        while ((current = reader.Read()) >= 0)
                            Console.Write((char)current);
                    }
                }).Start();
            }
    
            static void Main(string[] args)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(@"/usr/bin/ssh");
                startInfo.Arguments = "-ttty localhost";
                startInfo.CreateNoWindow = true;
                startInfo.ErrorDialog = false;
                startInfo.RedirectStandardError = true;
                startInfo.RedirectStandardInput = true;
                startInfo.RedirectStandardOutput = true;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;
                Process process = new Process();
                process.StartInfo = startInfo;
                process.Start();
                Thread.Sleep(15000); //time to login
                Read(process.StandardOutput);
                Read(process.StandardError);
                process.StandardInput.WriteLine("echoing your input now");
                while (!process.HasExited)
                    try { process.StandardInput.WriteLine(Console.ReadLine()); }
                    catch {}
                Console.WriteLine(process.ExitCode.ToString());    
            }
        }
    }
