    string input = "..."; // This is your input string.
    int last = 0;
    var output = new StringBuilder(input.Length);
    
    foreach (Match match in regex.Matches(input)) {
        output.Append(input.Substring(last, match.Index - last);
        output.AppendFormat("<a href=\"{1}\">{0}</a>", match.Value, dictionary[match.Value]);
        last = match.Index + match.Length;
    }
