      class CategoryLookupPatternConverter : PatternLayoutConverter
      {
        protected override void Convert(System.IO.TextWriter writer, LoggingEvent loggingEvent)
        {
          //Assumes logger name is fully qualified classname.  Need smarter code to handle
          //arbitrary logger names.
          string [] names = loggingEvent.LoggerName.Split('.');
          string cat;
          if (Option > 0 && Option < names.Length)
          {
            cat = names[names.Length - Option];
          }
          else
          {
            string cat = names[names.Length - 1];
          }
          writer.Write(setting);
        }
      }
