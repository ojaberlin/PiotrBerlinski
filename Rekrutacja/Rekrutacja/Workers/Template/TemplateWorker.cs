using Soneta.Business;
using System;
using Soneta.Kadry;
using Soneta.Types;
using Rekrutacja.Workers.Template;
using Soneta.Tools;
using Rekrutacja.Workers.Kalkulacja;
using Rekrutacja.Workers.Kalkulacja.OperacjeArytmetyczne;
using Rekrutacja.Workers.Kalkulacja.Figury;
using System.ComponentModel;
using Mono.CSharp;
using Soneta.Ksiega;

//Rejetracja Workera - Pierwszy TypeOf określa jakiego typu ma być wyświetlany Worker, Drugi parametr wskazuje na jakim Typie obiektów będzie wyświetlany Worker
[assembly: Worker(typeof(TemplateWorker), typeof(Pracownicy))]
namespace Rekrutacja.Workers.Template
{
    public class TemplateWorker
    {
        //Aby parametry działały prawidłowo dziedziczymy po klasie ContextBase
        public class TemplateWorkerParametry : ContextBase
        {
            [Caption("A"), Priority(1), Required]
            public double ZmiennaX { get; set; }

            [Caption("B"), Priority(2)]
            public double ZmiennaY { get; set; }

            [Caption("Data obliczeń"), Priority(3)]
            public Date DataObliczen { get; set; }

            [Caption("Figura"), Priority(4)]
            public Figury Figura { get; set; }

            public TemplateWorkerParametry(Context context) : base(context)
            {
                this.DataObliczen = Date.Today;
            }
        }
        //Obiekt Context jest to pudełko które przechowuje Typy danych, aktualnie załadowane w aplikacji
        //Atrybut Context pobiera z "Contextu" obiekty które aktualnie widzimy na ekranie
        [Context]
        public Context Cx { get; set; }
        //Pobieramy z Contextu parametry, jeżeli nie ma w Context Parametrów mechanizm sam utworzy nowy obiekt oraz wyświetli jego formatkę
        [Context]
        public TemplateWorkerParametry Parametry { get; set; }

        //Atrybut Action - Wywołuje nam metodę która znajduje się poniżej
        [Action("Kalkulator",
           Description = "Prosty kalkulator ",
           Priority = 10,
           Mode = ActionMode.ReadOnlySession,
           Icon = ActionIcon.Accept,
           Target = ActionTarget.ToolbarWithText)]
        public void WykonajAkcje()
        {
            //Włączenie Debug, aby działał należy wygenerować DLL w trybie DEBUG
            DebuggerSession.MarkLineAsBreakPoint();
            //Pobieranie danych z Contextu
            Pracownik[] pracownicy = null;
            if (this.Cx.Contains(typeof(Pracownik[])))
            {
                pracownicy = (Pracownik[])this.Cx[typeof(Pracownik[])];
            }

            if (pracownicy?.Length == 0)
            {
                return;
            }

            //Modyfikacja danych
            //Aby modyfikować dane musimy mieć otwartą sesję, któa nie jest read only
            using (Session nowaSesja = this.Cx.Login.CreateSession(false, false, "ModyfikacjaPracownika"))
            {
                //Otwieramy Transaction aby można było edytować obiekt z sesji
                using (ITransaction trans = nowaSesja.Logout(true))
                {
                    FabrykaFigur fabrykaFigur = new FabrykaFigur();
                    var wybranaFigura = fabrykaFigur.InicjujFigurę(Parametry.Figura);

                    var polePowierzchni = wybranaFigura.ObliczPolePowierzchni(Parametry.ZmiennaX, Parametry.ZmiennaY);
                    foreach (var pracownik in pracownicy)
                    {
                        //Pobieramy obiekt z Nowo utworzonej sesji
                        var pracownikZSesja = nowaSesja.Get(pracownik);
                        //Features - są to pola rozszerzające obiekty w bazie danych, dzięki czemu nie jestesmy ogarniczeni to kolumn jakie zostały utworzone przez producenta
                        pracownikZSesja.Features["DataObliczen"] = this.Parametry.DataObliczen;
                        //wynik zwracamy jako int, jednak cecha jest dalej typem double - dlatego poniżej castuję.
                        //Zmiana typu wyniku w systemowych opcjach -> definicje cech na liczbę całkowitą jest możliwa i sprawiłaby,
                        //że poniższy cast nie byłby potrzebny, jednak taka zmiana tworzy niebezpieczeństwo destablizacji działania programu.
                        //(najchętniej dopytałbym o szczegóły - czy zmiana typu cechy z liczby rzeczywistej jest pożądana/możliwa czy nie).
                        pracownikZSesja.Features["Wynik"] = (double)polePowierzchni;
                    }
                    //Zatwierdzamy zmiany wykonane w sesji
                    trans.CommitUI();
                }
                //Zapisujemy zmiany
                nowaSesja.Save();
            }
        }
    }
}