    partial class Default3 : System.Web.UI.Page
    {
        UTCTime = System.DateTime.UtcNow;
        IndianTime = UTCTime.AddHours(5.5).Date;
        private void Default3_Load(object sender, EventArgs e)
        {
            myTime.Text = IndianTime.ToShortDateString();
        }
        public Default3()
        {
            Load += Default3_Load;
        }
    }
