    public class ConsoleAsk : IAsk
    {
        bool Question(string message)
        {
             Console.WriteLine(message);
             return  bool.Parse(Console.ReadLine());
        }
    }
