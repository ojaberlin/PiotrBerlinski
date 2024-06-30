namespace Rekrutacja.Workers.Kalkulacja.OperacjeArytmetyczne
{
    public interface IOperacjaArytmetyczna
    {
        Operacje Operacja { get; }
        double Oblicz(double ZmiennaX, double ZmiennaY);
    }
}
