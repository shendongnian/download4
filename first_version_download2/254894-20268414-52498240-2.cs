    private IEnumerable<Control> GetControls(ControlCollection controls)
    {
        var lst = new List<Control>();
        if (controls == null)
            return lst;
        foreach(var ctrl in controls)
        {
            if (ctrl.Id.EndsWith("EditMode"))
               lst.Add(ctrl);
            lst.AddRange(GetControls(ctrl.Controls);
        }
        return lst;
    }
