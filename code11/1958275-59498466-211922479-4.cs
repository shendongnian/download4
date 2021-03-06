      ...
      foreach (var tuple in tuples) {
        var result = tuple
          .GetType()
          .GetProperties()
          .Where(prop => Regex.IsMatch(prop.Name, "^Item[0-9]+$"))
          .Select(prop => new {
             name  = prop.Name,
             value = prop.GetValue(tuple), 
           });
        foreach (var item in result)
          Debug.WriteLine($"{item.name} = {item.value}");
      }
      ...
