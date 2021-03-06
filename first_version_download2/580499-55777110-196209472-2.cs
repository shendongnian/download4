    var sql = "SELECT " +
                    "m.MovieID, " +
                    "m.Runtime, " +
                    "m.Description, " +
                    "m.Title, " +
                    "m.Director, " +
                    "m.Genres, " +
                    "p.MovieID, " +
                    "p.ProjectionID, " +
                    "p.Time, " +
                    "p.Price, " +
                    "p.Hall " +
              "FROM Movie AS m INNER JOIN Projection AS p " +
                "ON m.MovieID = p.MovieID ";
     using (var connection = new OleDbConnection(GetConnectionString("CinemaDB")))
    {
        var movieDictionary = new Dictionary<int, Movie>();
        list = connection.Query<Movie, Projection, Movie>(sql, (movie, projection) =>
        {
             Movie movieEntry = null;
             if(movieDictionary.ContainsKey(movie.MovieID))
                 movieEntry = movieDictionary[movie.MovieID];
             else
             {
                 movieEntry = movie;
                 movieEntry.Projections = new List<Projection>();
                 movieDictionary.Add(movieEntry.MovieID, movieEntry);
             }
             movieEntry.Projections.Add(projection);
             return movie;
        },splitOn: "p.MovieID");
    }
    return movieDictionary.Values.ToList();
