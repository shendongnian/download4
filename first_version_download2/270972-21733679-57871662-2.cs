    for (int i = 0; i < list.Count; i++)
    {
        //Get count of current element to before:
        int count = list.Skip(0)
                        .Take(i+1)
                        .Count(r => r.UserName == list[i].UserName);
        list[i].Count = count;
    }
