// Дата: 18.10.2018 Время: 22:57
using System;

namespace sumofdigit
{
	class Program
	{
		public static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine()),
			r = 0;
			while (n > 0) {
				r += n % 10;
				n /= 10;
			}
			Console.WriteLine(r);
			Console.ReadKey(true);
		}
	}
}
