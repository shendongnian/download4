    protected void LinkProjectNumber_Click(object sender, EventArgs e)
    {
         string projectid = (sender as LinkButton).Text;
         PopUpMessage(projectid);
    }
