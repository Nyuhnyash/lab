using System;

namespace ex2 // max из 3-х
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, c,max;
            Console.Write("1-е число: ");
            a = int.Parse(Console.ReadLine());
            Console.Write("2-е  число: ");
            b = int.Parse(Console.ReadLine());
            Console.Write("3-е  число: ");
            c = int.Parse(Console.ReadLine());
            max = a;
            if (b > max)
                max = b;
            if (c > max)
                max = c;
            Console.WriteLine("Наибольшее число: "+max);
        }
    }
}
