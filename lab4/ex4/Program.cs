using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex4
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            for (int i = 1; i <= 3; i++)
            {
                Console.Write(i + " число: ");
                a = int.Parse(Console.ReadLine());
                if (a < 0)
                    a *= a;
                    if (a> 20)
                        a *= 2;
                Console.WriteLine(a);
            }
        }
    }
}
