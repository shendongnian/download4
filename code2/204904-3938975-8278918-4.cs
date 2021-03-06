    var strings = new List<string>() { "82&?887..2", "82,9", "abse82,9>dpkg" };
    var result = strings.Select(s =>
        String.Join("",
            s.SkipWhile(c => !char.IsNumber(c))
            .TakeWhile(c => (char.IsNumber(c) || c == ','))
            .ToArray()
        )
    ).Where(s => char.IsNumber(s.LastOrDefault())).ToList();
