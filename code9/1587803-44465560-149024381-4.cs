     UIntPtr _processHandle;
    
            public MeMorybox(Process process)
            {
                _processHandle = OpenProcess((uint)Access.AllAccess, false, (uint)process.Id);
    
               
                BoyerScan = new BoyerMoore(_processHandle);
              
            }
		
