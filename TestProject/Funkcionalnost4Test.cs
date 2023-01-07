using CsvHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadaca1;

namespace TestProject
{/*
    [TestClass]
    public class Funkcionalnost4Test
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
        /**
         * author: akulaglic3
         * params: nazivStranke, brojGlasova
         * Funkcionalnost: Provjeravanje ispisa vezanog za kandidate rukovodstva strane za FUNKCIONALNOST 4. 
         * Rezultat: Testovi prolaze.
         * Data-Driven: Nazivi stranke i njihovi ukupni glasovi
         */
    /*
        [TestMethod]
        [DynamicData("Stranke")]
        public void testIspisaKandidataRukovodstvaStranke(string nazivStranke, int brojGlasova)
        {
            List<Kandidat> lista = new List<Kandidat>();
            lista.Add(new Kandidat("Adnan Hajro", 750, nazivStranke, "18030011123"));
            lista.Add(new Kandidat("Almina Brulić", 550, nazivStranke, "18127398172"));
            lista.Add(new Kandidat("Aldin Kulaglic", 1100, nazivStranke, "18123170103"));
            lista.Add(new Kandidat("Harun Cehajic", 122, nazivStranke, "123123170103"));
            lista.Add(new Kandidat("Elma Nuhanovic", 132, nazivStranke, "154301112303"));

            Stranka stranka = new Stranka(nazivStranke, brojGlasova);
            stranka.rukovodstvoStranke = lista;
            string rezultatPovratkaFunkcije =
                "Ukupan broj glasova: 2654;\n" +
                "Kandidati: Identifikacioni broj: 18030011123\n" +
                "Identifikacioni broj: 18127398172\n" +
                "Identifikacioni broj: 18123170103\n" +
                "Identifikacioni broj: 123123170103\n" +
                "Identifikacioni broj: 154301112303\n";
            Assert.AreEqual(rezultatPovratkaFunkcije, stranka.prikazInformacijaORukovodstvu());
        }

        [TestMethod]
        [DynamicData("PodaciZaTestiranjeKandidata")]
        public void testiranjeZaJednogKandidata(string ime_prezime, string stranka, string identifikacioniBroj, string brojGlasova)
        {
            Kandidat k = new Kandidat(ime_prezime, Int32.Parse(brojGlasova), stranka, identifikacioniBroj);
            Stranka testStranka = new Stranka(stranka, 2500);
            List<Kandidat> listaJednogKandidata = new List<Kandidat>();
            listaJednogKandidata.Add(k);
            testStranka.rukovodstvoStranke = listaJednogKandidata;
            string rezultatZaPorediti = "Ukupan broj glasova:" + brojGlasova + ";\n" +
                "Kandidati: Identifikacioni broj: " + identifikacioniBroj + "\n";
            Assert.AreEqual(rezultatZaPorediti, testStranka.prikazInformacijaORukovodstvu());

        }
    }
    */
}