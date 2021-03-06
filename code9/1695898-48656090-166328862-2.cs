    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }
    
        public static IWebHost BuildWebHost(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
                .UseUnityServiceProvider()   // Add Unity as default Service Provider
                .UseStartup<Startup>()
                .Build();
        }
