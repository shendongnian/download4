    var baseImagePath = rootSiteData.GetNewPath() + '/';
    using (var context = new NewsDbContext())
    {
        var data = context.News.GroupBy(x => x.Category)
            .Select(x => new
            {
                data = new 
                {
                    CatId = x.Key.Id, 
                    catName = x.Key.Name,
                    newsContents = x.OrderBy(n => n.CreatedDate)
                    .Select(n => new 
                    {
                        id = n.Id,
                        imagePath = baseImagePath + n.ImagePath,
                        title = n.Title,
                        description = n.Description
                     }).Take(6).ToList()
            }).ToList();
        // Serialize data.
    }
