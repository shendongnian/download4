    collection.AsQueryable()
      .GroupBy(p => p.EndpointId, (k,s) => new
        {
          tags = s.Sum(p => p.Tags.Count()),
          sensors = s.Sum(p => p.Tags.Select(x => x.Sensors.Count()).Sum())
        }
      );
