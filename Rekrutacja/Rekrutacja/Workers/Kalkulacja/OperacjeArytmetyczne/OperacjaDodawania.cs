namespace Rekrutacja.Workers.Kalkulacja.OperacjeArytmetyczne
{
    public class OperacjaDodawania : IOperacjaArytmetyczna
    {
        public Operacje Operacja => Operacje.Dodawanie;

        public double Oblicz(double ZmiennaX, double ZmiennaY)
        {
            return ZmiennaX + ZmiennaY;
        }
    }
}
