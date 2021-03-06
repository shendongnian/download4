    List<MenuModel> lstMenuModel = dtable.DataTableToList<XXX>().GroupBy(x => new { ParentID  = x.ParentID, ParentName = x.ParentName }).Select(x => new MenuModel()
    {
        ParentID = x.Key.ParentID,
        ParentName = x.Key.ParentName,
        MenuItems = x.Select(y => new MenuItemModel()
        {
            ChildID = y.ChildID,
            ChildName = y.ChildName,
            PageURL = y.PageURL
        }).ToList()
    }).ToList();
