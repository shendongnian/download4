    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f=new Form2(UpdateTextBox);
            f.ShowDialog();
        }
    
        private void UpdateTextBox(string newText)
        {
            label1.Text = newText;
        }
    }
