    resources.AddRange(collListItem
        .Where(item => item["Title"].ToString() == "test")
        .Select(item =>
            new Customer {
                ResourceName = item["Resource_x0020_Name"].ToString(),
                Quantity = int.Parse((item["Quantity_x0020_Ordered"] ?? 0).ToString())
            }
         )
     );
