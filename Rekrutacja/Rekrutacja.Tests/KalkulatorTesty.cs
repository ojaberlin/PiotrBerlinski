using NUnit.Framework;
using Rekrutacja.Workers.Kalkulacja;
using Rekrutacja.Workers.Kalkulacja.OperacjeArytmetyczne;
using System;

namespace Rekrutacja.Tests
{
    internal class KalkulatorTesty
    {
        #region Setup
        private IKalkulator kalkulator;

        [SetUp]
        public void Inicjalizacja()
        {
            kalkulator = new Kalkulator();
        }
        #endregion

        #region Testy podstawowe
        [Test]
        public void TestDodawania()
        {
            var rezultat = kalkulator.Oblicz(144, 233, Operacje.Dodawanie);
            Assert.AreEqual(144 + 233, rezultat);
        }

        [Test]
        public void TestOdejmowania()
        {
            var rezultat = kalkulator.Oblicz(144, 233, Operacje.Odejmowanie);
            Assert.AreEqual(144 - 233, rezultat);
        }

        [Test]
        public void TestMnożenia()
        {
            var rezultat = kalkulator.Oblicz(144, 233, Operacje.Mnożenie);
            Assert.AreEqual(144 * 233, rezultat);
        }

        [Test]
        public void TestDzielenia()
        {
            var rezultat = kalkulator.Oblicz(1, 2, Operacje.Dzielenie);
            Assert.AreEqual((double)1 / 2, rezultat);
        }
        #endregion

        #region testy z jedną liczbą ujemną
        [Test]
        public void TestMnożeniaZLiczbąUjemną()
        {
            var rezultat = kalkulator.Oblicz(-144, 233, Operacje.Mnożenie);
            Assert.AreEqual(-144 * 233, rezultat);
        }

        [Test]
        public void TestOdejmowaniaZLiczbąUjemną()
        {
            var rezultat = kalkulator.Oblicz(144, -233, Operacje.Odejmowanie);
            Assert.AreEqual(144 - -233, rezultat);
        }

        [Test]
        public void TestDodawaniaZLiczbąUjemną()
        {
            var rezultat = kalkulator.Oblicz(-144, 233, Operacje.Dodawanie);
            Assert.AreEqual(-144 + 233, rezultat);
        }

        [Test]
        public void TestDzieleniaZLiczbąUjemną()
        {
            var rezultat = kalkulator.Oblicz(-144, 233, Operacje.Dzielenie);
            Assert.AreEqual((double) -144 / 233, rezultat);
        }
        #endregion

        #region testy z dwiema liczbami ujemnymi
        [Test]
        public void TestDodawaniaZLiczbamiUjemnymi()
        {
            var rezultat = kalkulator.Oblicz(-144, -233, Operacje.Dodawanie);
            Assert.AreEqual(-144 + -233, rezultat);
        }

        [Test]
        public void TestOdejmowaniaZLiczbamiUjemnymi()
        {
            var rezultat = kalkulator.Oblicz(-144, -233, Operacje.Odejmowanie);
            Assert.AreEqual(-144 - -233, rezultat);
        }

        [Test]
        public void TestMnożeniaZLiczbamiUjemnymi()
        {
            var rezultat = kalkulator.Oblicz(-144, -233, Operacje.Mnożenie);
            Assert.AreEqual(-144 * -233, rezultat);
        }
        #endregion

        #region testy z jednym zerem
        [Test]
        public void TestDodawaniaZZerem()
        {
            var rezultat = kalkulator.Oblicz(0, 123, Operacje.Dodawanie);
            Assert.AreEqual(123, rezultat);
        }

        [Test]
        public void TestOdejmowaniaZZerem()
        {
            var rezultat = kalkulator.Oblicz(0, 123, Operacje.Odejmowanie);
            Assert.AreEqual(-123, rezultat);
        }

        [Test]
        public void TestMnożeniaZZerem()
        {
            var rezultat = kalkulator.Oblicz(0, 123, Operacje.Mnożenie);
            Assert.AreEqual(0, rezultat);
        }

        [Test]
        public void TestDzieleniaZeraBrakBłędu()
        {
            var rezultat = kalkulator.Oblicz(0, 123, Operacje.Dzielenie);
            Assert.AreEqual(0 / 123, rezultat);
        }
        #endregion

        #region testy z dwoma zerami
        [Test]
        public void TestDodawaniaZZerami()
        {
            var rezultat = kalkulator.Oblicz(0, 0, Operacje.Dodawanie);
            Assert.AreEqual(0, rezultat);
        }

        [Test]
        public void TestOdejmowaniaZZerami()
        {
            var rezultat = kalkulator.Oblicz(0, 0, Operacje.Odejmowanie);
            Assert.AreEqual(0, rezultat);
        }

        [Test]
        public void TestMnożeniaZZerami()
        {
            var rezultat = kalkulator.Oblicz(0, 0, Operacje.Odejmowanie);
            Assert.AreEqual(0, rezultat);
        }

        [Test]
        public void TestDzieleniaZZerami()
        {
            Assert.Throws<DivideByZeroException>(() => kalkulator.Oblicz(0, 0, Operacje.Dzielenie));
        }
        #endregion

        #region testy z liczbami wymiernymi niecałkowitymi
        [Test]
        public void TestDodawaniaZLiczbamiWymiernymiNiecałkowitymi()
        {
            var rezultat = kalkulator.Oblicz(-144.82, -233.23, Operacje.Dodawanie);
            Assert.AreEqual((double)-144.82 + -233.23, rezultat);
        }

        [Test]
        public void TestOdejmowaniaZLiczbamiWymiernymiNiecałkowitymi()
        {
            var rezultat = kalkulator.Oblicz(-144.82, -233.23, Operacje.Odejmowanie);
            Assert.AreEqual((double)-144.82 - -233.23, rezultat);
        }

        [Test]
        public void TestMnożeniaZLiczbamiWymiernymiNiecałkowitymi()
        {
            var rezultat = kalkulator.Oblicz(-144.82, -233.23, Operacje.Mnożenie);
            Assert.AreEqual((double)-144.82 * -233.23, rezultat);
        }


        [Test]
        public void TestDzieleniaZLiczbamiWymiernymiNiecałkowitymi()
        {
            var rezultat = kalkulator.Oblicz(-144.82, -233.23, Operacje.Dzielenie);
            Assert.AreEqual((double)-144.82 / -233.23, rezultat);
        }
        #endregion

        #region Testy wyjątków
        [Test]
        public void TestDzieleniaPrzezZeroOczekiwanyBłąd()
        {
            Assert.Throws<DivideByZeroException>(() => kalkulator.Oblicz(144, 0, Operacje.Dzielenie));
        }

        [Test]
        public void TestBłęduNieznanejOperacjiOczekiwanyBłąd()
        {
            var ex = Assert.Throws<ArgumentException>(() => kalkulator.Oblicz(144, 0, (Operacje)100));
            Assert.That(ex.Message, Is.EqualTo("Nie znaleziono operacji arytmetycznej"));
        }
        #endregion
    }
}
