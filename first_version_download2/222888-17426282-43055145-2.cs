       <td>
                            @Html.ActionLink("EditUser", "Index", new { Id = m.ID,Name = m.Name })
                        </td>
    
    
      public ActionResult Index(string Id, string Name)
            {
                var model = new RegisterModel();
                int _ID = 0;
                int.TryParse(Id, out _ID);
                if (_ID > 0)
                {
                    RegisterModel register = GetRegisterUserById(_ID);
                    model.ID = _ID;
                    model.Name = register.Name;
                    model.Address = register.Address;
                    model.PhoneNo = register.PhoneNo;
    
                }
                return View(model);
            }
