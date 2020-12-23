using System;
using System.Numerics;
using System.Collections.Generic;
using System.Text;

namespace lab5._1
{
    class MyFrac : IComparable<MyFrac>, IMyNumber<MyFrac>
    {
        private readonly BigInteger nom;
        private readonly BigInteger denom;

        public MyFrac(BigInteger nom, BigInteger denom)
        {

            BigInteger g1 = nom;
            BigInteger g2 = denom;

            while ((g1 != 0) && (g2 != 0))
            {
                if (g1 > g2)
                    g1 %= g2;
                else
                    g2 %= g1;
            }

            this.nom = nom / (g1 + g2);
            this.denom = denom / (g1 + g2);
        }


        public int CompareTo(MyFrac frac)
        {
            double r1 = (double)this.nom / (double)this.denom;
            double r2 = (double)frac.nom / (double)frac.denom;

            return r1.CompareTo(r2);
        }

        public MyFrac(int nom, int denom)
        {
            int g1 = Math.Abs(nom);
            int g2 = Math.Abs(denom);
            if (denom < 0)
            {
                nom = -nom;
                denom = Math.Abs(denom);
            }

            while ((g1 != 0) && (g2 != 0))
            {
                if (g1 > g2)
                    g1 %= g2;
                else
                    g2 %= g1;
            }

            this.nom = nom / Math.Max(g1, g2);
            this.denom = denom / Math.Max(g1, g2);
        }
        public MyFrac()
        {

        }

        public MyFrac Multiply(MyFrac that)
        {
            return new MyFrac(this.nom * that.nom, this.denom * that.denom);
        }

        public MyFrac Divide(MyFrac that)
        {
            BigInteger newdenom = this.denom * that.nom;
            if (newdenom == 0)
            {
                throw new System.DivideByZeroException();
            }

            return new MyFrac(this.nom * that.denom, newdenom);
        }

        public MyFrac Add(MyFrac that)
        {
            return new MyFrac(this.nom * that.denom + this.denom * that.nom, this.denom * that.denom);
        }

        public MyFrac Subtract(MyFrac that)
        {
            return new MyFrac(this.nom * that.denom - this.denom * that.nom, this.nom * that.nom);
        }

        public static MyFrac operator +(MyFrac f1, MyFrac f2)
        {
            return f1.Add(f2);
        }

        public static MyFrac operator -(MyFrac f1, MyFrac f2)
        {
            return f1.Subtract(f2);
        }

        public static MyFrac operator *(MyFrac f1, MyFrac f2)
        {
            return f1.Multiply(f2);
        }

        public static MyFrac operator /(MyFrac f1, MyFrac f2)
        {
            return f1.Divide(f2);
        }

        public override string ToString()
        {
            return nom + "/" + denom;
        }

    }
}
