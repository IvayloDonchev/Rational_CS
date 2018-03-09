using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rational;

namespace Rational_CS
{
    class Program
    {
        static void Main(string[] args)
        {
            Rat r1 = new Rat(2, 8);
            Rat r2 = new Rat(3, 9);

            Rat r = r1.SumRat(r2);   //r=r1+r2
            Console.WriteLine($"{r1} + {r2} = {r}");
            Console.WriteLine($"{r1} + {r2} = {r1+r2}");
            
            r = r1.SubRat(r2);   //r = r1 - r2
            Console.WriteLine($"{r1} - {r2} = {r}");
            Console.WriteLine($"{r1} - {r2} = {r1 - r2}");

            r = r1.MultRat(r2);   //r = r1 * r2
            Console.WriteLine($"{r1} * {r2} = {r}");
            Console.WriteLine($"{r1} * {r2} = {r1 * r2}");

            r = r1.QuotRat(r2);   //r = r1 / r2
            Console.WriteLine($"{r1} / {r2} = {r}");
            Console.WriteLine($"{r1} / {r2} = {r1 / r2}");

            r = new Rat(0.112);
            Console.WriteLine($"{r} = {(double)r}");
            Console.WriteLine((Rat)0.1024);
           
            Console.ReadKey();
        }
    }
}
