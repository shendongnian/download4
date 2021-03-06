    class Program
    {
        static void Main(string[] args)
        {
            CalculateMeals(new DateTime(2019, 1, 1, 5, 12, 1), new DateTime(2019, 1, 2, 18, 0, 0));
        }
        public static void CalculateMeals(DateTime timeArrived, DateTime timeExit)
        {
            // Number of full days
            int fullDaysNumber = (timeExit - timeArrived).Days;
            DayMeals dayMeals = new DayMeals();
            for (int i = 0; i <= fullDaysNumber; i++)
            {
                if (timeExit.Day > timeArrived.Day)
                {
                    dayMeals.AddFullDay();
                    // A trick to make the cycle work the next time
                    // You can use a different variable if you want to keep timeArrived unchanged
                    timeArrived = timeArrived.AddDays(1);
                }
                else if (timeExit.Day < timeArrived.Day)
                {
                    break;
                }
                else
                {
                    dayMeals.CountMealsForADay(timeArrived, timeExit);
                }
            }
            dayMeals.PrintMealsCount();
        }
    }
