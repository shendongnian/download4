    //you don't need a SmtpClient for each recipient
    SmtpClient smtpClient = new SmtpClient();
    foreach (String Email in usersList)
    { 
       if(Regex.IsMatch(Email, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*") 
       {
         using (MailMessage message = new MailMessage()){
             try{
                MailAddress AddressFrom = new MailAddress(emailFrom);
                message.From = AddressFrom;
                MailAddress AddressTo = new MailAddress(Email);
                message.To.Add(Email);
                smtpClient.Send(message);
             } catch{
             }
         }
       }
    }
    smtpClient.Dispose();
