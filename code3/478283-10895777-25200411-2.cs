    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.SuspendLayout();
            List<Bitmap> Smiles = new List<Bitmap>(); //Add images
            ToolStripSplitButton _toolStripSplitButton = new ToolStripSplitButton();
            _toolStripSplitButton.Size = new Size(23, 23);
            //_toolStripSplitButton.Image = myImage; //Add the image of the stripSplitButton
            ToolStrip _toolStrip = new ToolStrip();
            _toolStrip.Size = new Size(ClientSize.Width, 10);
            _toolStrip.Location = new Point(0, this.ClientSize.Height - _toolStrip.Height);
            _toolStrip.BackColor = Color.LightGray;
            _toolStrip.Dock = DockStyle.Bottom;
            _toolStrip.Items.AddRange(new ToolStripItem[] { _toolStripSplitButton });
            SmileBox smilebox = new SmileBox(new Point(_toolStripSplitButton.Bounds.Location.X, _toolStrip.Location.Y - 18), 6);
            smilebox.Visible = false;
            Controls.Add(smilebox);
            foreach (Bitmap bmp in Smiles)
                smilebox.AddItem(bmp);
            _toolStripSplitButton.Click += new EventHandler(delegate(object sender, EventArgs e)
            {
                smilebox.Visible = true;
            });
            Click += new EventHandler(delegate(object sender, EventArgs e)
            {
                smilebox.Visible = false;
            });
            this.Controls.Add(_toolStrip);
            this.ResumeLayout();
        }
        void Form1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
    class SmileBox : Panel
    {
        public List<Item> Items
        {
            get;
            set;
        }
        Size _ItemSpace = new Size(20, 20);
        Point _ItemLocation;
        int _rowelements = 0;
        public SmileBox(Point Location, int RowElements)
        {
            BackColor = Color.LightGray;
            Height = _ItemSpace.Height;
            Width = _ItemSpace.Width * RowElements;
            this.Location = new Point(Location.X, Location.Y - Height);
            _ItemLocation = new Point(0, 0);
            _rowelements = RowElements;
        }
        int count = 1;
        public void AddItem(Bitmap Image)
        {
            Item item = new Item(_ItemSpace, _ItemLocation, Image);
            if (_ItemLocation.X + _ItemSpace.Width >= Width)
                _ItemLocation = new Point(0, _ItemLocation.Y);
            else
                _ItemLocation = new Point(_ItemLocation.X + _ItemSpace.Width, _ItemLocation.Y);
            if (count == _rowelements)
            {
                _ItemLocation = new Point(_ItemLocation.X, _ItemLocation.Y + _ItemSpace.Height);
                Height += _ItemSpace.Height;
                Location = new Point(Location.X, Location.Y - _ItemSpace.Height);
                count = 0;
            }
            count++;
            Controls.Add(item);
        }
    }
    class Item : PictureBox
    {
        int _BorderSpace = 2;
        public Item(Size Size, Point Location, Bitmap Image)
        {
            this.Size = new Size(Size.Width - 2 * _BorderSpace, Size.Height - 2 * _BorderSpace);
            this.Location = new Point(Location.X + _BorderSpace, Location.Y + _BorderSpace);
            this.Image = new Bitmap(Image, this.ClientSize);
            Click += new EventHandler(delegate(object sender, EventArgs e)
            {
                //Here what do you want to do when the user click on the smile
            });
            MouseEnter += new EventHandler(delegate(object sender, EventArgs e)
            {
                Focus();
                Invalidate();
            });
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.Focus();
            base.OnMouseDown(e);
        }
        protected override void OnEnter(EventArgs e)
        {
            this.Invalidate();
            base.OnEnter(e);
        }
        protected override void OnLeave(EventArgs e)
        {
            this.Invalidate();
            base.OnLeave(e);
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            if (this.Focused)
            {
                ClientRectangle.Inflate(-1, -1);
                Rectangle rect = ClientRectangle;
                ControlPaint.DrawFocusRectangle(pe.Graphics, rect);
            }
        }
    }
