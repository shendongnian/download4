    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);
        //if (!IsOpenFileDialog) return;
        if (m.Msg == 289) //Notify of message loop
        {
            try
            {
                uint dialogHandle = (uint)m.LParam;	//handle of the file dialog
                if (dialogHandle != _lastDialogHandle) //only when not already changed
                {
                    _lastDialogHandle = dialogHandle;
                    SendKeys.SendWait("+{TAB}");
                    SendKeys.SendWait("+{TAB}");
                    SendKeys.SendWait("temp.xls");
                    //Or try via Win32
                    //List<string> childWindows = GetDialogChildWindows(dialogHandle);
                    //TODO set ListView Item
                 }
             }
          }
      }
