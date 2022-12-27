using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadaca1;

namespace TestProject
{
    [TestClass]
    public class TestCodeTuning
    {

        /**
         * U metodi ispod ce se koristiti slicni predefinisani podaci kao sto su se koristili i u glavnom programu 
         * Posto se funkcija "Glasaj" koja ima najvecu ciklomatsku kompleksnost, veže za klasu "Izbori" onda možemo iskoristiti
         * te podatke koje već imamo samo da bismo napravili kod koji će se izvršavati 30 sec prije vršenja code tuning-a
         * 
         * NAPOMENA: OGRANIČENJE U DODAVANJU ISTIH KANDIDATA RAZLIČITIM STRANKAMA NIJE ZADOVOLJENO IZ RAZLOGA JER TO NIJE POENTA TESTIRANJA
         */
        [TestMethod]
        public void codeTuningPerformancesTest()
        {
            Kandidat k1 = new Kandidat("Nezir Nezirovic", "NP");
            Kandidat k2 = new Kandidat("Hamid Hamidovic", "NP");
            Kandidat k3 = new Kandidat("Pero Peric", "Nasa stranka");
            Kandidat k4 = new Kandidat("Ana Anic", "Nasa stranka");
            Kandidat r1 = new Kandidat("Šefik Šefic", "Nasa stranka");
            Kandidat r2 = new Kandidat("Šefi Šefi", "NP");

            List<Stranka> stranke = new List<Stranka> { new Stranka("NP", new List<Kandidat> { k1, k2, r2}),
                                                         new Stranka("Nasa stranka", new List<Kandidat> { k3, k4, r1}),
                                                        new Stranka("SDP", new List<Kandidat> { k2, k3, r2 }),
                                                    new Stranka("Seljačka stranka", new List<Kandidat> { k1, k2, r2 })};
            List<Kandidat> kandidati = new List<Kandidat> { k1, k2, k3, k4, r1, r2, new Kandidat("Nezavisni Kandidat", null), new Kandidat("Nezavisni Kandidatopet", null),
            new Kandidat("Nezavisni KandidatOpetJosJedan", null)};
            stranke[0].rukovodstvoStranke = new List<Kandidat> { r2 };
            stranke[1].rukovodstvoStranke = new List<Kandidat> { r1 };
            List<Glasac> glasaci = new List<Glasac>();
            string datum = "07.20.2000.00:00:00";
            DateTime dt;
            dt = new DateTime(2000, 7, 20, 0, 0, 0);
            Glasac glasac = new Glasac("Harun", "Cehajic", "Ovdje moze sta hoces jer je adresa", dt, "2034K5678", "2007000170005");
            glasaci.Add(glasac);
            glasaci.Add(new Glasac("Neko", "Nekic", "Izmisljena bb", dt, "1234K5678", "2007000170009"));
            glasaci.Add(new Glasac("Ena", "Enic", "Gradacacka bb", dt, "1234K5678", "2007000170009"));


            Izbori izbori = new Izbori(stranke, kandidati, glasaci);

        }
    }
}
