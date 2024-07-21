using System;

namespace Rekrutacja.Workers.Kalkulacja.Wyjątki
{
    public class NegativeNumberException : Exception
    {
        public NegativeNumberException(string message) : base(message) { }
    }
}
