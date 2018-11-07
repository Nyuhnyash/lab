using System;

namespace ex9 // упорядочены ли a,b,c по возрастанию?
{
	class Program
	{
		public static void Main(string[] args)
		{
			int a,b,c;
			Console.Write("a=");
			a = int.Parse(Console.ReadLine());
			Console.Write("b=");
			b = int.Parse(Console.ReadLine());
			Console.Write("c=");
			c = int.Parse(Console.ReadLine());
			if ((a <= b) && (b <= c))
				Console.WriteLine("Упорядочены");
			else
				Console.WriteLine("Не упорядочены");	
		}	
	}
}