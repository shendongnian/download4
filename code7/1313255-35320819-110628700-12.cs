	public partial class Form3 : Form
	{
		public string Prozz { get; set; }
		public string Kolii { get; set; }
		public string Cenaa { get; set; }
		public string Proff { get; set; }
		public Form3()
		{
			InitializeComponent();
		}
		public void GetData(string Proi, string Kol, string Cena, string Profit)
		{
			textBox1.Text = Kol;
			textBox2.Text = Cena;
			textBox3.Text = Profit;
			textBox6.Text = Proi;
		}
		public void SetData(string Proz, string Kol, string NabCena, string Prof)
		{
			int x = int.Parse(Kol);
			double y = double.Parse(NabCena);
			double z = double.Parse(Prof);
			int a = int.Parse(textBox4.Text);
			double b = double.Parse(textBox5.Text);
			int Kolicna = x + a;
			double subNabavnaCena = (x * y + a * b) / (x + a);
			double Profit = z - Kolicna * subNabavnaCena;
			Prozz = Proz.ToString();
			Kolii = Kolicna.ToString();
			Cenaa = subNabavnaCena.ToString();
			Proff = Profit.ToString();
		}
	}
