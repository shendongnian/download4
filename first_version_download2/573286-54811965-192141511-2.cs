    public static class Extensions
    {
        public static bool ContainsNoCase(this string stringToLookIn, string stringToFind)
        {
            return stringToLookIn.IndexOf(stringToFind, StringComparison.InvariantCultureIgnoreCase) >= 0;
        }
    }
