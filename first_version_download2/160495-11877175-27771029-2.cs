    class DateEventArgs : EventArgs
    {
        public DateTime Date {get; private set;}
        public DateEventArgs(DateTime d) 
            : base()
        {
            this.Date = d;
        }
    }
    class FirstForm : Form
    {
        DateTimePicker dtp = new DateTimePicker();
        
        public event EventHandler<DateEventArgs> DateSelected;
        protected virtual void OnDateSelected(DateEventArgs e)
        {
            EventHandler<DateEventArgs> handler = DateSelected;
            if(handler != null) handler(this, e);
        }
       
        public FirstForm()
        {
            this.Controls.Add(dtp);
            dtp.ValueChanged += new EventHandler(dtp_ValueChanged);
        }
        void dtp_ValueChanged(object sender, EventArgs e)
        {
            DateEventArgs dea = new DateEventArgs(dtp.Value.Date);
            OnDateSelected(dea);
        }
    }
    class SecondForm : Form
    {
        DateTimePicker dtp = new DateTimePicker();
        
        public DateTime SelectedDate
        {
            set { dtp.Value = value; }
        }
       
        public SecondForm()
        {
            this.Controls.Add(dtp);
        }
    }
    static class Controller
    {
        static void Go()
        {
            f1 = new FirstForm();
            f2 = new SecondForm();
            f1.DateSelected += (o,e) => f2.SelectedDate = e.Date.AddMonths(6);
            f1.Show();
            f2.Show();
        }
    }
