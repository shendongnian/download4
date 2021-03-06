        LoggingRule richTextBoxRule = new LoggingRule("*",  asyncWrapper);
        richTextBoxRule.EnableLoggingForLevel(LogLevel.Debug);
        richTextBoxRule.EnableLoggingForLevel(LogLevel.Error);
        richTextBoxRule.EnableLoggingForLevel(LogLevel.Fatal);
        richTextBoxRule.EnableLoggingForLevel(LogLevel.Info);
        richTextBoxRule.EnableLoggingForLevel(LogLevel.Trace);
        richTextBoxRule.EnableLoggingForLevel(LogLevel.Warn);
        LogManager.Configuration.AddTarget(asyncWrapper.Name, asyncWrapper);
        LogManager.Configuration.LoggingRules.Add(richTextBoxRule);
        LogManager.ReconfigExistingLoggers();
