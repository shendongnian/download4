    public DateTime someDateTimeFormatted {
        get {
            DateTime.ParseExact(someDateTime, "dd MMM yyyy HH:mm:ss", CultureInfo.InvariantCulture);
        }
    }
