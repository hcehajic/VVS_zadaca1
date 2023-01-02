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
        }

        /**
         * [TestMethod]
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
    }
}
