using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex12
{
    class Program
    {
        static void Main(string[] args)
        {
        start:
            Console.Write("Введите возраст: ");
            int years = int.Parse(Console.ReadLine());
            int a = years % 10;
            uint l=0;
            switch (a)
            {
                case 1: if (years % 100 == 11) break; else l = 1; break;
                case 2: if (years % 100 == 12) break; else l = 2; break;
                case 3: if (years % 100 == 13) break; else l = 2; break;
                case 4: if (years % 100 == 14) break; else l = 2; break;
            }
            Console.Write("Вам "+years);
            switch (l)
            {
                case 1: Console.WriteLine(" год"); break;
                case 2: Console.WriteLine(" года"); break;
                default: Console.WriteLine(" лет"); break;
            }
            goto start;
        }
    }
}
