            var t1 = ExecuteActionAsync();
            Console.WriteLine($"Returned task: {t1.IsCompleted}");
            await t1;
            Console.WriteLine($"Awaited task: {t1.IsCompleted}\n");
            var t2 = MyMethod();
            Console.WriteLine($"Returned task: {t2.IsCompleted}");
            await t2;
            Console.WriteLine($"Awaited task: {t2.IsCompleted}\n");
            t1 = ExecuteActionAsync();
            t2 = MyMethod();
            var t3 = Task.WhenAll(new []{t1,t2 });
            Console.WriteLine($"Task from WhenAll: {t3.IsCompleted}");
