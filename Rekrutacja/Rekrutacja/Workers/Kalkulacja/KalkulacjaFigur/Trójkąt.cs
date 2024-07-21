using Rekrutacja.Workers.Kalkulacja.Wyjątki;
using System;

namespace Rekrutacja.Workers.Kalkulacja.Figury
{
    internal class Trójkąt : IFigura
    {
        public Figury Figura => Figury.Trójkąt;

        public int ObliczPolePowierzchni(double a, double b)
        {
            if (a < 0 || b < 0)
            {
                throw new NegativeNumberException("Wprowadzone wartości nie mogą być ujemne");
            }

            return (int)Math.Round(a * b / 2);
        }
    }
}
