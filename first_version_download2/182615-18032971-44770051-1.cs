      for (i = 0; i <= GvSchedule.Rows.Count - 1; i++)
            {
                if (((CheckBox)GvSchedule.Rows[i].FindControl("ChkIsService")).Checked)
                {
                    string catName = ((Label)GvSchedule.Rows[i].FindControl("lblCatName")).Text;
                    var subCatName = ((Label)GvSchedule.Rows[i].FindControl("lblSubCatName")).Text;
                }
            }
