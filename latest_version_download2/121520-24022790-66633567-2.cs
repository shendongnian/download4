    toolStripContainer1.ContentPanel.Paint += ContentPanel_Paint;//Triggering up the paint event
    public void ContentPanel_Paint(object sender, PaintEventArgs e)
    {
        ToolStripContentPanel panel = (ToolStripContentPanel)sender;
        using (var brush = new LinearGradientBrush(panel.ClientRectangle, Color.Gray, Color.Red, 90))
        {
            e.Graphics.FillRectangle(brush, panel.ClientRectangle);
        }
    }
