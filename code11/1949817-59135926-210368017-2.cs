    DataTable table1 = new DataTable("Table 1");
    table1.Columns.Add("Name", typeof(string));
    table1.Columns.Add("Number A", typeof(int));
    table1.Columns.Add("Comment", typeof(string));
    table1.Columns.Add("ID", typeof(int));
    table1.Rows.Add("John", 25800, "text", 12);
    DataTable table2 = new DataTable("Table 1");
    table2.Columns.Add("Name", typeof(string));
    table2.Columns.Add("Number B", typeof(int));
    table2.Columns.Add("Age", typeof(int));
    table2.Columns.Add("City", typeof(string));
    table2.Rows.Add("Rose", 92610, 24, "London");
    table1.Merge(table2);
