// Дата: 23.10.2018 Время: 17:35
using System;

namespace factorial
{
	class Program
	{
		public static void Main(string[] args)
		{
			int x = int.Parse(Console.ReadLine()),
			Sum = 1;
			for (int i = x; i > 1; i--) {
				Sum *= x;
				x--;
			}
			Console.WriteLine(Sum);
			Console.ReadKey();
		}
	}
}
