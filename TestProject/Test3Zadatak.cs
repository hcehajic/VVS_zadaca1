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
    public class Test3Zadatak
    {

        /**
         * [TestMethod]
         * @author ahajro2
         * @desc testiranje da li char na indexu 4 nije slovo što znači da to nije ispravan broj licne karte
         */

        [TestMethod]
        public void testNepravilnostiBrojaLicne()
        {
            String brojLicne = "123456789";
            Boolean ispravno = Kandidat.ValidirajBrojLicneKarte(brojLicne);
            //Treba da vrati false pa je zato '!'
            Assert.IsTrue(!ispravno);
            brojLicne = "1234T6789";
            ispravno = Kandidat.ValidirajBrojLicneKarte(brojLicne);
            Assert.IsTrue(ispravno);
        }

        /**
         * [TestMethod]
         * @author ahajro2
         * @desc drugi slučaj je nalaženje slova na nekom drugom mjesto osim indexa 4
         */

        [TestMethod]
        public void testNepravilnostiBrojaLicne1()
        {
            String brojLicne = "12K4567C9";
            Boolean ispravno = Kandidat.ValidirajBrojLicneKarte(brojLicne);
            //Treba da vrati false pa je zato '!'
            Assert.IsTrue(!ispravno);
        }


        /**
         * @author abrulic1
         * @desc treci slucaj je provjera da li su svi karakteri osim indeksa 4 brojevi 
         **/
        [TestMethod]
        public void testNepravilnostiBrojaLicne2()
        {
            String brojLicne = "1234K5678";
            Boolean ispravno = Kandidat.ValidirajBrojLicneKarte(brojLicne);
            //Treba da vrati false pa je zato '!'
            Assert.IsTrue(ispravno);
            brojLicne = "K234K56M8";
            ispravno = Kandidat.ValidirajBrojLicneKarte(brojLicne);
            Assert.IsTrue(!ispravno);
        }
    }
}
