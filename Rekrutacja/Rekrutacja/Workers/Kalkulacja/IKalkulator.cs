using Rekrutacja.Workers.Kalkulacja.OperacjeArytmetyczne;

namespace Rekrutacja.Workers.Kalkulacja
{
    public interface IKalkulator
    {
        double Oblicz(double ZmiennaX, double ZmiennaY, Operacje operacja);

    }
}
