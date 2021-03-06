    using (var db = new Entities())
        {
             db.Configuration.LazyLoadingEnabled = false;
             db.Configuration.ProxyCreationEnabled = false;
        
             var myprojection = db.Table1 
                                //.AsNoTracking()  //remove.AsNoTracking() from here
                                .Select(x => new
                                {
                                    table1= x,
                                    table2= x.Table2.Where(g => Some Condition),
                                    table3= x.Table3.Where(g=>Some Condition)
                                })
                                .AsNoTracking()//add .AsNoTracking() here
                                .ToList();    
            
            var result = myprojection.Select(g =>g.table1).FirstOrDefault();    
        }
