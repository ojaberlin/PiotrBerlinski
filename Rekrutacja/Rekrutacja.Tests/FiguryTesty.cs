using NUnit.Framework;
using Rekrutacja.Workers.Kalkulacja.Figury;
using Rekrutacja.Workers.Kalkulacja.Wyjątki;
using System;

namespace Rekrutacja.Tests
{
    internal class FiguryTesty
    {
        #region Setup
        private FabrykaFigur fabrykaFigur;
        private int poprawnePoleKoła(double a) => (int)Math.Round(Math.PI * a * a);
        private int poprawnePoleKwadratu(double a) => (int)Math.Round(a * a);
        private int poprawnePoleProstokąta(double a, double b) => (int)Math.Round(a * b);
        private int poprawnePoleTrójkąta(double a, double b) => (int)Math.Round(a * b / 2);

        [SetUp]
        public void Inicjalizacja()
        {
            fabrykaFigur = new FabrykaFigur();
        }
        #endregion

        #region Testy podstawowe
        [Test]
        public void TestPolaPowierzchniKoła()
        {
            var rezultat = fabrykaFigur.InicjujFigurę(Figury.Koło).ObliczPolePowierzchni(5, 123);
            Assert.AreEqual(poprawnePoleKoła(5), rezultat);
        }

        [Test]
        public void TestPolaPowierzchniKwadratu()
        {
            var rezultat = fabrykaFigur.InicjujFigurę(Figury.Kwadrat).ObliczPolePowierzchni(5, 123);
            Assert.AreEqual(poprawnePoleKwadratu(5), rezultat);
        }

        [Test]
        public void TestPolaPowierzchniTrójkąta()
        {
            var rezultat = fabrykaFigur.InicjujFigurę(Figury.Trójkąt).ObliczPolePowierzchni(5, 10);
            Assert.AreEqual(poprawnePoleTrójkąta(5, 10), rezultat);
        }

        [Test]
        public void TestPolaPowierzchniProstokąta()
        {
            var rezultat = fabrykaFigur.InicjujFigurę(Figury.Prostokąt).ObliczPolePowierzchni(5, 10);
            Assert.AreEqual(poprawnePoleProstokąta(5, 10), rezultat);
        }

        #endregion


        #region Testy z wartościami ujemnymi

        [Test]
        public void TestUjemnejWartościDlaKwadratuRzucaWyjątek()
        {
            Assert.Throws<NegativeNumberException>(() => fabrykaFigur.InicjujFigurę(Figury.Kwadrat).ObliczPolePowierzchni(-5, 0));
        }

        [Test]
        public void TestUjemnejWartościDlaKołaRzucaWyjątek()
        {
            Assert.Throws<NegativeNumberException>(() => fabrykaFigur.InicjujFigurę(Figury.Koło).ObliczPolePowierzchni(-5, 0));
        }

        [Test]
        public void TestUjemnejWartościDlaTrójkątaRzucaWyjątek()
        {
            Assert.Throws<NegativeNumberException>(() => fabrykaFigur.InicjujFigurę(Figury.Trójkąt).ObliczPolePowierzchni(-5, -12));
        }

        [Test]
        public void TestUjemnejWartościDlaProstokątaRzucaWyjątek()
        {
            Assert.Throws<NegativeNumberException>(() => fabrykaFigur.InicjujFigurę(Figury.Prostokąt).ObliczPolePowierzchni(-5, -112));
        }

        [Test]
        public void NieZnalezionoFiguryRzucaWyjątek()
        {
            var ex = Assert.Throws<ArgumentException>(() => fabrykaFigur.InicjujFigurę((Figury)1000).ObliczPolePowierzchni(-5, -112));
            Assert.That(ex.Message, Is.EqualTo("Nie znaleziono wybranej figury"));
        }

        #endregion
    }
}
