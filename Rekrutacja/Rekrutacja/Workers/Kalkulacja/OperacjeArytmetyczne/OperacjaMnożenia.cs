using System;

namespace Rekrutacja.Workers.Kalkulacja.OperacjeArytmetyczne
{
    internal class OperacjaMnożenia : IOperacjaArytmetyczna
    {
        public Operacje Operacja => Operacje.Mnożenie;

        public double Oblicz(double ZmiennaX, double ZmiennaY)
        {
            return ZmiennaX * ZmiennaY;
        }
    }
}
