csharp
public class Program
{
    public static void Main()
    {
        int rep = int.Parse(Console.ReadLine());
        int big = 0;
        for(int i = 0; i < rep; i++)
        {
            int hi = int.Parse(Console.ReadLine());
            if(hi > big)
            {
                big = hi;
            }
        }
        Console.WriteLine(big);
    }
}
Assuming your inputs are natural numbers. Otherwise, you might want to replace
csharp
int big = 0;
with
csharp
int big = int.MinValue;
