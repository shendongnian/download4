    public ActionResult Index()
    {
        var _obj = new List<C>();
        var Get_ClientInfor = example();
    
        foreach (var item in Get_ClientInfor)
        {
            var _objAdd = new C();
    
            _objAdd.FirstName = item.Clients.FirstName;
            _objAdd.LastName = item.Clients.LastName;
            if (item.Clients.DateBirth != null)
                _objAdd.Dob = item.Clients.DateBirth.Value;
            _objAdd.Gender = item.ClientDemographics.Gender;
    
    
            _obj.Add(_objAdd);
        }
    
    
        return View(_obj);
    }
