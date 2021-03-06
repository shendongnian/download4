    //-----------------------------------------------------------------------------
    // <copyright file="Program.cs" company="DCOM Productions">
    //     Copyright (c) DCOM Productions.  All rights reserved.
    // </copyright>
    //-----------------------------------------------------------------------------
    namespace Setup {
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Windows.Forms;
        using Setup.Forms;
        using System.Security.Principal;
        using System.Diagnostics;
        static class Program {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main() {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                WindowsPrincipal principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
                bool administrativeMode = principal.IsInRole(WindowsBuiltInRole.Administrator);
                if (!administrativeMode) {
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.Verb = "runas";
                    startInfo.FileName = Application.ExecutablePath;
                    try {
                        Process.Start(startInfo);
                    }
                    catch {
                        return;
                    }
                    return;
                }
                Application.Run(new ShellForm());
            }
        }
    }
