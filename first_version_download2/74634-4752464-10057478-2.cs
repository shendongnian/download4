    If (System.Windows.Forms.Application.MessageLoop)
    {
      // Use this since we are a WinForms app
      System.Windows.Forms.Application.Exit()
    }
    Else
    {
      // Use this since we are a console app
      System.Environment.Exit(1)
    }
