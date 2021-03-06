    public static class Program
    {
        static async Task Main(string[] args)
        {
            Task longTask = Task.Run(async () =>
            {
                while (true)
                {
                    long count = 0;
                    Console.WriteLine("doing hard work.");
                    while (count < 99999999)
                    {
                        count++;
                    }
                    Console.WriteLine("wait for a moment");
                    await Task.Delay(1000);
                    Console.WriteLine("I have waited enough");
                }
            });
            while (true)
            {
                Console.WriteLine($"status: {longTask.IsCompleted}");
                await Task.Delay(100);
            }
        }
    }
