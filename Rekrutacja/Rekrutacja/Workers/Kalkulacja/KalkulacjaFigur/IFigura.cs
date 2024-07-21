namespace Rekrutacja.Workers.Kalkulacja.Figury
{
    public interface IFigura
    {
        Figury Figura { get; }
        int ObliczPolePowierzchni();
    }
}
