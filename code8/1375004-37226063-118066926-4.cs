    public partial class DemandePrixFournisseur : Form
    {
    
        private DemandePrixClient info;
    
        public DemandePrixFournisseur(DemandePrixClient information)
        {
            InitializeComponent();
            info = information;
        }
    
       this.textBox1.Text = info.textBox1.Text // you can get other value like this way
    }
