    int panel_LOC = -60;
    int i;
    private void button1_Click(object sender, EventArgs e)
    {
        i = i + 1;
        var panel = new Panel();
        panel_LOC += 60;
        panel.Location = new Point(0, panel_LOC);
        panel.Name = "panelName_" + i.ToString();
        panel.Width = 1052;
        panel.Height = 50;
        panel.BackColor = Color.FromArgb(222, 222, 222);
        panelIWantToCreateTheControlsOn.Controls.Add(panel);
    }
