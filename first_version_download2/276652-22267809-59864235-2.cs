        private void button1_Click(object sender, EventArgs e)
        {
            using (var conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=posv.accdb"))
            {
                conn.Open();
                var Expanse_Name = expanse_name.Text;
                var Expanse_Cost = expanse_cost.Text;
                var Expanse_Date = expanse_date.Value;
                using (var cmd = new OleDbCommand("INSERT INTO expanses (Expanse_Name, Expanse_Cost,Expanse_Date) VALUES (@Expanse_Name, @Expanse_Cost,@Expanse_Date)", conn))
                {
                    cmd.Parameters.Add("@Expanse_Name", OleDbType.VarChar, 20).Value = Expanse_Name;
                    cmd.Parameters.Add("@Expanse_Cost", OleDbType.UnsignedInt, 20).Value = Expanse_Cost;
                    cmd.Parameters.Add("@Expanse_Date", OleDbType.DBTimeStamp, 20).Value = Expanse_Date;
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Expanse Added Success fully!");
                    }
                    catch (OleDbException exps)
                    {
                        MessageBox.Show(exps.Message);
                        conn.Close();
                    }
                }
            }
        }
