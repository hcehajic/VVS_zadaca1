using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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


        //izvrsavanje oko 31 sekundu
        [TestMethod]
        public void codeTuningPerformancesTest()
        {
            string brojLicne = "1234K5678";
            int prviStop = 0;
            for (long i = 0; i < 286200550; i++)
            {
                Kandidat.ValidirajBrojLicneKarte(brojLicne);
            }
            int drugiStop = 0;
        }



        //izvrasanje oko 25 26 sekundi
        [TestMethod]
        public void codeTuningPerformancesTestRefactored()
        {
            string brojLicne = "1234K5678";
            int prviStop = 0;
            for (int i = 0; i < 286200550; i++)
            {
                Kandidat.ValidirajBrojLicneKarteRefactoring1(brojLicne);
            }
            int drugiStop = 0;
        }
    }
}
