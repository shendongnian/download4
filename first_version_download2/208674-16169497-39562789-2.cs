    Client.GetPassWordByNameCompleted += ((s, e) =>
    {
        if (e.Error == null)
        {
        }
        else
        {
            password = e.Result;
            if(EnteredPassword == password)
            {
                    isAuthenticated = true;
            }
        }
    });
    Client.GetPassWordByNameAsync(user);
