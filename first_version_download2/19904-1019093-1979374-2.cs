    public partial class Form1 : Form
    {
        private ToolTip toolTip = new ToolTip();
    
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case (int)0x00A0: // WM_NCMOUSEMOVE
                    if (m.WParam == new IntPtr(0x0002)) // HT_CAPTION
                    {
                        toolTip.Show(this.Text, this, this.PointToClient(Cursor.Position));
                    }
                    break;
                case (int)0x02A2: // WM_NCMOUSELEAVE
                    toolTip.Hide(this);
                    break;
            }
            base.WndProc(ref m);
        }
    
        public Form1()
        {
            InitializeComponent();
            Form child = new Form();
            child.Text = "Program1 - Filename:[Really_long_filename_that_doesnt_fit.file] adsfaefwp oupawefpoawef jpoawej fpoawje fpowaej fpojaewpfjwaepfjawejfpwef";
            child.MdiParent = this;
            child.Show();
        }
    }
