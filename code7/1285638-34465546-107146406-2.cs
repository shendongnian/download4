    using System.Linq;
    private void button3_Click(object sender, EventArgs e)
    {
        string yourRoot = "D:\\";
        treeView1.Nodes.AddRange(getFolderNodes(yourRoot).ToArray());
        // if you want to you can expand all nodes like this, 
        // but this will take some time for larger directory structures
        //foreach (TreeNode tn in treeView1.Nodes) tn.ExpandAll();
        // for much better performance: expand each node before adding it (see below **)
    }
    private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
    {
        TreeNode tn = e.Node.Nodes[0];
        if (tn.Text == "...")
        {
            e.Node.Nodes.AddRange(getFolderNodes(((DirectoryInfo)e.Node.Tag)
                  .FullName).ToArray());
            if (tn.Text == "...") tn.Parent.Nodes.Remove(tn);
        }
    }
    List<TreeNode> getFolderNodes(string dir)
    {
        var dirs = Directory.GetDirectories(dir).ToArray();
        var nodes = new List<TreeNode>();
        foreach (string d in dirs)
        {
            DirectoryInfo di = new DirectoryInfo(d);
            TreeNode tn = new TreeNode(di.Name);
            tn.Tag = di;
            int subCount = 0;
            try { subCount = Directory.GetDirectories(d).Count();  } 
            catch { /* ignore accessdenied */  }
            if (subCount > 0) tn.Nodes.Add("...");
            tn.Expand();           // use onyl if you want to have everything expanded **
            nodes.Add(tn);
        }
        return nodes;
    }
