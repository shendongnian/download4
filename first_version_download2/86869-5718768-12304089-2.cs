    void radioButton_CheckedChanged(object sender, EventArgs e)
    {
        RadioButton rb = sender as RadioButton;
    
        if (rb == null)
        {
            MessageBox.Show("Sender is not a RadioButton");
            return;
        }
    
        // Ensure that the RadioButton.Checked property
        // changed to true.
        if (rb.Checked)
        {
            // Keep track of the selected RadioButton by saving a reference
            // to it.
            selectedrb = rb;
        }
    }
