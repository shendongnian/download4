    using (SqlCommand command = new SqlCommand("Insert into Sender(CourierNo,LoginID,SenderName) values (@courierNo, @loginId, @senderName)")
    {
        command.Parameters.Add(new SqlParameter("courierNo", cNo.Text));
        command.Parameters.Add(new SqlParameter("loginId", logID));
        command.Parameters.Add(new SqlParameter("senderName", Name1.Text));
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }
}
`
