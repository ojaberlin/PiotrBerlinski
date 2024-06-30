using System;

namespace Rekrutacja.Workers.Kalkulacja.OperacjeArytmetyczne
{
    internal class OperacjaDzielenia : IOperacjaArytmetyczna
    {
        public Operacje Operacja => Operacje.Dzielenie;

        public double Oblicz(double ZmiennaX, double ZmiennaY)
        {
            if(ZmiennaY == 0)
            {
                throw new DivideByZeroException();
            }
            return ZmiennaX / ZmiennaY;
        }
    }
}
