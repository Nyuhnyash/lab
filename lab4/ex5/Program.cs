using System;

namespace ex5 // sign(x)
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.Write("x=");
			int x = int.Parse(Console.ReadLine());
			if (x > 0)
				x = 1;
			else
				x = x == 0 ? 0 : -1;
			Console.WriteLine("sign(x)="+x);
		}
	}
}