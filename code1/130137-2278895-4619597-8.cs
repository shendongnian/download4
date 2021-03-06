    public static int MaxSequence(string str)
    {      
        MatchCollection matches = Regex.Matches(str, "H+|T+");
        return matches.Cast<Match>()
                      .Max(match => match.Value.Length);
    }
