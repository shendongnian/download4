                // button_Click event
               private void button11_Click(object sender, EventArgs e)
               {
                    // creating Excel Application
                    string fileName = String.Empty;
                    Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                    // creating new WorkBook within Excel application
                    Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                    // creating new Excelsheet in workbook
                    Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                    // see the excel sheet behind the program
                    app.Visible = true;
                    // get the reference of first sheet. By default its name is Sheet1.
                    // store its reference to worksheet
                    try
                    {
                         //Fixed:(Microsoft.Office.Interop.Excel.Worksheet)
                         worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];
                         worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.ActiveSheet;
                         // changing the name of active sheet
                         worksheet.Name = "Exported from AMIT";
                         // storing header part in Excel
                         for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                         {
                              worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                         }
                         // storing Each row and column value to excel sheet
                         for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                         {
                              for (int j = 0; j < dataGridView1.Columns.Count; j++)
                              {
                                   worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                              }
                         }
                         // Save The Application
                         SaveFileDialog saveFileExcel = new SaveFileDialog();
                         saveFileExcel.Filter = "Excel files |*.xls|All files (*.*)|*.*";
                         saveFileExcel.FilterIndex = 2;
                         saveFileExcel.RestoreDirectory = true;
                         if (saveFileExcel.ShowDialog() == DialogResult.OK)
                         {
                              fileName = saveFileExcel.FileName;
                              //Fixed-old code :11 para->add 1:Type.Missing
                              workbook.SaveAs(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                         }
                         else
                         {
                               return;
                               // Exit from the application
                               //app.Quit();
                         }
                   }
                   catch (Exception)
                   {
                         //Statement;
                   }
                   finally
                   {
                         app.Quit();
                         workbook = null;
                         app = null;
                   }
              }
