    public class IsLetterSample {
	public static void Main() {
		char ch = '8';
		Console.WriteLine(Char.IsLetter(ch));					// False
		Console.WriteLine(Char.IsLetter("sample string", 7));	// True
	}
