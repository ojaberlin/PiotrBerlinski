using System;
using System.Collections.Generic;
using System.Linq;

namespace Rekrutacja.Workers.Kalkulacja.Figury
{
    public class FabrykaFigur
    {

        public IFigura InicjujFigurę(Figury figura, double a, double b)
        {
            switch (figura)
            {
                case Figury.Trójkąt:
                {
                    return new Trójkąt(a, b);
                }
                case Figury.Prostokąt:
                {
                    return new Prostokąt(a, b);
                }
                case Figury.Kwadrat:
                {
                    return new Kwadrat(a);
                }
                case Figury.Koło:
                {
                    return new Koło(a);
                }
                default:
                    throw new ArgumentException("Nie znaleziono wybranej figury");
            }
        }
    }
}
