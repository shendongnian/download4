    interface IExplorable
    {
        string Object_string { get; set; }
    }
    class Folder : IExplorable
    {
        public string Object_string { get; set; }
    }
    class Document : IExplorable
    {
        public string Object_string { get; set; }
    }
    public void HandleModelObject(IExplorable modelObject)
    {
        TreeNode NewNode = new TreeNode(modelObject.Object_string);  //No if or cast required at all
    }
