using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rational
{
    public class Rat    //рационално число
    {
        private int num, den;   //числител и знаменател
        #region Constructors
        public Rat()   //default constructor
        {
            num = 0; den = 1;
        } 
        public Rat(int a, int b)
        {
            num = a; den = b;
            Normalize();
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
            Normalize();
        }
        #endregion
        public void Write() => Console.Write($"{num}/{den}");
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
        public static explicit operator double(Rat r) => (double)r.num / r.den; // form Rat to double
        public static explicit operator Rat(double d) => new Rat(d);  //from double to Rat

        #endregion
        #region Auxiliary functions
        private void Normalize()
        {
            if (den == 0)
            {
                throw new ArgumentException("Incorrect Parameter");
            }
            else
                 if (num == 0)
            {
                num = 0;
                den = 1;
            }
            else
            {
                int g = GCD(Math.Abs(num), Math.Abs(den));
                if ((num > 0 && den > 0) || (num < 0 && den < 0))   //дробта е положителна
                {
                    num = Math.Abs(num) / g;
                    den = Math.Abs(den) / g;
                }
                else   //дробта е отрицателна
                {
                    num = -Math.Abs(num) / g;
                    den = Math.Abs(den) / g;
                }
            }
        }
        private static int GCD(int a, int b)    // Н. О. Д.
        {
            while (a != b)
            {
                if (a > b)
                    a -= b;
                else
                    b -= a;
            }
            return a;
        }
        #endregion
    }
}
