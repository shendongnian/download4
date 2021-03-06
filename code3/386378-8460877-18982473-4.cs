     bool inAction = false;
     
     private void resultSheet_SelectedIndexChanged(object sender, EventArgs e)
     {
         if (inAction || (resultSheet.SelectedItems.Count == 0))
         {
             return;
         }
         inAction = true;
         string name = resultSheet.SelectedItems[0].Name;
         foreach (ListViewItem item in resultSheet.Items.OfType<ListViewItem>().Where(item => item.Name == name))
         {
             item.Selected = true;
         }
         inAction = false;
     } 
