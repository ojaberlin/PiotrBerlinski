namespace Rekrutacja.Workers.Kalkulacja.OperacjeArytmetyczne
{
    internal class OperacjaOdejmowania : IOperacjaArytmetyczna
    {
        public Operacje Operacja => Operacje.Odejmowanie;

        public double Oblicz(double ZmiennaX, double ZmiennaY)
        {
            return ZmiennaX - ZmiennaY;
        }
    }
}
