            if (e.CommandName == "Valj")
            {
                var valj = new Guid((string)e.CommandArgument);
                var visadagbok = (from x in DagbokFactoryBase.All
                                     where (x.ID == valj)
                                     select x).FirstOrDefault();
                Show(visadagbok);
            }
        }
