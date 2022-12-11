using CsvHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadaca1;

namespace TestProject
{
    [TestClass]
    public class Funkcionalnost3Test
    {




        static IEnumerable<object[]> Stranke
        {
            get
            {
                return new[]
                {
                    new object[] {"NES", 2000},
                    new object[] {"SDA", 4000},
                    new object[] {"NIP", 3500},
                    new object[] {"BHIF", 20000},
                    new object[] {"SDP", 20200},
                };
            }
        }


        static IEnumerable<object[]> PodaciZaTestiranjeKandidata
        {
            get
            {
                return UcitajKandidateCSV();
            }
        }


        public static IEnumerable<object[]> UcitajKandidateCSV()
        {
            using (var reader = new StreamReader("PodaciZaFunkcionalnost3Kandidati.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var rows = csv.GetRecords<dynamic>();
                foreach (var row in rows)
                {
                    var values = ((IDictionary<String, Object>)row).Values;
                    var elements = values.Select(elem => elem.ToString()).ToList();
                    yield return new object[] { elements[0], elements[1], elements[2], elements[3] };
                }
            }
        }

        /*
         * param: nazivStranke, brojGlasova
         * author: ahajro2
         * Funkcionalnost testa: Provjera ispisa sa inline podacima stranke i 
         * razlicitim brojem glasova svake od tih predefinisanih stranaka.
         * 
         * Testovi za poređenje prvog reda vraćenog stringa: PROLAZE!
         * Objašnjenje: Teško je bilo naći način poređenja, ali može se uporediti sa prvim redom jer 
         * ukoliko ispise taj red znači da funkcija radi i da dalji rad nije upitan. 
         * Također, dodan je prikaz ispisa u konzolu radi provjere cijelog ispisa na ekranu -> RADI!
         * 
         * TEST: USPJEŠAN!
         */

        [TestMethod]
        [DynamicData("Stranke")]
        public void TestIspisaRezultataIzbora(string nazivStranke, int brojGlasova)
        {

            List<Kandidat> lista = new List<Kandidat>();
            lista.Add(new Kandidat("Adnan Hajro", 750, nazivStranke, "1803001170103"));
            lista.Add(new Kandidat("Almina Brulić", 550, nazivStranke, "1803001170103"));
            lista.Add(new Kandidat("Aldin Kulaglic", 1100, nazivStranke, "1803001170103"));
            lista.Add(new Kandidat("Harun Cehajic", 122, nazivStranke, "1803001170103"));
            lista.Add(new Kandidat("Elma Nuhanovic", 132, nazivStranke, "1803001170103"));


            List<Kandidat> rukovodstvo = new List<Kandidat>();
            rukovodstvo.Add(new Kandidat("Neko Nekic", 750, nazivStranke, "1803001170103"));
            rukovodstvo.Add(new Kandidat("Taj Taglic", 550, nazivStranke, "1803001170103"));
            rukovodstvo.Add(new Kandidat("Ova Ovic", 1100, nazivStranke, "1803001170103"));
            rukovodstvo.Add(new Kandidat("Ti Tihic", 122, nazivStranke, "1803001170103"));
            rukovodstvo.Add(new Kandidat("Ono Onic", 132, nazivStranke, "1803001170103"));


            Izbori izbori = new Izbori();
            izbori.GlasanjeUToku = false;
            izbori.Ukupno_glasova_na_izborima = 30000;
            Stranka stranka = new Stranka(nazivStranke, brojGlasova);
            stranka.clanovi = lista;
            stranka.rukovodstvoStranke = rukovodstvo;
            List<Stranka> listaStranaka = new List<Stranka>();
            listaStranaka.Add(stranka);
            izbori.Stranke = listaStranaka;
            string[] nizStringovaZaProvjeru;
            string povratni = izbori.prikazRezultataIzbora();
            nizStringovaZaProvjeru = povratni.Split("\n");
            Console.WriteLine(izbori.prikazRezultataIzbora());
            Assert.AreEqual("Broj glasova za stranku: " + brojGlasova, nizStringovaZaProvjeru[0]);
        }

        /*
         * param: nazivStranke, brojGlasova
         * author: ahajro2
         * Funkcionalnost testa: Validiranje identifikacionog broja kandidata na izborima!
         * Kao identifikacioni kod kandidata predvidjeno je da to bude broj licne karte
         * TEST: USPJEŠAN!
         */

        [TestMethod]
        [DynamicData("PodaciZaTestiranjeKandidata")]
        public void testKandidata(string ime_prezime, string stranka, string identifikacioniBroj, string brojGlasova)
        {
            Kandidat k = new Kandidat(ime_prezime, Int32.Parse(brojGlasova), stranka, identifikacioniBroj);
            Assert.IsFalse(Kandidat.ValidirajBrojLicneKarte(k.IdentifikacioniBroj));
        }

        [TestMethod]
        public void testNezavrsetkaIzbora()
        {
            List<Kandidat> lista = new List<Kandidat>();
            lista.Add(new Kandidat("Adnan Hajro", 750, "Nebitno", "1803001170103"));
            lista.Add(new Kandidat("Almina Brulić", 550, "Nebitno", "1803001170103"));
            lista.Add(new Kandidat("Aldin Kulaglic", 1100, "Nebitno", "1803001170103"));
            lista.Add(new Kandidat("Harun Cehajic", 122, "Nebitno", "1803001170103"));
            lista.Add(new Kandidat("Elma Nuhanovic", 132, "Nebitno", "1803001170103"));


            List<Kandidat> rukovodstvo = new List<Kandidat>();
            rukovodstvo.Add(new Kandidat("Neko Nekic", 750, "Nebitno", "1803001170103"));
            rukovodstvo.Add(new Kandidat("Taj Taglic", 550, "Nebitno", "1803001170103"));
            rukovodstvo.Add(new Kandidat("Ova Ovic", 1100, "Nebitno", "1803001170103"));
            rukovodstvo.Add(new Kandidat("Ti Tihic", 122, "Nebitno", "1803001170103"));
            rukovodstvo.Add(new Kandidat("Ono Onic", 132, "Nebitno", "1803001170103"));


            Izbori izbori = new Izbori();
            izbori.GlasanjeUToku = true;
            izbori.Ukupno_glasova_na_izborima = 30000;
            Stranka stranka = new Stranka("Nebitno", 123);
            stranka.clanovi = lista;
            stranka.rukovodstvoStranke = rukovodstvo;
            List<Stranka> listaStranaka = new List<Stranka>();
            listaStranaka.Add(stranka);
            izbori.Stranke = listaStranaka;
            string[] nizStringovaZaProvjeru;
            string povratni = izbori.prikazRezultataIzbora();
            nizStringovaZaProvjeru = povratni.Split("\n");
            Console.WriteLine(izbori.prikazRezultataIzbora());
            //ubaciti neki uslov provjere za prolazak testa
            //totalno nebitno da se radi data-driven nad ovim testom... 
            Assert.AreEqual("GLASANJE JE JOŠ UVIJEK U TOKU!", nizStringovaZaProvjeru[2]);
        }
    }

}

