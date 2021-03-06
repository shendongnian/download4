	var data = dc.People
		.Select(i => new { 
			i.PersonId, 
			FullName = i.FirstName + " " + i.LastName,
			i.IsAuthorised, 
			i.IsEnabled, 
			Colours = i.Colours.ToList()
		})
		.OrderByDescending(i => i.PersonId)
		.ToList();
