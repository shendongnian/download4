	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		private void button1_Click(object sender, EventArgs e)
		{
			ModDataGridView dgv2 = new ModDataGridView();
			pnl.Controls.Add(dgv2); //pnl is a Panel type
			foreach (Control item in pnl.Controls)
			{
				txt.AppendText(item.GetType().ToString());
			}
		}
	}
