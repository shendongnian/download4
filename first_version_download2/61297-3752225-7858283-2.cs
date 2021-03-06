    private void generate_Click(object sender, EventArgs e) 
    { 
        String dateString = yyyy.Text + dd.Text + MM.Text + hh.Text + M.Text + ss.Text; 
        DateTime parsedDate;
        if (!DateTime.TryParseExact(dateString, "yyyyddMMhhmmss", null, 
                                           DateTimeStyles.None, out parsedDate))
        	return;                                   
        long ticks = timestamp.Ticks; 
        long microseconds = ticks / 10; 
        convertedText.Text = microseconds.ToString("X"); 
    }
