                ClientContext ctx = new ClientContext("http://sp/sites/dev");
                List list = ctx.Web.Lists.GetByTitle("MyList");
                ListItem item = list.GetItemById(6);
                ctx.Load(item);
                ctx.ExecuteQuery();
                User theUser = ctx.Web.EnsureUser("Contoso\\Jerry");
                ctx.Load(theUser);
                ctx.ExecuteQuery();
                item["Editor"] = theUser;
                item["Author"] = theUser;
                item.Update(); 
                ctx.ExecuteQuery();
