    using (OleDbConnection con = new OleDbConnection(Excel07ConString)) {
      using (OleDbCommand cmd = new OleDbCommand()) {
        using (OleDbDataAdapter oda = new OleDbDataAdapter()) {
          cmd.Connection = con;
          con.Open();
          DataTable dtExcelSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
          sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
          DataTable dt = new DataTable(); // <-- may want to move this definition outside, otherwise it will go out of scope as soon as it exits this using statement.
          cmd.Connection = con;
          cmd.CommandText = "SELECT * FROM [" + sheetName + "]";
          //con.Open();
          oda.SelectCommand = cmd;
          oda.Fill(dt);
          con.Close();
          //Populate DataGridView.
          WorkLoadDisp.DataSource = dt;
          label1.Text = dt.Rows.Count.ToString();
        }
      }
    }
