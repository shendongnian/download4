    public static IEnumerable<Control>
        FindControlByAttribute(this Control control, string key, string value)
    {
        var current = control as System.Web.UI.HtmlControls.HtmlControl;
        if (current != null)
        {
            var k = current.Attributes[key];
            if (k != null && k == value)
                yield return current;
        }
        if (control.HasControls())
        {
            foreach (Control c in control.Controls)
            {
                foreach (Control item in c.FindControlByAttribute(key, value))
                {
                    yield return item;
                }
            }
        }
    }
