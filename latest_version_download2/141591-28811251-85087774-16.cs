    public ActionResult Index()
    {
        var viewModel = new CreatePatientViewModel();
        
        viewModel.Devices.Add(new SelectListItem() { Text = "Device 1", Value = "1" });
        viewModel.Devices.Add(new SelectListItem() { Text = "Device 2", Value = "2" });
    
        viewModel.Users.AddRange(db.Users.ToList());
    
        return View(viewModel);
    }
