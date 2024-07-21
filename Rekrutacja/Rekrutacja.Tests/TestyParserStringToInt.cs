using NUnit.Framework;
using Rekrutacja.Workers.Kalkulacja;
using System;

namespace Rekrutacja.Tests
{
    internal class TestyParserStringToInt
    {
        [Test]
        public void PoprawnyCiąg()
        {
            var rezultat = "12555".ToInt();
            Assert.AreEqual(12555, rezultat);
        }

        [Test]
        public void PoprawnaLiczbaUjemna()
        {
            var rezultat = "-12555".ToInt();
            Assert.AreEqual(-12555, rezultat);
        }

        [Test]
        public void PoprawnyCiągZeSpacjami()
        {
            var rezultat = "   -12 555   ".ToInt();
            Assert.AreEqual(-12555, rezultat);
        }


        [Test]
        public void NiepoprawnyCiągRzucaWyjątek()
        {
            var ex = Assert.Throws<ArgumentException>(() => "#$#@#$%".ToInt());
            Assert.That(ex.Message, Is.EqualTo("Wprowadzony ciąg zawiera niepoprawne znaki"));
        }


        [Test]
        public void NiepoprawnyCiąg2RzucaWyjątek()
        {
            var ex = Assert.Throws<ArgumentException>(() => "!@#$%^&*()_+".ToInt());
            Assert.That(ex.Message, Is.EqualTo("Wprowadzony ciąg zawiera niepoprawne znaki"));
        }

        [Test]
        public void NiepoprawnyCiągZLiczbamiRzucaWyjątek()
        {
            var ex = Assert.Throws<ArgumentException>(() => "A123S124D5KJALSD".ToInt());
            Assert.That(ex.Message, Is.EqualTo("Wprowadzony ciąg zawiera niepoprawne znaki"));
        }

        [Test]
        public void NiepoprawnyCiągZeSpacjamiRzucaWyjątek()
        {
            var ex = Assert.Throws<ArgumentException>(() => "A SD KJAL SD".ToInt());
            Assert.That(ex.Message, Is.EqualTo("Wprowadzony ciąg zawiera niepoprawne znaki"));
        }

        [Test]
        public void PustyCiągZnakówRzucaWyjątek()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => "".ToInt());
        }

        [Test]
        public void PustyCiągZnaków2RzucaWyjątek()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => String.Empty.ToInt());
        }

        [Test]
        public void TestStringNullRzucaWyjątek()
        {
            string s = null;
            var ex = Assert.Throws<ArgumentNullException>(() => s.ToInt());
        }

        [Test]
        public void PojedynczyZnakUjemnościRzucaWyjątek()
        {
            var ex = Assert.Throws<ArgumentException>(() => "-".ToInt());
            Assert.That(ex.Message, Is.EqualTo("Wprowadzona wartość nie może być pusta"));
        }

        [Test]
        public void StringToSameSpacjeRzucaWyjątek()
        {
            var ex = Assert.Throws<ArgumentException>(() => "     ".ToInt());
            Assert.That(ex.Message, Is.EqualTo("Wprowadzona wartość nie może być pusta"));
        }

        [Test]
        public void PrzekroczenieGórnegoLimituIntRzucaWyjątek()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => "2147483648".ToInt());
        }

        [Test]
        public void PrzekroczenieDolnegoLimituIntRzucaWyjątek()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => "-21474836491".ToInt());
        }
    }
}
