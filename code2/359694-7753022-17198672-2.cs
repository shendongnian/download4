    string navigationIdString = GetNavID(oPage.Title)
    if (navigationIdString.StartWith("S"))
    {
        int navigationID = 0;
        if (int.TryParse(navigationIdString.SubString(1), navigationID)
        {
             if(navigationID > 0)
             {
                 ...
             } 
        }
    }
