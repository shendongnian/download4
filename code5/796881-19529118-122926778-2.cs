    class JiraTimeDurationParser
    {
      
      /// <summary>
      /// Jira's configured value for [working] days per week ;
      /// </summary>
      public ushort DaysPerWeek     { get ; private set ; }
      
      /// <summary>
      /// Jira's configured value for [working] hours per day
      /// </summary>
      public ushort HoursPerDay     { get ; private set ; }
      
      public JiraTimeDurationParser( ushort daysPerWeek = 5 , ushort hoursPerDay = 8 )
      {
        if ( daysPerWeek < 1 || daysPerWeek >  7 ) throw new ArgumentOutOfRangeException( "daysPerWeek"  ) ;
        if ( hoursPerDay < 1 || hoursPerDay > 24 ) throw new ArgumentOutOfRangeException( "hoursPerDay"  ) ;
        
        this.DaysPerWeek = daysPerWeek ;
        this.HoursPerDay = hoursPerDay ;
        
        return ;
      }
      
      private static Regex rxDuration = new Regex( @"
        ^                                   # drop anchor at start-of-line
          [\x20\t]* ((?<weeks>   \d+ ) w )? # Optional whitespace, followed by an optional number of weeks
          [\x20\t]* ((?<days>    \d+ ) d )? # Optional whitesapce, followed by an optional number of days
          [\x20\t]* ((?<hours>   \d+ ) h )? # Optional whitespace, followed by an optional number of hours
          [\x20\t]* ((?<minutes> \d+ ) m )  # Optional whitespace, followed by a mandatory number of minutes
          [\x20\t]*                         # Optional trailing whitespace
        $                                   # followed by end-of-line
        " ,
        RegexOptions.IgnorePatternWhitespace
        ) ;
      
      public TimeSpan Parse( string jiraDuration )
      {
        if ( string.IsNullOrEmpty( jiraDuration ) ) throw new ArgumentOutOfRangeException("jiraDuration");
                    
        Match m = rxDuration.Match( jiraDuration ) ;
        if ( !m.Success ) throw new ArgumentOutOfRangeException("jiraDuration") ;
        
        int weeks   ; bool hasWeeks   = int.TryParse( m.Groups[ "weeks"   ].Value , out weeks   ) ;
        int days    ; bool hasDays    = int.TryParse( m.Groups[ "days"    ].Value , out days    ) ;
        int hours   ; bool hasHours   = int.TryParse( m.Groups[ "hours"   ].Value , out hours   ) ;
        int minutes ; bool hasMinutes = int.TryParse( m.Groups[ "minutes" ].Value , out minutes ) ;
        
        bool isValid = hasWeeks|hasDays|hasHours|hasMinutes ;
        if ( !isValid ) throw new ArgumentOutOfRangeException("jiraDuration") ;
        
        TimeSpan duration = new TimeSpan( weeks*DaysPerWeek*HoursPerDay + days*HoursPerDay + hours , minutes , 0 );
        return duration ;
            
      }
      public bool TryParse( string jiraDuration , out TimeSpan timeSpan )
      {
        bool success ;
        try
        {
          timeSpan = Parse(jiraDuration) ;
          success = true ;
        }
        catch
        {
          timeSpan = default(TimeSpan) ;
          success  = false ;
        }
        return success ;
      }
    
    }
