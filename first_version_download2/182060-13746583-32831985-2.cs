    var list = new LinkedList<SLElement>();
    list.AddAfter(list.AddFirst(new SLElement()), new SLElement());
    list.Remove(list.Select((i, j) => new { i, j })
        .Where(j => j.j == 0)
        .Select(i => i.i)
        .FirstOrDefault());
