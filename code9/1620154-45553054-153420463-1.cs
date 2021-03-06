    public static async Task<List<FooModel>> ListFooModelAsync()
    {
        using (var db = new AppDbContext())
        {
            var foo_items = db.Foos
                .Select(e => new FooModel
                {
                    Id = e.Id,            
                    Name = e.Name,
                    Childs = e.Childs.Select(
                        child => new ChildModel { Id = child.Id, Name = child.Name })
                })
                .ToListAsync();
            return foo_items;
        }
    }
