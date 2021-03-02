    var query = context.Logins.Where( l => l.UserID == userID )
                              .Select( l => new { Date = l.Date, What = "logged in" } )
                      .Union( context.Actions.Where( a => a.UserID == userID )
                                              .Select( a => new { Date = a.Date, What = a.Action  } ))
                      .OrderBy( r => r.Date );
