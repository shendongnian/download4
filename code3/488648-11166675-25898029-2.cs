    foreach (Control x in this.Controls)
    {
        if (x is TextBox)
        {
            if (((TextBox)x).SelectionLength > 0)
            {
                ((TextBox)(x).Cut(); // Or some other method to get the text.
            }
        }
    }
