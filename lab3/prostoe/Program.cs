// Дата: 18.10.2018 Время: 15:54
using System;

namespace prostoe
{
	public static class Program
	{
		public static void Main()
		{
			bool p;
			for (int i = 10; i < 1001; i++) {
				p = true;
				for (int j = 2; j < i; j++)
					if ((i % j) == 0) {
						p = false;
						break;
					}
				if (p)
					Console.WriteLine(i);
			}
			Console.ReadKey();
		}
	}
}
