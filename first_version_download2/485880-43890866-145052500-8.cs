    private void dataGridView1_MouseUp(object sender, MouseEventArgs e)
    {
        var hit = dataGridView1.HitTest(e.X,e.Y);
        int dropRow = -1;
        if (hit.Type != DataGridViewHitTestType.None)
        {
            dropRow =   hit.RowIndex;
            if (dragRow >= 0 )
            {
                int tgtRow = dropRow + (dragRow > dropRow ? 1 : 0);
                if (tgtRow != dragRow)
                {
                    DataGridViewRow row = dataGridView2.Rows[dragRow];
                    dataGridView2.Rows.Remove(row);
                    dataGridView2.Rows.Insert(tgtRow, row);
                    dataGridView2.ClearSelection();
                    row.Selected = true;
                }
            }
        }
        else  { dataGridView2.Rows[dragRow].Selected = true;}
        if (dragLabel != null)
        {
            dragLabel.Dispose();
            dragLabel = null;
        }
    }
