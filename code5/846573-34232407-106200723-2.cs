    System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient
            {
                Host = Emailer.Host,
                Port = Emailer.Port,
                Credentials = creds,
                EnableSsl = Emailer.RequireSSL,
                UseDefaultCredentials = false,
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network
            }
