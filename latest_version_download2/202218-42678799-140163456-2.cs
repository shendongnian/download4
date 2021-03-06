	using System;
	namespace TestCode
	{
		public abstract class Shape
		{
			public abstract void PrintArea();
		}
		public class Circle : Shape
		{
			public override void PrintArea()
			{
				Console.WriteLine("πr2");
			}
		}
		public class Square : Shape
		{
			public override void PrintArea()
			{
				Console.WriteLine("l*w");
			}
		}
		public class Program
		{
			public static void Main()
			{
				Console.WriteLine("Start");
				var lst = new System.Collections.Generic.List<Shape>();
				lst.Add(new Circle());
				lst.Add(new Square());
				
				
				ShowFormula(lst);
			}
			
			public static void ShowFormula(System.Collections.Generic.IEnumerable<Shape> shapes){
				foreach (var shape in shapes)
				  shape.PrintArea();
			}
		}
	}
