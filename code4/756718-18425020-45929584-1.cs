     string cmdstr = "INSERT INTO Comments(commentText,datePosted,personName) VALUES (@txtComments, @datePosted, @personName)";
        OleDbConnection con = new OleDbConnection(constr);
        OleDbCommand com = new OleDbCommand(cmdstr, con);
        con.Open();
        com.Parameters.AddWithValue("@txtComments", txtComments.Text);
        com.Parameters.AddWithValue("@datePosted", DateTime.Now.ToString());     
        //com.Parameters.AddWithValue("@datePosted", hidTimeDate.Value.ToString());
        com.Parameters.AddWithValue("@personName", txtName.Text);
        com.ExecuteNonQuery();
        con.Close();
