using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rational_CS
{
    public class Rat    //рационално число
    {
        private static int GCD(int a, int b)    // Н. О. Д.
        {
            while(a!=b)
            {
                if (a > b)
                    a -= b;
                else
                    b -= a;
            }
            return a;
        }
        private int num, den;   //числител и знаменател
        public Rat() : this(0,1)   //default constructor
        {}
        private void Normalize(int a, int b)
        {
            if (b == 0)
            {
                throw new ArgumentException("Incorrect Parameter");
            }
            else
                 if (a == 0)
            {
                num = 0;
                den = 1;
            }
            else
            {
                int g = GCD(Math.Abs(a), Math.Abs(b));
                if ((a > 0 && b > 0) || (a < 0 && b < 0))   //дробта е положителна
                {
                    num = Math.Abs(a) / g;
                    den = Math.Abs(b) / g;
                }
                else   //дробта е отрицателна
                {
                    num = -Math.Abs(a) / g;
                    den = Math.Abs(b) / g;
                }
            }
        }
        public Rat(int a, int b)
        {
            Normalize(a, b);
        }
        public Rat(double d)
        {
            int sign = (d > 0) ? +1 : -1;
            d = Math.Abs(d);
            int m = 0;
            const double eps = 0.000000000001;
            while (Math.Abs(d - (int)d)>eps)
            {
                d *= 10;
                m++;
            }
            num = (int)d;
            den = (int)Math.Pow(10, m);
            Normalize(num, den);
        }
        public void Write()
        {
            Console.Write($"{num}/{den}");
          //  Console.Write("{0}/{1}", num, den);
        }
        public override string ToString() => $"{num}/{den}";
        #region Arithmetic operations
        public Rat SumRat(Rat r) => new Rat(this.num * r.den + r.num * this.den, this.den * r.den);
        public Rat SubRat(Rat r) => new Rat(this.num * r.den - r.num * this.den, this.den * r.den);
        public Rat MultRat(Rat r) => new Rat(this.num * r.num, this.den * r.den);
        public Rat QuotRat(Rat r) => new Rat(this.num*r.den, this.den*r.num);
        #endregion
        #region Overloaded operators
        public static Rat operator +(Rat r1, Rat r2) => new Rat(r1.num * r2.den + r2.num*r1.den, r1.den * r2.den);
        public static Rat operator -(Rat r1, Rat r2) => new Rat(r1.num * r2.den - r2.num * r1.den, r1.den * r2.den);
        public static Rat operator *(Rat r1, Rat r2) => new Rat(r1.num * r2.num, r1.den * r2.den);
        public static Rat operator /(Rat r1, Rat r2) => new Rat(r1.num * r2.den, r2.num * r1.den);
        public static explicit operator double(Rat r) => (double)r.num / r.den;
       
        #endregion
    }
}
