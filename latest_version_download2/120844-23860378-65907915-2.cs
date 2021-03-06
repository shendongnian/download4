    public static string ToTitleCase(string input, int minLength = 0)
    {
        TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
        string titleCaseDefault = ti.ToTitleCase(input);
        if (minLength == 0)
            return titleCaseDefault;
        StringBuilder sb = new StringBuilder(titleCaseDefault.Length);
        int wordCount = 0;
        char[] wordSeparatorChars = " \t\n.,;-:".ToCharArray();
        for (int i = 0; i < titleCaseDefault.Length; i++)
        {
            char c = titleCaseDefault[i];
            bool nonSpace = !char.IsWhiteSpace(c);
            if (nonSpace)
            {
                wordCount++;
                int firstSpace = titleCaseDefault.IndexOfAny(wordSeparatorChars, i);
                int endIndex = firstSpace >= 0 ? firstSpace : titleCaseDefault.Length;
                string word = titleCaseDefault.Substring(i, endIndex - i);
                if (wordCount == 1) // first word upper
                    sb.Append(word);
                else
                    sb.Append(word.Length < minLength ? word.ToLower() : ti.ToTitleCase(word));
                i = endIndex - 1;
            }
            else
                sb.Append(c);
        }
        return sb.ToString();
    }
