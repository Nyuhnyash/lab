// Дата: 23.10.2018 Время: 17:00
using System;

namespace stepen
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.Write("Введите число: ");
			int x = int.Parse(Console.ReadLine());
			Console.Write("Введите степень числа: ");
			int y = int.Parse(Console.ReadLine());
			float sum = 1;
			for (int i = 0; i != y && i != -y; i++)
				sum *= x;
			if (y < 0)
				sum = 1 / sum;
			Console.WriteLine(sum);
			Console.ReadKey();
		}
	}
}
