    public partial class SplitTablePanel : TableLayoutPanel
    {
        public int SplitterSize { get; set; }
        int sizingRow = -1;
        int currentRow = -1;
        Point mdown = Point.Empty;
        int oldHeight = -1;
        public SplitTablePanel()
        {
            InitializeComponent();
            this.MouseDown += SplitTablePanel_MouseDown;
            this.MouseMove += SplitTablePanel_MouseMove;
            this.MouseUp += SplitTablePanel_MouseUp;
            this.MouseLeave += SplitTablePanel_MouseLeave;
            SplitterSize = 6;
        }
        void SplitTablePanel_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
        void SplitTablePanel_MouseUp(object sender, MouseEventArgs e)
        {
            getRowRectangles(SplitterSize);
        }
        void SplitTablePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (TlpRows.Count <= 0) getRowRectangles(SplitterSize);
            if (rowHeights.Length <= 0) rowHeights = GetRowHeights();
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (sizingRow < 0) return;
                int newHeight = oldHeight + e.Y - mdown.Y;
                sizeRow(sizingRow, newHeight);
            }
            else
            {
                currentRow = -1;
                for (int i = 0; i < TlpRows.Count; i++)
                    if (TlpRows[i].Contains(e.Location)) { currentRow = i; break;}
                Cursor = currentRow >= 0 ? Cursors.SizeNS : Cursors.Default;
            }
        }
        void SplitTablePanel_MouseDown(object sender, MouseEventArgs e)
        {
            mdown = Point.Empty;
            sizingRow = -1;
            if (currentRow < 0) return;
            sizingRow = currentRow;
            oldHeight = rowHeights[sizingRow];
            mdown = e.Location;
        }
        List<RectangleF> TlpRows = new List<RectangleF>();
        int[] rowHeights = new int[0];
        void getRowRectangles(float size)
        {
            float sz = size / 2f;
            float y = 0f;
            int w = ClientSize.Width;
            int[] rw = GetRowHeights();
            TlpRows.Clear();
            foreach (int r in rw)
            {
                y += r;
                TlpRows.Add(new RectangleF(0, y - sz, w, size));
            }
        }
        void sizeRow(int row, int newHeight)
        {
            if (newHeight == 0) return;
            if (sizingRow < 0) return;
            SuspendLayout();
            rowHeights = GetRowHeights();
            if (sizingRow >= rowHeights.Length) return;
            if (newHeight > 0) 
                RowStyles[sizingRow] = new RowStyle(SizeType.Absolute, newHeight);
            ResumeLayout();
            rowHeights = GetRowHeights();
            getRowRectangles(SplitterSize);
        }
    }
    }
