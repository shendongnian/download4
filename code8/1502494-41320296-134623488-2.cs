      #region fileupload
      var FileExtension = Path.GetExtension(FileUpload1.PostedFile.FileName).Substring(1);
      string SaveLocation = Server.MapPath("Invoices\\") + Guid.NewGuid().ToString("N") + FileExtension;
      try
       {
          FileUpload1.PostedFile.SaveAs(SaveLocation);
       }
      catch (Exception ex)
       {
          if (ex is ArgumentNullException || ex is NullReferenceException)
           {
              throw ex;
           }
        }
       string PicAddress = "~/Invoices/" + SaveLocation;
      #endregion
        MySqlConnection connection = new MySqlConnection("server=localhost; userid=   ; password=   ; database=admindb; allowuservariables=True");
        MySqlCommand cmd = new MySqlCommand();
        cmd.CommandText = "insert into invoicesfp (PicAddress), VALUES (@PicAddress)";
        cmd.CommandType = CommandType.Text;
        cmd.Connection = connection;
        cmd.Parameters.AddWithValue("PicAddress", Server.MapPath("~/Invoices"));
        cmd.Connection.Open();
        cmd.BeginExecuteNonQuery();
        cmd.Connection.Close();
