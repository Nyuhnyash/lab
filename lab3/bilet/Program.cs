/* Дата: 18.10.2018 Время: 22:48 */
using System;

namespace bilet
{
	class Program
	{
		public static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine()),
                r=0;
            for(int i=0;i<3;i++)
            {
                r += n%10;
                n /= 10;
            }
            for(int i=0;i<3;i++)
            {
                r -= n%10;
                n /= 10;
            }
            if (r == 0)
                Console.WriteLine("Да");
            else
                Console.WriteLine("Нет");
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}
