    public ActionResult Foo()
    {
        LookUpViewModel Model = new LookUpViewModel();
        using(RosterManagementEntities rosterManagementContext = new RosterManagementEntities())
        {
            Model.tblCurrentLocations = from o in rosterManagementContext.tblCurrentLocations select o;
            Model.tblStreams = from o in rosterManagementContext.tblStreams select o; 
        }
    }
