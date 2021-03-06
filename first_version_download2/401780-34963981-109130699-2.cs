    private static List<T> FilterList<T>( IEnumerable<T> source, Dictionary<string, object> propertyFilters )
    {
        var properties = propertyFilters.Keys.Distinct()
                                                .ToDictionary( x => x, x => typeof ( T ).GetProperty( x ).GetGetMethod() );
    
        IEnumerable<T> result = source.ToList();
        foreach ( var propertyFilter in propertyFilters )
        {
            if ( properties.ContainsKey( propertyFilter.Key ) )
            {
                result = result.Where( x =>
                {
                    var invoke = properties[propertyFilter.Key].Invoke( x, new object[0] );
                    return invoke.Equals( propertyFilter.Value );
                } );
            }
        }
        return result.ToList();
    } 
