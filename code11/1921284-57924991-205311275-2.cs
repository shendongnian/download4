    private void richTextBox_KeyDown(object sender, KeyEventArgs e)
     {
                // Handle special keys (Alt)
                if (e.Alt)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.K:
                            richTextBox.AppendText("Alt+K pressed");
                    e.SuppressKeyPress = true;
                            break;
                        default:
                            // Don't need to handle this
                            break;
                    }
                }
                // Ctrl + key
                else if (e.Control)
                {
    
    
                }
                else
                { 
            switch (e.KeyCode)
            {
                case Keys.OemSemicolon:
                    richTextBox.AppendText("Ū");
                    e.SuppressKeyPress = true;
                    break;
                case Keys.OemBackslash:
                    richTextBox.AppendText("X̄");
                    e.SuppressKeyPress = true;
                    break;
                case Keys.G:
                    richTextBox.AppendText("Ʒ");
                    e.SuppressKeyPress = true;
                    break;
                default:
                    // Nothing special here
                    break;
            }
        }
    }
