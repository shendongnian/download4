    Public delegate void LabelDelegate(string s);
    void Updatelabel(string text)
    {
       if (label.InvokeRequired)
       {
           LabelDelegate LDEL = new LabelDelegate(Updatelabel);
           label.Invoke(LDEL, text);
       }
       else
           label.Text = text
    }
