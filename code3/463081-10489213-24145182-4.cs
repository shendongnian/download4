    private void cmbjobcode_SelectedValueChanged(object sender, EventArgs e)
       {
           tbltoinvoicedtableTableAdapter tbltoinvce = new tbltoinvoicedtableTableAdapter();
           tbltoinvce.Connection = new OleDbConnection(Program.ConnStr);
           if (cmbjobcode.SelectedValue != null)
           {
               DataRow job = tbltoinvce.GetDataBy(int.Parse(cmbjobcode.SelectedValue.ToString())).Rows[0])
               if (jobList == null)
               {
                   jobList = new BindingList<DataRow>(job);
                   dataGridView1.DataSource = dt;
               }
               else
               {
                   if (!jobList.Contains(job));
                       jobList.Add(job);               
               }
           }
       }
