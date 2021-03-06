        public static WinCell FindCellByColumnAndValue(this WinTable table, int colIndex, string strCellValue, bool searchHeader = false)
        {
            Playback.PlaybackSettings.SmartMatchOptions = Microsoft.VisualStudio.TestTools.UITest.Extension.SmartMatchOptions.None;
    
            WinCell cell = new WinCell(table);
            cell.SearchProperties.Add(WinCell.PropertyNames.ColumnIndex, colIndex.ToString());
            cell.SearchProperties.Add(WinCell.PropertyNames.Value, strCellValue);
            if (cell.Exists == false)
                cell = null;
            return new WinCell();
        }
