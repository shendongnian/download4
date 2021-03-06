    static void ParseLine(
        string line,
        int keyIndex,
        int keyLength,
        Action<List<byte>> txHandler,
        Action<List<byte>> rxHandler)
    {
        var re = new Regex(@"\[(TX|RX)\](?: ([0-9a-f]{2}))+");
        var match = re.Match(line);
        if (match.Success)
        {
            var mode = match.Groups[1].Value; // either TX or RX
            var values = match.Groups[2]
                .Captures.Cast<Capture>()
                .Skip(keyIndex)
                .Take(keyLength)
                .Select(c => Convert.ToByte(c.Value, 16))
                .ToList();
            if (mode == "TX") txHandler(values);
            else if (mode == "RX") rxHandler(values);
        }
    }
