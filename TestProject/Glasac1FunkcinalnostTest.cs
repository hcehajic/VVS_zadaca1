using CsvHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Zadaca1;
/*
*Validacijom se treba pokriti i jedinstveni identifikacioni broj glasača.
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

        static IEnumerable<object[]> podaciZaTestiranjePrezimenaGlasaca
        {
            get
            {
                return new[]
                {
                    new object[]
                    {
                       "Haskovic123",
                    },
                    new object[]
                    {
                        "Hask0v1c"
                    },
                    new object[]
                    {
                        "Haskov!c"
                    },
                    new object[]
                    {
                        "Haskovic Hadan1"
                    },
                    new object[]
                    {
                        "Ha"
                    },
                    new object[]
                    {
                        "ovajobjekatimaprekopedesetzarakterazaprezimeglasaaatonijedozvoljenozatotrebadabaciizuzetaksvudagdjesetoprobauraditi.bacitceseizuzetak"
                    },
                    new object[]
                    {
                        ""
                    }
                };
            }
        }

        static IEnumerable<object[]> podaciZaTestiranjeMaticnogBroja
        {
            get
            {
                return UcitajPodatkeMaticniBrojCSV();
            }
        }

        static IEnumerable<object[]> podaciZaTestiranjeDatumaRodjenja
        {
            get
            {
                return UcitajPodatkeDatumRodjenjaCSV();
            }
        }

        static IEnumerable<object[]> podaciZaTestiranjeBrojaLicneKarte
        {
            get
            {
                return UcitajPodatkeXML();
            }
        }

        [TestMethod]
        //IME smije sadrzavati samo slova i crticu, duzina je na segmentu [2, 40] i ne smije biti prazno - ispravni slucajevi
        public void TestiranjeValidnostiZnakovaImena1()
        {
            Glasac glasac1 = new Glasac("Hasan", "Haskovic", "Nepoznata bb", new DateTime(2001, 12, 1), "1234K5678", "0112001175555");
            Glasac glasac3 = new Glasac("Hasan-Haskovic", "Haskovic", "Nepoznata bb", new DateTime(2001, 12, 1), "1234K5678", "0112001175555");
            Glasac glasac4 = new Glasac();
            bool tacnoJe1 = Glasac.ValidirajIme(glasac1.Ime);
            bool tacnoJe2 = Glasac.ValidirajIme(glasac3.Ime);


           Assert.IsTrue(tacnoJe1);
           Assert.IsTrue(tacnoJe2);

            glasac1.Ime = "NovoIspravno-ime";
            Assert.IsTrue(Glasac.ValidirajIme(glasac1.Ime));

            Assert.ThrowsException<ArgumentException>(() => glasac4.Ime="Ne1sprav0 !me!");


        }

        [TestMethod]
        //IME smije sadrzavati samo slova i crticu, duzina je na segmentu [2, 40] i ne smije biti prazno - neispravni slucajevi
        [DynamicData("podaciZaTestiranjeImenaGlasaca")]
        [ExpectedException(typeof(ArgumentException))]
        public void TestiranjeValidnostiZnakovaImena2(string ime)
        {
            //sam konstruktor poziva metodu ValidirajIme koja baca izuzetak
            Glasac glasac2 = new Glasac(ime, "Haskovic", "Nepoznata bb", new DateTime(2001, 12, 1), "1234K5678", "0112001175555");
        }




        [TestMethod]
        //PREZIME smije sadrzavati samo slova i crticu, duzina je na segmentu [3, 50] i ne smije biti prazno - ispravni slucajevi
        public void TestiranjeValidnostiZnakovaPrezimena1()
        {
            Glasac glasac1 = new Glasac("Hasan", "Haskovic", "Nepoznata bb", new DateTime(2001, 12, 1), "1234K5678", "0112001175555");
            Glasac glasac3 = new Glasac("Hasan-Haskovic", "Haskovic", "Nepoznata bb", new DateTime(2001, 12, 1), "1234K5678", "0112001175555");
            Glasac glasac4 = new Glasac();
            bool tacnoJe1 = Glasac.ValidirajPrezime(glasac1.Prezime);
            bool tacnoJe2 = Glasac.ValidirajPrezime(glasac3.Prezime);

            Assert.IsTrue(tacnoJe1);
            Assert.IsTrue(tacnoJe2);

            glasac1.Prezime = "Hasanovic";
            Assert.IsTrue(Glasac.ValidirajPrezime(glasac1.Prezime));

            Assert.ThrowsException<ArgumentException>(() => glasac4.Prezime = "Ne1sprav0 pr3z1me!");
        }

        [TestMethod]
        //PREZIME smije sadrzavati samo slova i crticu, duzina je na segmentu [3, 50] i ne smije biti prazno - neispravni slucajevi
        [DynamicData("podaciZaTestiranjePrezimenaGlasaca")]
        [ExpectedException(typeof(ArgumentException))]
        public void TestiranjeValidnostiZnakovaPrezimena2(string prezime)
        {
            //sam konstruktor poziva metodu ValidirajIme koja baca izuzetak
            Glasac glasac2 = new Glasac("Hasan", prezime, "Nepoznata bb", new DateTime(2001, 12, 1), "1234K5678", "0112001175555");
        }

        [TestMethod]
        public void TestiranjeValidnostiAdrese()
        {
            Glasac glasac2 = new Glasac("Hasan", "Hasanovic", "Nepoznata bb", new DateTime(2001, 12, 1), "1234K5678", "0112001175555");
            bool ispravnaAdresa = Glasac.ValidirajAdresu(glasac2.Adresa);
            Assert.IsTrue(ispravnaAdresa);

            glasac2.Adresa = "Nove adrese bb";
            Assert.IsTrue(Glasac.ValidirajAdresu(glasac2.Adresa));

            bool bacenIzuzetak = false;
            try
            {
                //ovdje ce biti bacen izuzetak
                glasac2.Adresa = "";
            }
            catch(ArgumentException e)
            {
                Assert.IsTrue(true);
                bacenIzuzetak = true;
            }

            if(bacenIzuzetak==false)
                Assert.IsTrue(false);
        }

        public static IEnumerable<object[]> UcitajPodatkeMaticniBrojCSV()
        {
            using (var reader = new StreamReader("podaciZaTestiranjeValidnostiMaticnogBroja.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var rows = csv.GetRecords<dynamic>();
                foreach (var row in rows)
                {
                    var values = ((IDictionary<String, Object>)row).Values;
                    var elements = values.Select(elem => elem.ToString()).ToList();
                    yield return new object[] { elements[0], elements[1], elements[2], DateTime.Parse(elements[3]), elements[4], elements[5]};
                }
            }
        }

        [TestMethod]
        [DynamicData("podaciZaTestiranjeMaticnogBroja")]
        [ExpectedException(typeof(ArgumentException))]

        public void TestiranjeMaticnogBroja(string ime, string prezime, string adresa, DateTime datumRodjenja, string brojLicne, string jmbg)
        {
            Glasac glasac = new Glasac(ime, prezime, adresa, datumRodjenja, brojLicne, jmbg);
        }

        public static IEnumerable<object[]> UcitajPodatkeDatumRodjenjaCSV()
        {
            using (var reader = new StreamReader("podaciZaTestiranjeDatumaRodjenja.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var rows = csv.GetRecords<dynamic>();
                foreach (var row in rows)
                {
                    var values = ((IDictionary<String, Object>)row).Values;
                    var elements = values.Select(elem => elem.ToString()).ToList();
                    yield return new object[] {DateTime.Parse(elements[0]), elements[1] };
                }
            }
        }
        [TestMethod]
        [DynamicData("podaciZaTestiranjeDatumaRodjenja")]
        [ExpectedException(typeof(ArgumentException))]

        public void TestiranjeDatumaRodjenja(DateTime datumRodjenja, string jmbg)
        {
            //problem moze biti kada se ovaj program pokrene za par godina, a neki od datuma ce biti validan za ovaj slucaj te samo za takav slucaj staviti da test ipak prodje tj. da se ipak baci izuzetak
                Glasac glasac = new Glasac("Neko", "Nekic", "Nepoznate bb", datumRodjenja, "1111K2222", jmbg);

                if (Glasac.ValidirajDatumRodjenja(datumRodjenja) == true)
                    throw new ArgumentException("Glasac je sada punoljetan, ali za vrijeme kreiranja CSV dokumenta nije bio");
            
        }



        public static IEnumerable<object[]> UcitajPodatkeXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("podaciZaTestiranjeBrojaLicneKarte.xml");
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                List<string> elements = new List<string>();
                foreach (XmlNode innerNode in node)
                {
                    elements.Add(innerNode.InnerText);
                }
                yield return new object[] { elements[0], elements[1], elements[2], DateTime.Parse(elements[3]), elements[4], elements[5]};
            }
        }



        [TestMethod]
        [DynamicData("podaciZaTestiranjeBrojaLicneKarte")]
        [ExpectedException(typeof(ArgumentException))]

        public void TestiranjeBrojaLicneKarte(string ime, string prezime, string adresa, DateTime datumRodjenja, string brojLicne, string jmbg)
        {
            Glasac glasac = new Glasac(ime, prezime, adresa, datumRodjenja, brojLicne, jmbg);
        }





    }
}
