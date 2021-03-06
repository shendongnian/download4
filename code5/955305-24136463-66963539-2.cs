        DataSet ds1 = new DataSet();
        // Adding new 4 column to ds1
        ds1.Tables.Add(new DataTable());
        ds1.Tables[0].Columns.Add("column_1", typeof(string));
        ds1.Tables[0].Columns.Add("column_2", typeof(string));
        ds1.Tables[0].Columns.Add("column_3", typeof(string));
        ds1.Tables[0].Columns.Add("column_4", typeof(string));
        
        DataRow row_1 = ds1.Tables[0].NewRow();
        row_1["column_1"] = "row1cell1";
        row_1["column_2"] = "row1cell2";
        row_1["column_3"] = "row1cell3";
        row_1["column_4"] = "row1cell4";
        ds1.Tables[0].Rows.Add(row_1);
        DataRow row_2 = ds1.Tables[0].NewRow();
        row_2["column_1"] = "row2cell1";
        row_2["column_2"] = "row2cell2";
        row_2["column_3"] = "row2cell3";
        row_2["column_4"] = "row2cell4";
        ds1.Tables[0].Rows.Add(row_2);
        DataRow row_3 = ds1.Tables[0].NewRow();
        row_3["column_1"] = "row3cell1";
        row_3["column_2"] = "row3cell2";
        row_3["column_3"] = "row3cell3";
        row_3["column_4"] = "row3cell4";
        ds1.Tables[0].Rows.Add(row_3);
        GridView1.DataSource = ds1;
        GridView1.DataBind();
        DataSet ds2 = new DataSet();
        ds2.Tables.Add(new DataTable());
        ds2.Tables[0].Columns.Add("column_1", typeof(string));
        ds2.Tables[0].Columns.Add("column_2", typeof(string));
        ds2.Tables[0].Columns.Add("column_3", typeof(string));
        ds2.Tables[0].Columns.Add("column_4", typeof(string));
        DataRow ds2row_1 = ds2.Tables[0].NewRow();
        ds2row_1["column_1"] = ds1.Tables[0].Rows[2]["column_1"].ToString();
        ds2row_1["column_2"] = ds1.Tables[0].Rows[2]["column_2"].ToString();
        ds2row_1["column_3"] = ds1.Tables[0].Rows[2]["column_3"].ToString();
        ds2row_1["column_4"] = ds1.Tables[0].Rows[2]["column_4"].ToString();
        ds2.Tables[0].Rows.Add(ds2row_1);
        GridView2.DataSource = ds2;
        GridView2.DataBind();
