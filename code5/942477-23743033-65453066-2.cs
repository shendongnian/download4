    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Add this to your form initialization
            this.listBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem);
        }
        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            //if the item state is selected them change the back color 
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e = new DrawItemEventArgs(e.Graphics,
                                          e.Font,
                                          e.Bounds,
                                          e.Index,
                                          e.State ^ DrawItemState.Selected,
                                          e.ForeColor,
                                          Color.Transparent);//Choose the color
            // Draw the background of the ListBox control for each item.
            e.DrawBackground();
            // Draw the current item text
            e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }
    }
