     DateTime UTCTime = System.DateTime.UtcNow;
        DateTime IndianTime = UTCTime.AddHours(5.5).Date;
        partial class Default3 : System.Web.UI.Page
        {
            private void Default3_Load(object sender, EventArgs e)
            {
                UTCTime = System.DateTime.UtcNow;
                DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0);
                IndianTime = epoch.AddDays(Math.Floor(IndianTime.Subtract(epoch).TotalDays));
                 myTime.Text = IndianTime.ToShortDateString();
            }
            public Default3()
            {
                Load += Default3_Load;
            }
        }
