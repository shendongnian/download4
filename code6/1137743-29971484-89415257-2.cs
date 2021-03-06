    public IEnumerable<User> Query()
    {
        if (!String.IsNullOrEmpty(query))
        {
            int ext = 0;
            if (query.Contains("."))
            {
                return repository.SelectSearchByEmail(query.Trim());
            }
            else if (query.Contains(","))
            {
                var names = query.Split(',');
                var firstName  = names[0];
                var lastName = names[1];
                return repository.SelectSearchByFirstAndLastName(firstName, lastName);
            }
            else if (query.Contains(" ") && query.Split(" ").Length ==2 ) //This Line
            {
                var names = query.Split(' ');
                var firstName = names[0];
                var lastName = names[1];
                return repository.SelectSearchByFirstAndLastName(firstName, lastName);
            }
            else if (query.Contains("_"))
            {
                var names = query.Split('_');
                var firstName = names[0];
                var lastName = names[1];
                return repository.SelectSearchByFirstAndLastName(firstName, lastName);
            }
            else if (int.TryParse(query, out ext))
            {
                return repository.SelectSearchByExt(ext);
            }
            else
            {
                return repository.SelectAllUserByQuery(query);
            }
        }
        return new List<User>();
    }
