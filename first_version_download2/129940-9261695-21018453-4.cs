    // Do this once...
    var pattern = LocalDateTimePattern.CreateWithInvariantInfo("yyyyMMddHHmm");
    // Do this repeatedly...
    var parseResult = pattern.Parse(text);
    if (parseResult.Success)
    {
        LocalDateTime value = parseResult.Value;
        // Use the value...
    }
    else
    {
        // Error... 
    }
