    public class CustomDataGridView : DataGridView
    {    
        //This contains all the column indices in which the tab will be switched vertically. For your case, the initial index is 1 (the second column): VerticalTabColumnIndices.Add(1);
        public List<int> VerticalTabColumnIndices = new List<int>();    
        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab&&VerticalTabColumnIndices.Contains(CurrentCell.ColumnIndex))
            {
                int i = (CurrentCell.RowIndex + 1) % Rows.Count;
                CurrentCell = Rows[i].Cells[CurrentCell.ColumnIndex];
                return true;//Suppress the default behaviour which switches to the next cell. 
            }
            return base.ProcessDataGridViewKey(e);
        }
    }
    //or simply you can handle the Tab key in a KeyDown event handler
    private void KeyDownHandler(object sender, KeyEventArgs e){
      if(e.KeyCode == Keys.Tab){
         e.Handled = true;
         //remaining code...
         //.....
      }
    }
    //in case you are not familiar with event subscribing
    yourDataGridView.KeyDown += KeyDownHandler;
