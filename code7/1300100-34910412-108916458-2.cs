    public static class AsyncTest
    {
        static async Task<int> test()
        {
            Console.WriteLine("{0}: Start 3", DateTime.Now);
            await Task.Delay(3000);
            return 3;
        }
        public static void Main()
        {
            var tasks2 = new List<Task<int>>
            {
                test(),
                new Task<int>( delegate { Console.WriteLine("{0}: Start 3", DateTime.Now); Task.Delay(3000).Wait(); return 3; } ),
                new Task<int>( delegate { Console.WriteLine("{0}: Start 1", DateTime.Now); Task.Delay(1000).Wait(); return 1; } )
            };
            foreach (var task in tasks2)
            {
                if (task.Status == TaskStatus.Created)
                    task.Start(); // this cause exception at runtime
            }
            Task.WhenAll(tasks2).Wait();
            Console.WriteLine("All done!");
        }
    }
