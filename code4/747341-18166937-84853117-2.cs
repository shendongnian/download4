    // create nodes:
    TreeNode item = new TreeNode();
    item.Tag = typeof(UserControl1);
    TreeView.Nodes.Add( item );
    
    // field currentControl
    UserControl _currentControl;
    // on selection:
    TreeViewItem item = (TreeViewItem)sender;
    if(_currentControl != null)
    {
       _currentControl.Controls.Remove(_currentControl);
       _currentControl.Dispose();
    }
    // if no type is bound to the node, just leave the panel empty
    if (item.Tag == null)
      return;
    _currentControl = (UserControl)Activator.Create((Type)item.Tag);
    Panel1.Controls.Add(_currentControl);
    
