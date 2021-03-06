    #region Check if another user's process is locking a pkg
    
    [StructLayout(LayoutKind.Sequential)]
    private struct RM_UNIQUE_PROCESS
    {
        public int dwProcessId;
        public System.Runtime.InteropServices.ComTypes.FILETIME ProcessStartTime;
    }
    
    private const int RmRebootReasonNone = 0;
    private const int CCH_RM_MAX_APP_NAME = 255;
    private const int CCH_RM_MAX_SVC_NAME = 63;
    
    //private enum RM_APP_TYPE
    //{
    //    RmUnknownApp = 0,
    //    RmMainWindow = 1,
    //    RmOtherWindow = 2,
    //    RmService = 3,
    //    RmExplorer = 4,
    //    RmConsole = 5,
    //    RmCritical = 1000
    //}
    
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    private struct RM_PROCESS_INFO
    {
        public RM_UNIQUE_PROCESS Process;
    
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCH_RM_MAX_APP_NAME + 1)]
        public string strAppName;
    
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCH_RM_MAX_SVC_NAME + 1)]
        public string strServiceShortName;
    
        //public RM_APP_TYPE ApplicationType;
        public uint AppStatus;
        public uint TSSessionId;
        [MarshalAs(UnmanagedType.Bool)]
        public bool bRestartable;
    }
    
    [DllImport("rstrtmgr.dll", CharSet = CharSet.Unicode)]
    private static extern int RmRegisterResources(uint pSessionHandle,
                                          UInt32 nFiles,
                                          string[] rgsFilenames,
                                          UInt32 nApplications,
                                          [In] RM_UNIQUE_PROCESS[] rgApplications,
                                          UInt32 nServices,
                                          string[] rgsServiceNames);
    
    [DllImport("rstrtmgr.dll", CharSet = CharSet.Auto)]
    private static extern int RmStartSession(out uint pSessionHandle, int dwSessionFlags, string strSessionKey);
    
    [DllImport("rstrtmgr.dll")]
    private static extern int RmEndSession(uint pSessionHandle);
    
    [DllImport("rstrtmgr.dll")]
    private static extern int RmGetList(uint dwSessionHandle,
                                out uint pnProcInfoNeeded,
                                ref uint pnProcInfo,
                                [In, Out] RM_PROCESS_INFO[] rgAffectedApps,
                                ref uint lpdwRebootReasons);
    
    
    /// <summary>
    /// Checks if a pkg has been locked by another user
    /// </summary>
    /// <param name="path">The pkg file path.</param>
    /// <param name="includeCurrentUserProcesses">Check also for current user's processes</param>
    /// <returns></returns>
    public static bool AnotherUserIsLockingPkg(string path, bool includeCurrentUserProcesses = false)
    {
        uint handle;
        string key = Guid.NewGuid().ToString();
        Process currentProcess = Process.GetCurrentProcess();
    
        int res = RmStartSession(out handle, 0, key);
        if (res != 0)
            throw new Exception("Could not begin restart session. Unable to determine file locker.");
    
        try
        {
            const int ERROR_MORE_DATA = 234;
    
            uint pnProcInfoNeeded = 0,
                 pnProcInfo = 0,
                 lpdwRebootReasons = RmRebootReasonNone;
    
            string[] resources = new string[] { path }; // Just checking on one resource.
    
            res = RmRegisterResources(handle, (uint)resources.Length, resources, 0, null, 0, null);
    
            if (res != 0)
                throw new Exception("Could not register resource.");
    
            //Note: there's a race condition here -- the first call to RmGetList() returns
            //      the total number of process. However, when we call RmGetList() again to get
            //      the actual processes this number may have increased.
            res = RmGetList(handle, out pnProcInfoNeeded, ref pnProcInfo, null, ref lpdwRebootReasons);
    
            if (res == ERROR_MORE_DATA)
            {
                // Create an array to store the process results
                RM_PROCESS_INFO[] processInfo = new RM_PROCESS_INFO[pnProcInfoNeeded];
                pnProcInfo = pnProcInfoNeeded;
    
                // Get the list
                res = RmGetList(handle, out pnProcInfoNeeded, ref pnProcInfo, processInfo, ref lpdwRebootReasons);
                //pnProcInfo contains all the processes that are using the pkg
    
                if (res == 0)
                {
                    // Enumerate all of the results and check for waf3 process and not same session
                    for (int i = 0; i < pnProcInfo; i++)
                    {
                        try
                        {
                            if (includeCurrentUserProcesses)
                            {
                                if (processInfo[i].strAppName == currentProcess.ProcessName)
                                    return true;
                            }
                            else
                            {
                                if (processInfo[i].strAppName == currentProcess.MainModule.ModuleName && processInfo[i].TSSessionId != currentProcess.SessionId)
                                    return true;
                            }
                        }
                        // catch the error -- in case the process is no longer running
                        catch (ArgumentException)
                        { }
                    }
                }
                else
                    throw new Exception("Could not list processes locking resource.");
            }
            else if (res != 0)
                throw new Exception("Could not list processes locking resource. Failed to get size of result.");
        }
        finally
        {
            RmEndSession(handle);
        }
    
        return false;
    }
    #endregion
