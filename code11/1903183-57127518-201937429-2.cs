    public partial class Form1 : Form
    {
        public Monster MonsterInstance { get; set; } = new Monster();
        public Player PlayerInstance { get; set; } = new Player(); 
        public Form1()
        {
            InitializeComponent();
        }
        //Your business logic
        private void AttackBtn_Click(object sender, EventArgs e)
        {
            PlayerInstance.AttackMonster(PlayerInstance, MonsterInstance);
            MonsterHealth.Text = MonsterInstance.HP.ToString();
        }
    }
