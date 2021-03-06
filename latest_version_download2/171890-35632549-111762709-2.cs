    public static string RemoveDiacritics(this String s)
    {
        String normalizedString = s.Normalize(NormalizationForm.FormD);
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < normalizedString.Length; i++)
        {
            Char c = normalizedString[i];
            if (System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c) != System.Globalization.UnicodeCategory.NonSpacingMark)
                stringBuilder.Append(c);
        }
        return stringBuilder.ToString();
    }
