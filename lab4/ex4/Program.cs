using System;

namespace ex4 // 3 числа, если отриц. то ^2 => если >20 то *2
{
	class Program
	{
		static void Main(string[] args)
		{
			int a;
			for (char i = 'a'; i != 'd'; i++) 
			{
				Console.Write(i + "=");
				a = int.Parse(Console.ReadLine());
				if (a < 0) 
				{
					a *= a;
					if (a > 20)
						a *= 2;
				}
				Console.WriteLine(i + "'=" + a);
			}
		}
	}
}
