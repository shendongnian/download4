    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e){
      if(e.Value == null) return;
      e.CellStyle.BackColor = ((DateTime)e.Value).TimeOfDay < DateTime.Now.TimeOfDay ?
                              Color.Gray : Color.Green;
    }
    //To register the event handler for CellPainting, you can use this code
    dataGridView1.CellPainting += dataGridView1_CellPainting;//Place this in your form constructor
