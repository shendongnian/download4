     if (MessageBox.Show("This will close down the whole application. Confirm?", "Close Application", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
            MessageBox.Show("The application has been closed successfully.", "Application Closed!", MessageBoxButtons.OK);
        }
        else
        {
            e.Cancel = true;
        }   
