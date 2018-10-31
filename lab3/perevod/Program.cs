// Дата: 19.10.2018 Время: 19:33
using System;

namespace perevod
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.Write("Введите основание системы счисления: ");
			int b = int.Parse(Console.ReadLine()), b2;
			string s;
			if (b == 2) {
				s = "двоичное";
				b2 = 10;
			} else {
				s = "десятичное";
				b2 = 2;
			}
			Console.Write("Введите " + s + " число: ");
			int num = int.Parse(Console.ReadLine()),
			res = 0, x = 1;
			while (num != 0) {
				res += (num % b2 * x);
				num /= b2;
				x *= b;
			}
			Console.WriteLine("Результат: " + res);
			Console.ReadKey(true);
		}
	}
}
