    private void timer1_Tick(object sender, EventArgs e)
    {
        seconds++;
        if (seconds > 5)
        {
            timer1.Stop();
            MessageBox.Show("Card NOT removed in time: CONFISCATED");
            login.cardConfiscated(cardNumber);
            login.Visible = true;
            this.Close();
        }
    }
