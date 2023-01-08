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


        //[ahajro2]izvrsavanje oko 31 sekundu: stara verzija 
        //[abrulic1] izvrsavanje 34.27s, CPU 25%, Heap Size 283KB
        //[akulaglic3] izvrsavanje 28.9, CPU 24%, Heap Size 1093.91KB
        /* [TestMethod]
         public void codeTuningPerformancesTest()
         {
             string brojLicne = "1234K5678";
             int prviStop = 0;
             for (long i = 0; i < 357692307; i++)
             {
                 Kandidat.ValidirajBrojLicneKarte(brojLicne);
             }
             int drugiStop = 0;
         }



         //[ahajro2] izvrasanje oko 25 26 sekundi: stara verzija
         //[abrulic1] izvrsavanje 29.05s, CPU 25%, Heap Size 190.7KB
         //[akulaglic3] izvrsavanje 24.1, CPU 24%, Heap Size 1251.88KB
         [TestMethod]
         public void codeTuningPerformancesTestRefactored()
         {
             string brojLicne = "1234K5678";
             int prviStop = 0;
             for (int i = 0; i < 357692307; i++)
             {
                 Kandidat.ValidirajBrojLicneKarteRefactoring1(brojLicne);
             }
             int drugiStop = 0;
         }

         //
         //[abrulic1] izvrsavanje 27.43, CPU 25%, Heap Size 240.3KB
         //[akulaglic3] izvrsavanje 24.1, CPU 24%, Heap Size 1094.40KB
         [TestMethod]
         public void codeTuningPerformancesTestRefactored2()
         {
             string brojLicne = "1234K5678";
             int prviStop = 0;
             for (int i = 0; i < 357692307; i++)
             {
                 Kandidat.ValidirajBrojLicneKarteRefactoring2(brojLicne);
             }
             int drugiStop = 0;

         }


         //
         //[akulaglic3] izvrsavanje 23.1, CPU 24%, Heap Size 1300.91KB
         [TestMethod]
         public void codeTuningPerformancesTestRefactored3()
         {
             string brojLicne = "1234K5678";
             int prviStop = 0;
             for (int i = 0; i < 357692307; i++)
             {
                 Kandidat.ValidirajBrojLicneKarteRefactoring3(brojLicne);
             }
             int drugiStop = 0;
         }

         //[hcehajic] izvrsavanje 21.7333, CPU 25%, Heap Size 1485.32KB
         [TestMethod]
         public void codeTuningPerformancesTestRefactored4()
         {
             string brojLicne = "1234K5678";
             int prviStop = 0;
             for (long i = 0; i < 357692307; i++)
             {
                 Kandidat.ValidirajBrojLicneKarteRefactoring4(brojLicne);
             }
             int drugiStop = 0;
         }
         //[enuhanovic1] prije 12.766, CPU 17%, Heap Size 1415.08KB
        //[enuhanovic1] poslije 12.584, CPU 17%, Heap Size 1369.29KB
        [TestMethod]
        public void codeTuningPerformancesTestRefactored4()
        {
            string brojLicne = "1234K5678";
            int prviStop = 0;
            for (long i = 0; i < 357692307; i++)
            {
                Kandidat.ValidirajBrojLicneKarteRefactoring4(brojLicne);
            }
            int drugiStop = 0;
        }
      */
    }
     
}
