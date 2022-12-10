﻿using CsvHelper;
using CsvHelper.Configuration.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Zadaca1;

namespace TestProject
{
    [TestClass]
    public class Funkcionalnost5Test
    {
        /*  
         *  Testovi za funkcionalnost 5 brisanja glasova od glasaca
         *  
         *  Autor klase Funkcionalnost5Test: Harun Cehajic
         *     
         *  Prosli testovi: brojKojiSuProsli/ukupniBrojTestova = 
         */

        static IEnumerable<object[]> GlasoviStranka
        {
            get
            {
                return new[]
                {
                    new object[] { 1, 1 },
                    new object[] { 2, 2 }
                };
            }
        }

        static IEnumerable<object[]> GlasoviSve
        {
            get
            {
                return UcitajGlasoveNezavisnogKandidataIKandidataStrankeCSV();
            }
        }

        private static IEnumerable<object[]> UcitajGlasoveNezavisnogKandidataIKandidataStrankeCSV()
        {
            using (var reader = new StreamReader("PodaciZaFunkcionalnost3Kandidati.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var rows = csv.GetRecords<dynamic>();
                foreach (var row in rows)
                {
                    var values = ((IDictionary<String, Object>)row).Values;
                    var elements = values.Select(elem => Convert.ToInt32(elem.ToString())).ToList();
                    yield return new object[] { elements[0], elements[1], elements[2] };
                }
            }
        }

        [TestMethod]
        public void TestPogresanUnosTajneSifre()
        {
                          
            Izbori izbori = new Izbori();
            Assert.IsFalse(izbori.ProvjeriUnesenuTajnuSifru("VVS20222022");
        }

        [TestMethod]
        [DynamicData("GlasoviStranka")]
        public void TestBrisanjeGlasaNezavisnogKandidataIStranke(int nezavisniKandidat, int stranka)
        {
            // kreiram izbore
            Kandidat k1 = new Kandidat("Nezir Nezirovic", "NP");
            Kandidat k2 = new Kandidat("Hamid Hamidovic", "NP");
            Kandidat k3 = new Kandidat("Pero Peric", "Nasa stranka");
            Kandidat k4 = new Kandidat("Ana Anic", "Nasa stranka");
            List<Stranka> stranke = new List<Stranka> { new Stranka("NP", new List<Kandidat> { k1, k2}),
                                                         new Stranka("Nasa stranka", new List<Kandidat> { k3, k4})};
            List<Kandidat> kandidati = new List<Kandidat> { k1, k2, k3, k4, new Kandidat("Prvi nezavisni", null), new Kandidat("Drugi nezavisni", null) };

            List<Glasac> glasaci = new List<Glasac>();
            string datum = "7/20/2000";
            DateTime dt;
            var jel_ok = DateTime.TryParse(datum, out dt);
            Glasac glasac = new Glasac("Harun", "Cehajic", "Ovdje moze sta hoces jer je adresa", dt, "2034K5678", "2007000170005");

            // sada postavljam na trenutnog glasaca da je glasao i dodajem za koga je glasao
            glasac.Glaso.Add(nezavisniKandidat);
            glasac.Glaso.Add(stranka);
            glasac.birao = true;

            // dodajem glasaca u listu glasaca
            glasaci.Add(glasac);

            Izbori izbori = new Izbori();
            izbori.GlasanjeUToku = true;
            izbori.Kandidati = kandidati;
            izbori.Glasaci = glasaci;

            // postavljam glasove prema zadanim parametrima iz dinamickih podataka

            // prvo postavljam za nezavisnog kandidata
            int counter = 1;
            List<int> listaIndeksaKandidataSaGlasovima = new List<int>();
            for (int i = 0; i < izbori.Kandidati.Count; i++)
            {
                if (kandidati[i].Stranka == null && counter == nezavisniKandidat)
                {
                    kandidati[i].BrojGlasova++;
                    listaIndeksaKandidataSaGlasovima.Add(i);    // sa indeksom 0 je nezavisni kandidat
                    break;
                }
                else if (kandidati[i].Stranka == null)
                {
                    counter++;
                }
            }

            // sada postavljam za stranku
            for (int i = 0; i < izbori.Kandidati.Count; i++)
            {
                if (kandidati[i].Stranka == izbori.Stranke[stranka - 1].naziv)
                {
                    izbori.Stranke[stranka - 1].brojGlasova++;
                    kandidati[i].BrojGlasova++;
                    listaIndeksaKandidataSaGlasovima.Add(i); // svaki naredni indeks je indeks od clana stranke koji je dobio glas
                }
            }

            // brisem glasove
            izbori.IzbrisiGlasoveZaGlasaca(izbori.Glasaci.Find(g => g.JMBG == "2007000170005"));

            // provjeravam da li su se obrisali glasovi
            Assert.AreEqual(izbori.Kandidati[listaIndeksaKandidataSaGlasovima[0]].BrojGlasova, 0); // nezavisni clan, broj glasova mora biti 0
            Assert.AreEqual(izbori.Stranke[stranka - 1].brojGlasova, 0); // takodjer i broj glasova stranke za koju se glasalo mora biti 0

            for (int i = 1; i < listaIndeksaKandidataSaGlasovima.Count; i++)
            {
                Assert.AreEqual(izbori.Kandidati[listaIndeksaKandidataSaGlasovima[i]].BrojGlasova, 0); // broj glasova svakog pojedinacnog kandidata stranke mora biti 0
            }
        }

        [TestMethod]
        [DynamicData("GlasoviSve")]
        public void TestBrisanjeGlasaNezavisnogKandidataIKandidataStranke(int nezavisniKandidat, int stranka, int kandidatStranke)
        {
            // kreiram izbore
            Kandidat k1 = new Kandidat("Nezir Nezirovic", "NP");
            Kandidat k2 = new Kandidat("Hamid Hamidovic", "NP");
            Kandidat k3 = new Kandidat("Pero Peric", "Nasa stranka");
            Kandidat k4 = new Kandidat("Ana Anic", "Nasa stranka");
            List<Stranka> stranke = new List<Stranka> { new Stranka("NP", new List<Kandidat> { k1, k2}),
                                                         new Stranka("Nasa stranka", new List<Kandidat> { k3, k4})};
            List<Kandidat> kandidati = new List<Kandidat> { k1, k2, k3, k4, new Kandidat("Prvi nezavisni", null), new Kandidat("Drugi nezavisni", null) };

            List<Glasac> glasaci = new List<Glasac>();
            string datum = "7/20/2000";
            DateTime dt;
            var jel_ok = DateTime.TryParse(datum, out dt);
            Glasac glasac = new Glasac("Harun", "Cehajic", "Ovdje moze sta hoces jer je adresa", dt, "2034K5678", "2007000170005");

            // sada postavljam na trenutnog glasaca da je glasao i dodajem za koga je glasao
            glasac.Glaso.Add(nezavisniKandidat);
            glasac.Glaso.Add(stranka);
            glasac.Glaso.Add(kandidatStranke);
            glasac.birao = true;

            // dodajem glasaca u listu glasaca
            glasaci.Add(glasac);

            Izbori izbori = new Izbori();
            izbori.GlasanjeUToku = true;
            izbori.Kandidati = kandidati;
            izbori.Glasaci = glasaci;

            // prvo postavljam za nezavisnog kandidata
            int counter = 1;
            List<int> listaIndeksaKandidataSaGlasovima = new List<int>();
            for (int i = 0; i < izbori.Kandidati.Count; i++)
            {
                if (kandidati[i].Stranka == null && counter == nezavisniKandidat)
                {
                    kandidati[i].BrojGlasova++;
                    listaIndeksaKandidataSaGlasovima.Add(i);    // sa indeksom 0 je nezavisni kandidat
                    break;
                }
                else if (kandidati[i].Stranka == null)
                {
                    counter++;
                }
            }

            // sada postavljam za stranku
            counter = 1;
            for (int i = 0; i < izbori.Kandidati.Count; i++)
            {
                if (kandidati[i].Stranka == izbori.Stranke[stranka - 1].naziv && counter == kandidatStranke)
                {
                    izbori.Stranke[stranka - 1].brojGlasova++;
                    kandidati[i].BrojGlasova++;
                    listaIndeksaKandidataSaGlasovima.Add(i); // svaki naredni indeks je indeks od clana stranke koji je dobio glas
                } 
                else if (kandidati[i].Stranka == izbori.Stranke[stranka - 1].naziv)
                {
                    counter++;
                }
            }

            // brisem glasove
            izbori.IzbrisiGlasoveZaGlasaca(izbori.Glasaci.Find(g => g.JMBG == "2007000170005"));

            // provjeravam da li su se obrisali glasovi
            Assert.AreEqual(izbori.Kandidati[listaIndeksaKandidataSaGlasovima[0]].BrojGlasova, 0); // nezavisni clan, broj glasova mora biti 0
            Assert.AreEqual(izbori.Kandidati[listaIndeksaKandidataSaGlasovima[1]].BrojGlasova, 0); // broj glasova kandidata iz stranke mora biti 0
            Assert.AreEqual(izbori.Stranke[stranka - 1].brojGlasova, 0); // takodjer i broj glasova stranke iz koje je kandidat mora biti 0
        }

    }
}
