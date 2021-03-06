     public class SMSNotifier
        {
            public SMSNotifier()
            {
                var accountSid = ConfigurationManager.AppSettings["TwilioSid"];
                // Your Auth Token from twilio.com/console
                var authToken = ConfigurationManager.AppSettings["TwilioToken"]; ;
    
                TwilioClient.Init(accountSid, authToken);
            }
    
            public async Task SendWaitingPatientNotification(AspNetUser user, string phonenumber)
            {
                var message = await MessageResource.CreateAsync(
                 to: new PhoneNumber("+1" + phonenumber),
                 from: new PhoneNumber("+xxxxxxxxxx"),
                 body: string.Format("Patient {0} {1} has entered the waiting room at {2}. Please visit the patient queue to see patient.", user.FirstName, user.LastName, DateTime.Now.ToString()));
                
            }
        }
