    list.GroupBy(i => new {i.Agent_ID, i.Name}).Select(g => new 
    { 
    Agent_ID= g.Key.Agent_ID, 
    Name = g.Key.Name, 
    Calls = g.Sum(i => i.Calls)
    });
