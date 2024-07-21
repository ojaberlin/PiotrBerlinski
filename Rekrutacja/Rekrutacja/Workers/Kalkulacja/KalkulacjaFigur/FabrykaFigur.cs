using System;
using System.Collections.Generic;
using System.Linq;

namespace Rekrutacja.Workers.Kalkulacja.Figury
{
    public class FabrykaFigur
    {
        private List<IFigura> figury = new List<IFigura>()
        {
            new Koło(),
            new Kwadrat(),
            new Prostokąt(),
            new Trójkąt()
        };

        public IFigura InicjujFigurę(Figury figura)
        {
            var wybranaFigura = figury.FirstOrDefault(x => x.Figura == figura);

            if (wybranaFigura == null)
            {
                throw new ArgumentException("Nie znaleziono wybranej figury");
            }

            return wybranaFigura;
        }
    }
}
