using System;

namespace ex12
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Введите возраст: ");
			byte y = byte.Parse(Console.ReadLine());
			Console.Write("Вам " + y);
			if (y / 10 % 10 == 1)
				y = 0; // Исключение: 2-ой разряд = 1
			switch (y % 10) // 1-ый разряд
			{
				case 1:
					Console.WriteLine(" год"); break;
				case 2:
				case 3:
				case 4:
					Console.WriteLine(" года"); break;
				default:
					Console.WriteLine(" лет"); break;
			}
		}
	}
}