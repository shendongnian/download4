    if (Session["vlans"] == null )
    {
       _context = new nsdc_supplyEntities();
       _vc = new VlanClass(_context);
       _ec = new EnvironmentTypesClass(_context);
        Session["vlans"] = _vc.GetAllVlans();
        Session["context"] = _context;
    }
    else
    {
        _context = (DbContext)Session["context"];  // cast to your Context
       _vc = (WhateverClassThisWouldBe) Session["vlans"]  ;
    }
    if (!IsPostBack)
    {
        BindData();
    }
