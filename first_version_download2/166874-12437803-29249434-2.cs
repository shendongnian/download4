            dataGridView1.AllowUserToAddRows = false;
            for (int i = 0; i < 24; i++)
            {
                DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
                btnColumn.HeaderText = string.Format("{0}:00", i+1);
                btnColumn.Name = "dayColumn";
                btnColumn.Width = 40; //set yout width
                dataGridView1.Columns.Add(btnColumn);
            }
            for (int i = 0; i < 7; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    dataGridView1[j, i].Value = string.Format("{0}:00", (j + 1));
                }
            }
