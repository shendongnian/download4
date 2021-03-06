    string Sender     = "username@domain.com";
    
    string Username   = "username";
    string Password   = "********";
    
    string Recipient  = "username@domain.com";
    
    string Subject    = "Enter subject here.";
    string Message    = "Enter message here.";
    
    string Host       = "mail.server.com";
    int Port          = 26;
    
    using(MailMessage Mail = 
          new MailMessage(
          Sender,
          Recipient))
    using (SmtpClient SmtpMail =
           new SmtpClient(
           Host,
           Port))
    {
      Mail.Subject = Subject;
      Mail.Body    = Message;
    
      SmtpMail.EnableSsl = true;
    
      SmtpMail.Credentials =
    		new System.Net.NetworkCredential(
    		Username,
    		Password);
    
      SmtpMail.Send(Mail);
    }
