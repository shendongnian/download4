     public void AddUser(string domain, string firstName, string lastName, string email,string comment, string telephoneNumber, string jobTitle)
        {
            string userName = string.Concat(firstName, lastName);
            userName = string.Format(@"{0}\{1}", domain, userName);
          string newPassword = Membership.GeneratePassword(10, 3);
            
             try
            {
                if (!User.Exists(userName))
                {
                    Membership.CreateUser(userName, newPassword, email);
                    // Edit the profile information
                    Sitecore.Security.Accounts.User user = Sitecore.Security.Accounts.User.FromName(userName, true);
                    Sitecore.Security.UserProfile userProfile = user.Profile;
                    userProfile.FullName = string.Format("{0} {1}", firstName, lastName);
                    userProfile.Comment = comment;
                    // Assigning the user profile template
                    userProfile.SetPropertyValue("ProfileItemId", "{AE4C4969-5B7E-4B4E-9042-B2D8701CE214}");
                    // Have modified the user template to also contain telephone number and job title.
                    userProfile.SetCustomProperty("TelephoneNumber", telephoneNumber);
                    userProfile.SetCustomProperty("JobTitle", jobTitle);
                    userProfile.Save();
                }
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error(string.Format("Error in Client.Project.Security.UserMaintenance (AddUser): Message: {0}; Source:{1}", ex.Message, ex.Source), this);
            }
        } 
 
