    var tasks = new List<Task<List<House>>>();
    for (int i = 0; i < pageCount; i++)
    {
        var currentPageCopy = currentPage; 
        var task = Task.Run(() =>
        {
            return worker.GetHouses(currentPageCopy);
        });
        tasks.Add(task);
        currentPage++;
    }
    Task.WaitAll(tasks.ToArray());
