    Data = new DataTable();
    // create "fixed" columns
    Data.Columns.Add("id");
    Data.Columns.Add("image");
    // create custom columns
    Data.Columns.Add("Name1");
    Data.Columns.Add("Name2");
    // add one row as an object array
    Data.Rows.Add(new object[] { 123, "image.png", "Foo", "Bar" });
