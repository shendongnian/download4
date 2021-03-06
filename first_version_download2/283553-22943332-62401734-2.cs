    public string GetCategoryName(int albumCategoryId)
    {
        var _db = new Trying.Models.AlbumContext();
    
        IQueryable<Category> query = _db.Categories;
        Category ca = query.FirstOrDefault(c => c.id == albumCategoryId);
        
        return ca.name;
    }
