using System;
using System.Linq;
namespace Rekrutacja.Workers.Kalkulacja
{
    public static class CustomStringExtensionMethods
    {
        //dla obecnego przypadku, w którym liczymy pole ta metoda nie musi zawierać sprawdzania ujemności, jest to dodane na potrzeby rzucania odpowiedniego
        //wyjątku w późniejszym etapie (co można to było zrobić np. sprawdzając tylko czy na początku widnieje znak ujemności, jednak stąd to już tylko mały
        //krok do tego aby parser działał pełnoprawnie.
        public static int ToInt(this string str)
        {
            //ostatnia wartość z tabeli ascii przed ciągiem liczb - jeśli znak jest liczbą, odjęcie 48 konwertuje go na faktyczną liczbę
            const int charToNumberTranslator = 48;
            const int minusSign = 45;
            bool isNegative = false;

            if (!str.Any())
            {
                throw new ArgumentNullException();
            }

            var stringToConvert = str.Replace(" ", String.Empty);

            if (!stringToConvert.Any())
            {
                throw new ArgumentException("Wprowadzona wartość nie może być pusta");
            }

            if (stringToConvert[0] == minusSign)
            {
                isNegative = true;
                stringToConvert = stringToConvert.Remove(0, 1);
            }

            if (!stringToConvert.Any())
            {
                throw new ArgumentException("Wprowadzona wartość nie może być pusta");
            }

            if (stringToConvert.Any(x => x < minusSign || (x > minusSign && x < charToNumberTranslator) || x > 57))
            {
                throw new ArgumentException("Wprowadzony ciąg zawiera niepoprawne znaki");
            }

            double result = 0;

            foreach(char c in stringToConvert)
            {
                result *= 10;
                result += (c - charToNumberTranslator);
            }

            result = result * (isNegative ? -1 : 1);

            if (result > int.MaxValue || result < int.MinValue)
            {
                throw new ArgumentOutOfRangeException();
            }

            return (int)result;
        }
    }
}
