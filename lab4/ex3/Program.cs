// Дата: 04.11.2018 Время: 21:53
using System;

namespace ex3
{
	class Program
	{
		static void Main(string[] args)
		{
			if (int.Parse(Console.ReadLine()) % 2 != 0)
				Console.Write("не");
			Console.WriteLine("чётное");
		}
		
	}
}