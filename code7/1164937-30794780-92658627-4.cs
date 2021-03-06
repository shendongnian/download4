    var query = db.person.AsQueryable();
    if(!String.IsNullOrEmpty(name)) {
        query = query.Where(a => a.person.Contains(name));
    }
    var result = query.Select(s => new { Name = s.FullName, DOB = s.DOB })
                      .ToList();
