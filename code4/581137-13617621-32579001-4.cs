    private void GEWebBrowser1OnPluginReady(object sender, GEEventArgs geEventArgs)
    {
        this.geWebBrowser1.AddEventListener(geEventArgs.ApiObject.getGlobe(), EventId.MouseDown);
        this.geWebBrowser1.KmlEvent += geWebBrowser1_KmlEvent;
    }
        
    void geWebBrowser1_KmlEvent(object sender, GEEventArgs e)
    {
        // the feature that the mousedown event fired on
        dynamic feature = e.ApiObject.getTarget();
    
        // If you have other events added you will need some conditional logic here
        // to sort out which event has fired. e.g.
        // if(e.EventId == EventId.MouseDown)
        // if(GEHelpers.IsApiType(feature, ApiType.KmlPlacemark);
        // etc..
    
        string id = feature.getId(); // the features id
        KmlTreeViewNode node = myKmlTreeView.GetNodeById(id);   // find the corresponding node...    
        if(node == null) { return; } // no corresponding node...
    
        // set the selected node to the feature node.
        myKmlTreeView.SelectedNode = node; 
    
        // make sure the node is visible in the treeview
        if (!node.IsVisible)
        {
            node.EnsureVisible();
        }
    }
