private void listViewExtended1_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
{
      if (e.ColumnIndex == 0)
      {
           e.Cancel = true;
           e.NewWidth = listViewExtended1.Columns[e.ColumnIndex].Width;
      }
}
