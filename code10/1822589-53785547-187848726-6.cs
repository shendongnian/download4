    public static class Cultures
    {
        public static readonly CultureInfo UnitedKingdom = 
            CultureInfo.GetCultureInfo("en-GB");
    }
    Then:
    
    Money.ToString("C", Cultures.UnitedKingdom)
