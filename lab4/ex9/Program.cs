// Дата: 03.11.2018 Время: 18:49
using System;

namespace ex9
{
	class Program
	{
		public static void Main(string[] args)
		{
			int a = int.Parse(Console.ReadLine()),
				b = int.Parse(Console.ReadLine()),
				c = int.Parse(Console.ReadLine());
			if ((a <= b) && (b <= c))
				Console.WriteLine("Упорядочены");
			else
				Console.WriteLine("Не упорядочены");
		}
	}
}