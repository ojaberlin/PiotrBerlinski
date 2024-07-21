using System;
using Rekrutacja.Workers.Kalkulacja.Wyjątki;

namespace Rekrutacja.Workers.Kalkulacja.Figury
{
    internal class Koło : IFigura
    {
        public Figury Figura => Figury.Koło;

        public int ObliczPolePowierzchni(double a, double b)
        {
            if (a < 0)
            {
                throw new NegativeNumberException("Wprowadzona wartość nie może być ujemna");
            }

            return (int)Math.Round(Math.PI * a * a);
        }
    }
}
