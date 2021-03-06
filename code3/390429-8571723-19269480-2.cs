    try
    {
        if (vm.SubmitAction == "Cancel")
            return ShowSummary();
        _account.ValidateNoDuplicate(vm.Account);
        vm.Account.Modified = DateTime.Now;
        vm.Account.ModifiedBy = User.Identity.Name;
        _account.AddOrUpdate(vm.Account);
    }
    catch (Exception e) { 
        log(e); 
        return View("CreateEdit", vm); 
    }
    return ShowSummary();
