    for (int i = 0; i <= dataGridView1.Columns.Count - 1; i++)
    {
        if (i > 0)
        {
             swOut.Write(",");
        }
        // Datetime column content transformed in a formatted string....
        if(i == 1)
           value = dr.Cells[i].Value.ToString("yyyy/MM/dd hh:mm:ss");
        else
           ....
