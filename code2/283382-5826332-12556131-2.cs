    System.ComponentModel.BindingList<Client> bindings = new System.ComponentModel.BindingList<Client>();
    
    Client clientA = bindings.AddNew();
    clientA.Firstname = "John";
    
    textEditControl.DataSource = bindings;
    
    // This change presumably will be refelected in control
    clientA.Firstname = "Jane";
