        MailMessage msgMail = new MailMessage();
        MailMessage myMessage = new MailMessage();
        myMessage.From = new MailAddress("sender's email","sender`s name and surname");
        myMessage.To.Add("recipient's email");
        myMessage.Subject = "Subject";
        myMessage.IsBodyHtml = true;
        myMessage.Body = "Message Body";
        SmtpClient mySmtpClient = new SmtpClient();
        System.Net.NetworkCredential myCredential = new System.Net.NetworkCredential("email", "password");
        mySmtpClient.Host = "your smtp host address";
        mySmtpClient.UseDefaultCredentials = false;
        mySmtpClient.Credentials = myCredential;
        mySmtpClient.ServicePoint.MaxIdleTime = 1;
        mySmtpClient.Send(myMessage);
        myMessage.Dispose();
