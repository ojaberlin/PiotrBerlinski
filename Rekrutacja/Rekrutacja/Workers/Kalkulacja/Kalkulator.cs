using Rekrutacja.Workers.Kalkulacja.OperacjeArytmetyczne;

namespace Rekrutacja.Workers.Kalkulacja
{
    public class Kalkulator : IKalkulator
    {
        private FabrykaOperacjiArytmetycznych fabrykaOperacjiArytmetycznych = new FabrykaOperacjiArytmetycznych();

        public double Oblicz(double ZmiennaX, double ZmiennaY, Operacje operacja)
        {
            var operacjaArytmetyczna = fabrykaOperacjiArytmetycznych.InicjujOperacjęArytmetyczną(operacja);
            return operacjaArytmetyczna.Oblicz(ZmiennaX, ZmiennaY);
        }
    }
}
