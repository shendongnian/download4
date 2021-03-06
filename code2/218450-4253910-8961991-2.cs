    // Connect to Active Directory and get the DirectoryEntry object.
    // Note, ADPath is an Active Directory path pointing to a user. You would have created this
    // path by calling a GetUser() function, which searches AD for the specified user
    // and returns its DirectoryEntry object or path. See [here][1].
    DirectoryEntry oDE;
    oDE = new DirectoryEntry(ADPath, ADUser, ADPassword, AuthenticationTypes.Secure);
    
    try
    {
       // Change the password.
       oDE.Invoke("ChangePassword", new object[]{strOldPassword, strNewPassword});
    } 
    catch (Exception excep)
    {
       Debug.WriteLine("Error changing password. Reason: " + excep.Message);
    }
