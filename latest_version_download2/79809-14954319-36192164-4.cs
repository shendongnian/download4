    using DevExpress.XtraGrid.Views.Grid;
    //...
    gridView1.RowCellClick += gridView_RowCellClick;
    //...
    void gridView_RowCellClick(object sender, RowCellClickEventArgs e) {
        object id = ((GridView)sender).GetRowCellValue(e.RowHandle, "ID");
        testBoxId.Text = id.ToString();
        //...
    }
