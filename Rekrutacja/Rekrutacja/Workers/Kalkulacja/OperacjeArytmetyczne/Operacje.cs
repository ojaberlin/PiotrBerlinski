using Soneta.Types;

namespace Rekrutacja.Workers.Kalkulacja.OperacjeArytmetyczne
{
    public enum Operacje
    {

        [Caption("+")]
        Dodawanie,

        [Caption("-")]
        Odejmowanie,

        [Caption("*")]
        Mnożenie,

        [Caption("/")]
        Dzielenie
    }
}
