        int lastCount = 0;
        while (true)
        {
                portCount = 0;
                MultipleClock = false;
                OneClock = false;
                NoClock = false;
                //clear the string list.
                MultiplePortNames.Clear();
                //create an object searcher and fill it with the path and the query provided above.
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
                try
                {
                    foreach (ManagementObject queryObj in searcher.Get())
                    {
                        if (queryObj["InstanceName"].ToString().Contains("USB") || queryObj["InstanceName"].ToString().Contains("FTDIBUS"))
                        {
                            portCount = searcher.Get().Count;
                            if (portCount >= 1)
                                MultiplePortNames.Add(queryObj["PortName"].ToString());
                        }
                    }
                }
                catch
                {
                } 
                if(portCount == 1) 
                    OneClock = true;
                else if(portCount > 1)
                    MultipleClock = true;
                else
                    NoClock = true;
                if(lastCount != portCount)
                {
                     lastCount = portCount;
                     form1.UpdateListBox(MultiplePortNames);
                }
                Debug.WriteLine("NoClock = " + NoClock);
                Debug.WriteLine("OneClock = " + OneClock);
                Debug.WriteLine("MultipleClock = " + MultipleClock);
    
                Thread.Sleep(500);
        }
