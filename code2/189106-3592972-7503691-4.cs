    [ParseChildren(true)]
    [PersistChildren(true)]
    [ToolboxData("<{0}:CustomControlUno runat=server></{0}:CustomControlUno>")]
    public class CustomControlUno : WebControl, INamingContainer
    {
        private Control1ChildrenCollection _children;
    
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Control1ChildrenCollection Children
        {
            get
            {
                if (_children == null)
                    _children = new Control1ChildrenCollection();
                return _children;
            }
        }
    }
    
    public class Control1ChildrenCollection : List<Control1Child>
    {
    }
    
    public class Control1Child
    {
        private int integerProperty;
        private string stringProperty;
    
        public string StringProperty
        {
            get { return stringProperty; }
            set { stringProperty = value; }
        }
    
        public int IntegerProperty
        {
            get { return integerProperty; }
            set { integerProperty = value; }
        }
    }
