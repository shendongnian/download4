    private void button3_Click(object sender, EventArgs e)
    {
        string[] Text1 = new[] { this.textBox1.Text };
        string[] Text2 = new[] { this.textBox2.Text };
        string[] Word1 = this.textBox1.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
        string[] Word2 = this.textBox2.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
        //            this.textBox1.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
        string outStr = string.Empty;
        if (Word1.Length > 0)
        {
            for (int i = 0, j = 0; i < Word1.Length; i++)
            {
                if (!string.IsNullOrEmpty(string.Join("", Word1[i])))
                {
                    outStr = outStr + Word1[i];
                }
                else
                {
                    outStr = outStr + Word2[j];
                    j = j + 1;
                }
                outStr = outStr + "\r\n";
            }
            this.textBox3.Text = outStr;
        }
    }
