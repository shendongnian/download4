    private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.Handled = true;
            DataGridViewCell cell = dataGridView1.Rows[0].Cells[0];
            dataGridView1.CurrentCell = cell;
            dataGridView1.BeginEdit(true);               
        }
    }
