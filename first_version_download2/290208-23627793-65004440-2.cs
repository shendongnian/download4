    [WebMethod]
    [ScriptMethod]
    public static string MyMethod()
    {
        try
        {
            MySqlConnection con = new MySqlConnection(Globals.CONNECTION_STRING);
            con.Open();
            String UserId = Session["user_id"].ToString();
            int Pro_id = Convert.ToInt32(drop_p.SelectedValue);
            int Sta_id = Convert.ToInt32(drop_s.SelectedValue);
            int Ity_id = Convert.ToInt32(drop_i.SelectedValue);
            MySqlCommand cmd = new MySqlCommand("INSERT INTO issue (user_id, project_id, status_id, itype_id) values ('" + UserId + "','" + Pro_id + "','" + Sta_id + "','" + Ity_id + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception err)
        {
            return "error";
        }
        return "success";
    }
