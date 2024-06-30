
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rekrutacja.Workers.Kalkulacja.OperacjeArytmetyczne
{
    internal class FabrykaOperacjiArytmetycznych
    {
        private List<IOperacjaArytmetyczna> operacjeArytmetyczne = new List<IOperacjaArytmetyczna>()
        {
            new OperacjaDodawania(),
            new OperacjaOdejmowania(),
            new OperacjaMnożenia(),
            new OperacjaDzielenia()
        };

        public IOperacjaArytmetyczna InicjujOperacjęArytmetyczną(Operacje operacja)
        {
            var operacjaArytmetyczna = operacjeArytmetyczne.FirstOrDefault(x => x.Operacja == operacja);

            if (operacjaArytmetyczna == null)
            {
                throw new ArgumentException("Nie znaleziono operacji arytmetycznej");
            }

            return operacjaArytmetyczna;
        }
    }
}
