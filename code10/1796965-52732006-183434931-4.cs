                if (sdr.HasRows == true)
                {
                    StringBuilder sb = new StringBuilder();
  
                    while (sdr.Read())
                    {
                        sb.Append(sdr["sysproID"].ToString().Replace(",", ";"));
                        sb.Append(";");
                        // add other columns
                        sb.AppendLine();
                    }
                }
                //Download the CSV file.
