    return articles.Where(!(entity.HideUntilDate != null && entity .HideUntilDate.Value > DateTime.Today)).Select(entity => new OrderCateringArticleViewModel
    {
       ArticleId = entity.Id,
       ImagePath = entity.ImagePath
    });
