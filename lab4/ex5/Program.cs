// Дата: 03.11.2018 Время: 18:35
using System;

namespace ex5
{
	class Program
	{
		public static void Main(string[] args)
		{
			int x=int.Parse(Console.ReadLine());
            if (x>0)
                x=1;
            else
                x= x==0 ? 0 : -1;
            Console.WriteLine(x);
		}
	}
}