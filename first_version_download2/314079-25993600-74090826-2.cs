    DateTime result;
    if (DateTime.TryParse(input, out result))
    {
        // the delta between two datetimes is a timespan.
        TimeSpan delta = result - DateTime.Now;
        TimeLeftToSleep.Text = delta.ToString();
    }
    else
    {
        // the textbox doesn't contain a valid datetime.
    }
