    public partial class frmEvent : Form
    {
        public DateTime SelectedDate { get; set; }
        public frmEvent()
        {
            InitializeComponent();
        }
    }
    public partial class frmMain : Form
    {
        private void monthCalendar1_SelectedDate(object sender, DateRangeEventArgs e)
        {
            var selectedDate = (DateTime.Parse(e.Start.ToShortDateString())).Day;
            frmEvent frmE = new frmEvent();
            frmEvent.SelectedDate = selectedDate;
            frmE.Show();
        }
    }
