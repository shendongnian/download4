    class Program
    {
        static void Main(string[] args)
        {
            var scheduler = MySchedule.GetValue();
            Console.WriteLine("Scheduler started. Press [Enter] to quit.");
            Console.ReadLine();
        }
    }
    
    public static class MySchedule
    {
        public static IScheduler GetValue()
        {
            var scheduler = StdSchedulerFactory.GetDefaultScheduler();
    
            scheduler.Start();
    
            var job = JobBuilder.Create<MyJob>().Build();
    
            var trigger = TriggerBuilder.Create().WithDailyTimeIntervalSchedule(builder =>
    
            builder.WithIntervalInSeconds(1)
            .OnEveryDay()
            .StartingDailyAt(TimeOfDay.HourMinuteAndSecondOfDay(9, 40, 0))).Build();
    
            scheduler.ScheduleJob(job, trigger);
            return scheduler;
        }
    }
    public class MyJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine(DateTime.Now.ToString(new CultureInfo("en")));
        }
    }
