	interface IControl
	{
		void Paint();
	}
	interface ISurface
	{
		void Paint();
	}
	public class SampleClass : IControl, ISurface
	{
		void IControl.Paint()
		{
			System.Console.WriteLine("IControl.Paint");
		}
		void ISurface.Paint()
		{
			System.Console.WriteLine("ISurface.Paint");
		}
	}
