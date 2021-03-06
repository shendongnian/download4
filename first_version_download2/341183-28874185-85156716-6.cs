            var logs = new List<LogEntry>
            {
                new LogEntry(new DateTime(2015, 3, 5, 11, 10, 15), true),
                new LogEntry(new DateTime(2015, 3, 5, 11, 20, 15), false),
                new LogEntry(new DateTime(2015, 3, 5, 12, 30, 15), true),
                new LogEntry(new DateTime(2015, 3, 5, 13, 40, 15), false),
                new LogEntry(new DateTime(2015, 3, 5, 14, 50, 15), true),
                new LogEntry(new DateTime(2015, 3, 5, 15, 10, 15), false)
            };
            var results = new List<ResultEntry>();
            for (var i = 1; i < logs.Count; i++)
            {
                var logEntry = logs[i];
                if (!logEntry.Status) 
                    continue;
                var roundedStartDateTime = new DateTime(logEntry.DateTime.Year, logEntry.DateTime.Month, logEntry.DateTime.Day, logEntry.DateTime.Hour, 0, 0);
                var previousLogEntry = logs[i - 1];
                var startDateTime = roundedStartDateTime > previousLogEntry.DateTime
                    ? roundedStartDateTime
                    : previousLogEntry.DateTime;
                var roundedEndDateTime = roundedStartDateTime.AddHours(1);
                var endDateTime = roundedEndDateTime;
                if (i < logs.Count - 1)
                {
                    var nextLogEntry = logs[i + 1];
                    endDateTime = roundedEndDateTime < nextLogEntry.DateTime
                        ? roundedEndDateTime
                        : nextLogEntry.DateTime;
                }
                var minutesOn = Convert.ToInt32((endDateTime - startDateTime).TotalMinutes);
                results.Add(new ResultEntry(startDateTime, minutesOn));
            }
