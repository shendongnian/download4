    using System;
    using Innovative.SolarCalculator;
    // ***
    // *** Geo coordinates of Oak Street Beach in Chicago, IL
    // ***
    // *** NOTE: the .Date is not necessary but is included to demonstrate that time input 
    // *** does not affect the output. Time will be returned in the current time zone so it 
    // *** will need to be adjusted to the time zone where the coordinates are from (there 
    // *** are services that can be used to get time zone from a latitude and longitude position).
    // ***
    TimeZoneInfo cst = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
    SolarTimes solarTimes = new SolarTimes(DateTime.Now.Date, 41.9032, -87.6224);
    DateTime sunrise = TimeZoneInfo.ConvertTimeFromUtc (solarTimes.Sunrise.ToUniversalTime(), cst);
    // ***
    // *** Display the sunrise
    // ***
    Console.WriteLine ("View the sunrise across Lake Michigan from Oak Street Beach in Chicago at {0} on {1}.", sunrise.ToLongTimeString(), sunrise.ToLongDateString());
