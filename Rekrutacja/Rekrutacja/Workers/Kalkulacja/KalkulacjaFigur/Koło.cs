using System;
using Rekrutacja.Workers.Kalkulacja.Wyjątki;
using Soneta.Business;

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

            var result = Math.Round(Math.PI * r * r);

            if(result > int.MaxValue)
            {
                throw new ArgumentOutOfRangeException();
            }

            return (int)Math.Round(Math.PI * r * r);
        }
    }
}
