    private static Range GetNonEmptyRangeInColumn(_Application application, _Worksheet worksheet, string columnName)
    {
        // get the intersection of the column and the used range on the sheet (this is a superset of the non-null cells)
        var tempRange = application.Intersect(worksheet.UsedRange, (Range) worksheet.Columns[columnName]);
        // if there is no intersection, there are no values in the column
        if (tempRange == null)
            return null;
        // get complete set of values from the temp range (potentially memory-intensive)
        var value = tempRange.Value2;
        // if value is NULL, it's a single cell with no value
        if (value == null)
            return null;
        // if value is not an array, the temp range was a single cell with a value
        if (!(value is Array))
            return tempRange;
        // otherwise, the temp range is a 2D array which may have leading or trailing empty cells
        var value2 = (object[,]) value;
        // get the first and last rows that contain values
        var rowCount = value2.GetLength(0);
        int firstRowIndex;
        for (firstRowIndex = 1; firstRowIndex <= rowCount; ++firstRowIndex)
        {
            if (value2[firstRowIndex, 1] != null)
                break;
        }
        int lastRowIndex;
        for (lastRowIndex = rowCount; lastRowIndex >= firstRowIndex; --lastRowIndex)
        {
            if (value2[lastRowIndex, 1] != null)
                break;
        }
        // if there are no first and last used row, there is no used range in the column
        if (firstRowIndex > lastRowIndex)
            return null;
        // return the range
        return worksheet.Range[tempRange[firstRowIndex, 1], tempRange[lastRowIndex, 1]];
    }
