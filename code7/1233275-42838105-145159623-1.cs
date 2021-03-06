    Dim clientTZService As ExchangeService = New ExchangeService(ExchangeVersion.Exchange2010)
      
        clientTZService.Credentials = New NetworkCredential(userEmail, userPass)
        clientTZService.AutodiscoverUrl(userEmail, AddressOf RedirectionCallBack)
       
        ' Create the task
        Dim Task1 As Task = New Task(clientTZService)
        Task1.Subject = "New Task"
        Task1.Body = New MessageBody(String.Format("test"))
        Task1.StartDate = DateTime.Now
        Dim DueDate As DateTime = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 2)
        Task1.DueDate = DueDate
     
           Task1.Save(New FolderId(WellKnownFolderName.Tasks, "test@domain.com"))
