                int i = 1;
                int j = 1;
                //header row
                foreach (DataColumn col in dtMainSQLData.Columns)
                {
                    ExcelApp.Cells[i, j] = col.ColumnName;
                    j++;
                    ExcelApp.Rows.AutoFit();
                    ExcelApp.Columns.AutoFit();
                }
                i++;
                Console.Write("Progressing......65%  \n  Wait for around 8 minutes \r");
                //data rows
                foreach (DataRow row in dtMainSQLData.Rows)
                {
                    for (int k = 1; k < dtMainSQLData.Columns.Count + 1; k++)
                    {
                        ExcelApp.Cells[i, k] = "'" + row[k - 1].ToString();
                    }
                    i++;
                    ExcelApp.Columns.AutoFit();
                    ExcelApp.Rows.AutoFit();
                }
