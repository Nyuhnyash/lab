// Дата: 04.11.2018 Время: 20:13
using System;

namespace ex10 // треугольники
{
	class Program
	{
		public static void Main(string[] args)
		{
			int a, b, c;
			Console.Write("a=");
			a = int.Parse(Console.ReadLine());
			Console.Write("b=");
			b = int.Parse(Console.ReadLine());
			Console.Write("c=");
			c = int.Parse(Console.ReadLine());
			Console.Write("Треугольник ");
			if ((a + b <= c) || (a + c <= b) || (c + b <= a))
				Console.WriteLine("не существует");
			else
			{
				string[] s = new string[4];
				if ((a == b) || (a == c) || c == b)
				{
					s[2] = "не";
					if ((a != b) || (a != c))
						s[0] = "не";
				}
				else
				{
					s[0] = "не";
					s[1] = "не";
				}
				if ((a*a!=b*b+c*c)&&(b*b!=a*a+c*c)&&(c*c!=b*b+a*a))
					s[3] = "не";
				Console.WriteLine("{0}равносторонний, {1}равнобедренный, {2}разносторонний и {3}прямоугольный.", s[0], s[1], s[2], s[3]);
			}
			Console.ReadKey(true);
		}
	}
}