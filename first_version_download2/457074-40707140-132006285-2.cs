    Redemption.RDOSession session = new Redemption.RDOSession();
    Redemption.RDOPstStore store = session.LogonPstStore(PstFileName);
    Redemption.RDOFolder folder = store.IPMRootFolder.Folders.Add("Backup folder");
    RDOMail item = folder.Items.Add("IPM.Note");
    item.Sent = true;
    item.Subject = "test";
    item.Body = "test body";
    item.Recipients.AddEx("The User", "user@domain.demo", "SMTP");
    item.UserProperties.Add("My custom prop", olText).Value = "custom prop value";
    item.Save();
