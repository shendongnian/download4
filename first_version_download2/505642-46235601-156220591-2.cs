    foreach(var page in tabControl1.TabPages){
    	var server = ProcessControls(page.controls, "txtServer");
    	//... continue with the others
    }
    
    private TextBox ProcessControls(Control ctrlContainer, string name) 
    { 
        foreach (Control ctrl in ctrlContainer.Controls) 
        { 
            if (ctrl.GetType() == typeof(TextBox)) 
            { 
                if(ctrl.Name.StartsWith(name))
    				return ctrl;
            }
        } 
    }
