        char[] passwordChars = passwordPre.ToCharArray();
        System.Security.SecureString securePassword = new System.Security.SecureString();
        foreach (char c in passwordChars)
            securePassword.AppendChar(c);
        string decryptedPassword = securePassword
