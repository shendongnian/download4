    ICollection<Movie>  moviesCollection = new Collection<Movie>();
    var movie = new Movie();
    // for each movie...
    moviesCollection.Add(movie);
    // if you use System.Linq you can convert any IEnumerable<T> to array
    // by calling ToArraY()
    movies = moviesCollection.ToArray();
