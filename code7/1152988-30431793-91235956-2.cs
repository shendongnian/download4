    bool IsAllGreen = true;
    foreach (GroupBox groupBox in this.Controls.OfType<GroupBox>()) //get all GroupBoxes
    {
    	foreach (TextBox textBox in groupBox.Controls.OfType<TextBox>()) //Get all Textboxes for every GroupBox
    	{
    		if (textBox.BackColor != Color.Green)   //if any textbox is not Green, it will not go further
    		{
    			IsAllGreen = false;
    			break;
    		}
    	}
    }
    if (IsAllGreen)
    {
    	SchemaForm ff = new SchemaForm();
        ff.Show();
        this.Hide();
    }
