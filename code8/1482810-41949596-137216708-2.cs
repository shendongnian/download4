        [Service]
        public class FCMRegistrationService : IntentService
        {
            private const string Tag = "FCMRegistrationService";
            static object locker = new object();
         
            protected override void OnHandleIntent(Intent intent)
            {
                try
                {
                    lock (locker)
                    {
                        var instanceId = FirebaseInstanceId.Instance;
                        var token = instanceId.Token;
    
                        if (string.IsNullOrEmpty(token))
                            return;
    
    #if DEBUG
                        instanceId.DeleteToken(token, "");
                        instanceId.DeleteInstanceId();
                        //   token = instanceId.GetToken(_senderId, "");
    #endif
    
                        //  if (!Settings.FcmTokenId.Equals(token))
                        //       SendRegistrationToAppServer(Settings.FcmTokenId, token);
    
                        //Settings.FcmTokenId = token;
                        //Subscribe(token);
                    }
                }
                catch (Exception e)
                {
                    Log.Debug(Tag, e.Message);
                }
            }
        }
