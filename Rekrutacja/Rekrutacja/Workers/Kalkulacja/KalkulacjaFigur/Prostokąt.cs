using Rekrutacja.Workers.Kalkulacja.Wyjątki;
using System;

namespace Rekrutacja.Workers.Kalkulacja.Figury
{
    public class Prostokąt : IFigura
    {
        public Figury Figura => Figury.Prostokąt;

        private double a;
        private double b;

        public Prostokąt(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public int ObliczPolePowierzchni()
        {
            if (a < 0 || b < 0)
            {
                throw new NegativeNumberException("Wprowadzone wartości nie mogą być ujemne");
            }

            return (int)Math.Round(a * b);
        }
    }
}
