    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            foreach (var control in Controls.OfType<Label>())
            {
                control.MouseEnter += label_MouseEnter;
                control.MouseLeave += label_MouseLeave;
            }
        }        
        private void label_MouseEnter(object sender, EventArgs e)
        {
            ((Label) sender).Tag = ((Label) sender).BackColor;
            ((Label) sender).BackColor = Color.Red;
        }
        private void label_MouseLeave(object sender, EventArgs e)
        {
            ((Label) sender).BackColor = (Color)((Label) sender).Tag;
            ((Label) sender).Tag = null;
        }
    }
