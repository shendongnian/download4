	public static bool MaleTour { get; set; }
	public static bool FemaleTour { get; set; }
	public static bool MixTour { get; set; }
	private static int playerSize;
	static void Main(string[] args)
	{
		Menu();
	}
	private static bool Menu()
	{
		{
			Console.WriteLine("You have now entered the 2017 Wimbledon tournament!" + "\n" + "\n");
			Console.Write("Choose one of the 6 options:" + "\n" + "Press 1 for Default tournament:" + "\n" + "Press 2 for Women's single:" + "\n" +
				"Press 3 for Men's single:" + "\n" + "Press 4 for Women's double:" + "\n" + "Press 5 for Men's double:" + "\n" +
				"Press 6 for Mix double:" + "\n" + "Insert your choice...:");
			string userValue = Console.ReadLine();
			switch (userValue)
			{
				case "1":
					Console.WriteLine("You have entered a default tournament");
					return true;
				case "2":
					Console.WriteLine("You have entered women's single");
					return true;
				case "3":
					Console.WriteLine("You have entered men's single");
					return true;
				case "4":
					Console.WriteLine("You have entered women's double");
					return true;
				case "5":
					Console.WriteLine("You have entered men's double");
					return true;
				case "6":
					Console.WriteLine("You have entered mix double");
					return true;
				default:
					Console.WriteLine("Sorry! You have to choose one of the 6 tournament options");
					return false;
			}
		}
	}
}
