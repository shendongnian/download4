    using System.Drawing;
    using System.Windows.Forms;
    public class DataGridViewLookupColumn : DataGridViewButtonColumn
    {
        public DataGridViewLookupColumn()
        {
            CellTemplate = new DataGridViewLookupCell();
        }
        public string ButtonText { get; set; }
        public override object Clone()
        {
            var c = (DataGridViewLookupColumn)base.Clone();
            c.ButtonText = this.ButtonText;
            return c;
        }
    }
    public class DataGridViewLookupCell : DataGridViewButtonCell
    {
        protected override void Paint(Graphics graphics, Rectangle clipBounds,
            Rectangle cellBounds, int rowIndex,
            DataGridViewElementStates elementState,
            object value, object formattedValue, string errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            var g = this.DataGridView;
            var c = (DataGridViewLookupColumn)this.OwningColumn;
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState,
                value, formattedValue, errorText, cellStyle, advancedBorderStyle,
                DataGridViewPaintParts.All &
                ~DataGridViewPaintParts.ContentBackground &
                ~DataGridViewPaintParts.ContentForeground);
            var cellRectangle = g.GetCellDisplayRectangle(c.Index, rowIndex, false);
            var buttonRectangle = GetContentBounds(rowIndex);
            var textRectangle = new Rectangle(cellRectangle.Location, 
                new Size(GetButtonWidth(),
                cellRectangle.Height));
            buttonRectangle.Offset(cellRectangle.Location);
            base.Paint(graphics, clipBounds, buttonRectangle, rowIndex, elementState,
                value, c.ButtonText, errorText, cellStyle, advancedBorderStyle,
                DataGridViewPaintParts.All &
                ~DataGridViewPaintParts.Border);
            TextRenderer.DrawText(graphics, $"{formattedValue}", cellStyle.Font,
                textRectangle, cellStyle.ForeColor);
        }
        protected override Rectangle GetContentBounds(Graphics graphics,
            DataGridViewCellStyle cellStyle, int rowIndex)
        {
            var w = GetButtonWidth();
            var r = base.GetContentBounds(graphics, cellStyle, rowIndex);
            return new Rectangle(r.Right - w, r.Top, w, r.Height);
        }
        private int GetButtonWidth()
        {
            var c = (DataGridViewLookupColumn)this.OwningColumn;
            var text = c.ButtonText;
            return TextRenderer.MeasureText(text, c.DefaultCellStyle.Font).Width
                + 6 /*a bit padding */;
        }
    }
