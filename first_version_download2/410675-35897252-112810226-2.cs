    // If the string contains a space, split it
    string surname = Name2;
    int spacePos = surname.IndexOf(" ");
    if (spacePos > 0)
    {
        string[] words = s.Split(' ');
        surname = words[1];
    }
