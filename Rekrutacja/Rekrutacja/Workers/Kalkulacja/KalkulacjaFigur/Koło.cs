using System;
using Rekrutacja.Workers.Kalkulacja.Wyjątki;

namespace Rekrutacja.Workers.Kalkulacja.Figury
{
    internal class Koło : IFigura
    {
        public Figury Figura => Figury.Koło;
        
        private double r;

        public Koło(double r)
        {
            this.r = r;
        }

        public int ObliczPolePowierzchni()
        {
            if (r < 0)
            {
                throw new NegativeNumberException("Wprowadzona wartość nie może być ujemna");
            }

            return (int)Math.Round(Math.PI * r * r);
        }
    }
}
