    public void LoadTemplate()
    {
         var parameters = m_Provider.Provide(GetTemplate);
         configForm.txtDSN1.Text = parameters.DSN;
         configForm.comboServer.Text = parameters.Server;
         configForm.comboDatabase.Text = parameters.Database;
    }
