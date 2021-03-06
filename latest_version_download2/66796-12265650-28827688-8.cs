    static bool TablesEqual(DataTable table1, DataTable table2, params int[] skipColumns)
    {
        if (table1.Rows.Count != table2.Rows.Count)
            return false;
        for (int i = 0; i < table1.Rows.Count; i++)
        {
            var array1 = table1.Rows[i].ItemArray
                .Where((obj, index) => !skipColumns.Contains(index));
            var array2 = table2.Rows[i].ItemArray
                .Where((obj, index) => !skipColumns.Contains(index)); ;
            if (!array1.SequenceEqual(array2))
            {
                return false;
            }
        }
        return true;
    }
