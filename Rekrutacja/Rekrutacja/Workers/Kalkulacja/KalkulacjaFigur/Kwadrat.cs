using Rekrutacja.Workers.Kalkulacja.Wyjątki;
using System;

namespace Rekrutacja.Workers.Kalkulacja.Figury
{
    internal class Kwadrat : IFigura
    {
        public Figury Figura => Figury.Kwadrat;

        private double a;

        public Kwadrat(double a)
        {
            this.a = a;
        }

        public int ObliczPolePowierzchni()
        {
            if (a < 0)
            {
                throw new NegativeNumberException("Wprowadzona wartość 'A' nie może być ujemna");
            }

            return (int)Math.Round(a * a);
        }
    }
}
