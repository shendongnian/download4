    private void LoadGroup(string option) {
        Group group = GetGroup(option);
        string groupName = GetGroupName(option);
        Grid grid = GetGrid(option);
    
        BindGroup(group, groupName, grid);
    }
    
    Group GetGroup(string option) {
        // ideally this should be defined and initialized elsewhere
        var dictionary = new Dictionary<string, Group>() {
            new { "ALPHA", ManagerContext.Current.Group1 },
            new { "BETA", ManagerContext.Current.Group2 },
            new { "CHARLIE", ManagerContext.Current.Group3 },
            new { "DELTA", ManagerContext.Current.Group4 },
        };   
 
        return dictionary[option.ToUpperInvariant()];
    }
    string GetGroupName(string option) {
        return option.ToLowerInvariant() + "Group";
    }
    Grid GetGrid(string option) {
        // ideally this should be defined and initialized elsewhere
        var dictionary = new Dictionary<string, Grid>() {
            new { "ALPHA", uxAlphaGrid },
            new { "BETA", uxBetaGrid },
            new { "CHARLIE", uxCharlieGrid },
            new { "DELTA", uxDeltaGrid },
        };
        return dictionary[option.ToUpperInvariant()];
    }
    void BindGroup(Group group, string groupName, Grid grid) {
        VList<T> groupList = FetchInformation(group);
        if (Session[groupName] != null) {
            List<T> tempList = (List<T>)Session[groupName];
            groupList.AddRange(tempList);
        }
        grid.DataSource = groupList;
        grid.DataBind();
    }
