using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadaca1;
/*
Ime i prezime smiju sadržavati samo
slova i crticu, a ostale vrste karaktera nisu dozvoljene. Ime se sastoji od minimalno 2, a
maksimalno 40 slova, dok se prezime sastoji od minimalno 3, a maksimalno 50 slova. Ime,
prezime i adresa ne smiju biti prazni. Svaki glasač mora biti punoljetan i njegov datum rođenja
ne može biti u budućnosti. Broj lične karte uvijek se sastoji od tačno 7 karaktera u formatu
999A999, pri čemu 9 može biti bilo koji broj, a A bilo koje slovo iz skupa (E, J, K, M, T). Matični
broj se mora sastojati od 13 brojeva, pri čemu prva dva broja odgovaraju danu, sljedeća dva
broja mjesecu, a sljedeća tri broja godini rođenja glasača. Validacijom se treba pokriti i
jedinstveni identifikacioni broj glasača.
*/
namespace TestProject
{
    [TestClass]
    public class Glasac1FunkcionalnostTest
    {
        static IEnumerable<object[]> podaciZaTestiranjeImenaGlasaca
        {
            get
            {
                return new[]
                {
                    new object[]
                    {
                       "Hasan123",
                    },
                    new object[]
                    {
                        "Hasan_Drugi564"
                    },
                    new object[]
                    {
                        "!@#$$Hasan"
                    }, 
                    new object[]
                    {
                        "Hasan_Hasan "
                    },
                    new object[]
                    {
                        "n"
                    },
                    new object[]
                    {
                        "ovajobjekatimaprekocetrdesetzarakterazaimeatonijedozvoljenozatotrebadabaciizuzetaksvudagdjesetoprobauraditi"
                    },
                    new object[]
                    {
                        ""
                    }
                };
            }
        }

        [TestMethod]
        //Ime smije sadrzavati samo slova i crticu
        public void TestiranjeValidnostiZnakovaImena1()
        {
            Glasac glasac1 = new Glasac("Hasan", "Haskovic", "Nepoznata bb", new DateTime(2001, 12, 1), "1234K5678", "0112001175555");
            Glasac glasac3 = new Glasac("Hasan-Haskovic", "Haskovic", "Nepoznata bb", new DateTime(2001, 12, 1), "1234K5678", "0112001175555");

            bool tacnoJe1 = Glasac.ValidirajIme(glasac1.Ime);
            bool tacnoJe2 = Glasac.ValidirajIme(glasac3.Ime);

           Assert.IsTrue(tacnoJe1);
           Assert.IsTrue(tacnoJe2);
        }

        [TestMethod]
        [DynamicData("podaciZaTestiranjeImenaGlasaca")]
        [ExpectedException(typeof (ArgumentException))]
        public void TestiranjeValidnostiZnakovaImena2(string ime)
        {
            Glasac glasac2 = new Glasac(ime, "Haskovic", "Nepoznata bb", new DateTime(2001, 12, 1), "1234K5678", "0112001175555");
        }



    }
}
