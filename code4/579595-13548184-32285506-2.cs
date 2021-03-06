    static IEnumerable<string> SplitByCharacterType(string input)
    {
        if (String.IsNullOrEmpty(input)) throw new ArgumentNullException("input");
        string segment = input[0].ToString();
        System.Globalization.UnicodeCategory cat = Char.GetUnicodeCategory(input[0]);
        for (int i = 1; i < input.Length; i++)
        {
            if (Char.GetUnicodeCategory(input[i]) == cat)
            {
                segment += input[i];
            }
            else
            {
                yield return segment;
                segment = input[i].ToString();
                cat = Char.GetUnicodeCategory(input[i]);
            }
        }
        yield return segment;
    }
