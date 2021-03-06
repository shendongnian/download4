    [HttpPost]
    public async Task<IActionResult> PostCall()
    {
        var tasks = Enumerable
            .Range(0, 10)
            .Select(Manager.SomeMethodAsync)
            .ToList();
        while (tasks.Any())
        {
            var readyTask = await tasks.WhenAny();
            tasks.Remove(ready);
            if (await readyTask)
                return new ObjectResult("At least one task returned true");
        }
        return new ObjectResult("No tasks returned true");
    }
