        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                dataGridView1.EndEdit();
                if (dataGridView1 != null &&
                    dataGridView1.SelectedCells != null &&
                    dataGridView1.CurrentCell != null)
                {
                    if (!(dataGridView1.RowCount == 10 && AllRowCellsEntered(dataGridView1, 9)))
                    {
                        bool allEntered = true;
                        int col = dataGridView1.CurrentCell.ColumnIndex;
                        int row = dataGridView1.CurrentCell.RowIndex;
                        dataGridView1.EndEdit();
                        //check if all values in the current row are entered
                        allEntered = AllRowCellsEntered(dataGridView1, row);
                        if (allEntered)
                        {
                            if (row == dataGridView1.Rows.Count - 1)
                            {
                                dataGridView1.Rows.Add(1);
                                dataGridView1.Rows[row].Cells[0].Value = row + 1;
                                dataGridView1.Rows[row + 1].Cells[0].Value = row + 2;
                                dataGridView1.Rows[row].ReadOnly = true;
                                dataGridView1[0, row + 1].ReadOnly = true;
                                dataGridView1.CurrentCell = dataGridView1.Rows[row + 1].Cells[1];
                                return true;
                            }
                            else 
                            {
                                dataGridView1.CurrentCell = dataGridView1[1, dataGridView1.Rows.Count - 1];
                                return base.ProcessCmdKey(ref msg, keyData);
                            }                                          
                           
                        }
                        else if (col == dataGridView1.Columns.Count - 1)
                        {
                            MessageBox.Show("you are in the last cell and not all values are entered,\n enter all values please!");
                        }
                        else
                        {
                            dataGridView1.CurrentCell = dataGridView1[col + 1, row];
                        }
                    }
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);            
        }
        private bool AllRowCellsEntered(DataGridView dataGridView, int row)
        {
            bool allEntered = true;
            for (int i = 1; i < dataGridView.Columns.Count; i++)
            {
                if (dataGridView.Rows[row].Cells[i].Value != null)
                {
                    int result;
                    if (!(int.TryParse(dataGridView.Rows[row].Cells[i].Value.ToString(), out result)))
                    {
                        allEntered = false;
                       // dataGridView.Rows[row].Cells[i].Value = "";
                        break;
                    }
                }
                else
                {
                    allEntered = false;
                    break;
                }
            }
            return allEntered;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
            dataGridView1[0, 0].Value = 1;
            dataGridView1[0, 0].ReadOnly = true;
            dataGridView1.CurrentCell = dataGridView1[1, 0];
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if ((dataGridView1.CurrentCell != null))
            {
                if ((dataGridView1.CurrentCell.Value != null))
                {
                    string _cellValue = dataGridView1.CurrentCell.Value.ToString();
                    int _parsedCellValue = 0;
                    {
                        if (!(Int32.TryParse(_cellValue, out _parsedCellValue)))
                        {
                            dataGridView1.CurrentCell.Value = null;
                        }
                    }
                }
            }
            if (dataGridView1.Rows.Count == 10)
            {
                if (AllRowCellsEntered(dataGridView1, dataGridView1.Rows.Count - 1))
                {
                    dataGridView1.ReadOnly = true;
                    MessageBox.Show("done!");
                    // all data entered to datagridview do what do you want!
                }
            }
        }
