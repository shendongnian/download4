    public static class Program
    {
         private static Game game;
    
         public static void Main()
         {
             game = CreateNewGame();
             do
             {
                // get input
                // update game state
             } while (!game.IsOver);
         }
    
         private static Game CreateNewGame()
         {
            Horse horse;
            do
            {
               horse = CreateRandomHorse();
               Console.WriteLine("Is this ok? : " + horse); // Calls horse.ToString()
            } while (!GetBoolInput());
            // have a horse, can make a game
            return new Game(horse, 100);
         }
    }
