// Дата: 07.11.2018 Время: 22:00
using System;

namespace ex7 // +8 Квадратные уравнения
{
	class Program
	{
		public static void Main(string[] args)
		{
			double a, b, c;
            Console.Write("a=");
            a = double.Parse(Console.ReadLine());
            Console.Write("b=");
            b = double.Parse(Console.ReadLine());
            Console.Write("c=");
            c = double.Parse(Console.ReadLine());
			if (a==0)
				if (b==0)
					if (c==0)
						Console.WriteLine("Любое число является корнем");
					else
						Console.WriteLine("Нет корней");
				else
				{
				Console.WriteLine("Линейное уравнение");
				Console.WriteLine("x="+-c/b);
				}
			else
			{
				double D=b*b-4*a*c;
				if (D<0)
					Console.WriteLine("Нет корней");
				else
					if (D>0)
						Console.WriteLine("x1={0} x2={1}",(-b+D)/2/a,(-b-D)/2/a);
					else
						Console.WriteLine("x="+-b/2/a);
			}
			Console.ReadKey(true);
		}
	}
}