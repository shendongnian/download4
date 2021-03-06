    // there are always multiple chrome processes, so we have to loop through all of them to find the
    // process with a Window Handle and an automation element of name "Address and search bar"
    Process[] procsChrome = Process.GetProcessesByName("chrome");
    foreach (Process chrome in procsChrome) {
      // the chrome process must have a window
      if (chrome.MainWindowHandle == IntPtr.Zero) {
        continue;
      }
      // find the automation element
      AutomationElement elm = AutomationElement.FromHandle(chrome.MainWindowHandle);
      AutomationElement elmUrlBar = elm.FindFirst(TreeScope.Descendants,
        new PropertyCondition(AutomationElement.NameProperty, "Address and search bar"));
      // if it can be found, get the value from the URL bar
      if (elmUrlBar != null) {
        AutomationPattern[] patterns = elmUrlBar.GetSupportedPatterns();
        if (patterns.Length > 0) {
          ValuePattern val = (ValuePattern)elmUrlBar.GetCurrentPattern(patterns[0]);
          Console.WriteLine("Chrome URL found: " + val.Current.Value);
        }
      }
    }
