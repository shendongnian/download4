    private void Savebtn_Click(object sender, EventArgs e)
    {
        int A, B, C;
        A = int.Parse(textBox1.Text);
        B = int.Parse(textBox2.Text);
        C = int.Parse(textBox3.Text);
        int mw = Class1.MWCompute(A, B, C);
        if (something)
        {
            textbox4.text = MW.ToString();
        }
    }
