    List<object> list = new List<object>();
    
    for (int i = 0; i < 10; i++)
    {
        list.Add(new { Number = i, Name = string.Concat("name",i) });
    }
