    List<string> invalidType = new List<string>();
    .....
    // Probably you don't need to check for null but for element count.
    // However it doesn't hurt to be a little defensive...
    if (invalidType != null && invalidType.Count > 0)
    {
        string attachments = string.join(",", invalidType);
        emailInvalidBody = new ItemBody
        {
            Content = " Expense attachments received with subject line [ " + 
                      email.Subject + " ] sent at  [  " + 
                      email.DateTimeReceived.Value.DateTime.ToLocalTime() + 
                      " ]  had the following invalid attachments [" + 
                      attachments + "].  Please make sure all " + 
                      " attachment's are images or PDF's.",
        };
    }
