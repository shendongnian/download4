    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    public class FormStorage
    {
        private System.Web.UI.Page _page = null;
        public Dictionary<String, String> storage
        {
            get { return (Dictionary<String, String>)_page.Session["FormStorage"]; }
            set { _page.Session["FormStorage"] = value; }
        }
        public FormStorage(System.Web.UI.Page page)
        {
            _page = page;
            initHandler();
            if (this.storage == null)
                this.storage = new Dictionary<String, String>();
        }
        private void initHandler()
        {
            _page.Load += Load;
            _page.PreRender += PreRender;
        }
        private void Load(Object sender, EventArgs e)
        {
            loadForm();
        }
        private void PreRender(Object sender, EventArgs e)
        {
            saveForm();
        }
        private void loadForm()
        {
            var e = storage.GetEnumerator();
            while (e.MoveNext())
            {
                loadControl(e.Current.Key, e.Current.Key, e.Current.Value);
            }
        }
        private void loadControl(String ID, String postDataKey, String value)
        {
            Control control = findControlRecursively(_page, ID);
            if (control != null)
            {
                setControlValue(control, value);
            }
        }
        private void setControlValue(Control control, String value)
        {
            if (control is ITextControl)
            {
                ITextControl txt = (ITextControl)control;
                txt.Text = value == null ? "" : value;
            }
            else if (control is ICheckBoxControl)
            {
                ICheckBoxControl chk = (ICheckBoxControl)control;
                chk.Checked = value != null;
            }
            else if (control is ListControl) {
                ListControl ddl = (ListControl)control;
                if (value == null)
                    ddl.SelectedIndex = -1;
                else
                    ddl.SelectedValue = value;
            }
        }
        public void saveForm()
        {
            saveControlRecursively(this._page);
        }
        private void saveControlRecursively(Control rootControl)
        {
            if (rootControl is IPostBackDataHandler)
            {
                var postBackData = _page.Request.Form[rootControl.ID];
                storage[rootControl.ID] = postBackData;
            }
            if (rootControl.HasControls())
                foreach (Control subControl in rootControl.Controls)
                    saveControlRecursively(subControl);
        }
        private static Control findControlRecursively(Control rootControl, String idToFind)
        {
            if (rootControl.ID == idToFind)
                return rootControl;
            foreach (Control subControl in rootControl.Controls)
            {
                Control controlToReturn = findControlRecursively(subControl, idToFind);
                if (controlToReturn != null)
                {
                    return controlToReturn;
                }
            }
            return null;
        }
    }
