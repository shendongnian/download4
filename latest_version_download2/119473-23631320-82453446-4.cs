    private void button1_Click(object sender, RibbonControlEventArgs e)
    {
        // initialize form
        var frm = new Form();
        frm.FormBorderStyle = FormBorderStyle.FixedSingle;
        frm.MinimizeBox = false;
        frm.MaximizeBox = false;
        frm.Text = "Test Form";
        frm.StartPosition = FormStartPosition.CenterScreen;
        Forms.Add(frm);
        // create the native window handle
        var nw = new Win32Window(Globals.ThisAddIn.Application.Hwnd);
        // show with owner
        frm.Show(nw);
    }
