    public string ShortIdentifier(string longIdentifier)
    {
        MacthCollection matches = Regex.Matches(longIdentifier, "[A-Z][a-z]{2}");
        if (matches.Count == 1) {
            return matches[0].Value;
        } else if (matches.Count >= 2) {
            return matches[0].Value + matches[1].Value;
        }
        return longIdentifier.Substring(0, 6);
    }
