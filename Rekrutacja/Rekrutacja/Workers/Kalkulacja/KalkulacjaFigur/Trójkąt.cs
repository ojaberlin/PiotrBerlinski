using Rekrutacja.Workers.Kalkulacja.Wyjątki;
using System;

namespace Rekrutacja.Workers.Kalkulacja.Figury
{
    internal class Trójkąt : IFigura
    {
        public Figury Figura => Figury.Trójkąt;
        private double a;
        private double h;

        public Trójkąt(double a, double h)
        {
            this.a = a; 
            this.h = h;
        }

        public int ObliczPolePowierzchni()
        {
            if (a < 0 || h < 0)
            {
                throw new NegativeNumberException("Wprowadzone wartości nie mogą być ujemne");
            }

            var result = Math.Round(a * h / 2);

            if (result > int.MaxValue)
            {
                throw new ArgumentOutOfRangeException();
            }

            return (int)result;
        }
    }
}
