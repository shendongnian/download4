    var list = list1.AsQueryable();
    foreach (string str in SearchItems)
    {
         list = list.Where(p => p.Name.ToLower().Contains(str.ToLower()));
    }
    listBox1.ItemsSource = list.ToList();
