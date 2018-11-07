using System;

namespace ex1 // 2 числа в порядке возрастания
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("a=");
            int a = int.Parse(Console.ReadLine());
            Console.Write("b=");
            int b = int.Parse(Console.ReadLine());
            if (a < b)
                Console.WriteLine(a + " " + b);
            else
                Console.WriteLine(b + " " + a);
        }
    }
}
