        Dictionary<string, Dictionary<string, Dictionary<int, int>>> UserCityPermissions = new Dictionary<string, Dictionary<string, Dictionary<int, int>>>();
        UserCityPermissions.Add("John", new Dictionary<string, Dictionary<int, int>>());
        UserCityPermissions["John"].Add("NY", new Dictionary<int,int>());
        UserCityPermissions["John"]["NY"].Add(1, 1);
        UserCityPermissions["John"]["NY"].Add(2, 2);
        UserCityPermissions["John"]["NY"].Add(3, 3);
        UserCityPermissions["John"].Add("DC", new Dictionary<int, int>());
        UserCityPermissions["John"]["DC"].Add(3, 3);
        UserCityPermissions["John"]["DC"].Add(4, 4);
        UserCityPermissions.Add("Jane", new Dictionary<string, Dictionary<int, int>>());
        UserCityPermissions["Jane"].Add("DC", new Dictionary<int, int>());
        UserCityPermissions["Jane"]["DC"].Add(1, 1);
        UserCityPermissions["Jane"]["DC"].Add(2, 2);
        UserCityPermissions["Jane"].Add("NY", new Dictionary<int, int>());
        UserCityPermissions["Jane"]["NY"].Add(6, 6);
