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
    public class Funkcionalnost2Test
    {
        static IEnumerable<object[]> Clanstva
        {
            get
            {
                return new[]
                {
                    new object[] {"NIP", DateTime.Parse("01/01/2021"), DateTime.Parse("07/07/2021")},
                    new object[] {"NES", DateTime.Parse("02/02/2021"), DateTime.Parse("08/08/2021")}
                };
            }
        }


        static IEnumerable<object[]> PodaciZaClanstva
        {
            get
            {
                return UcitajClanstvaCSV();
            }
        }


        public static IEnumerable<object[]> UcitajClanstvaCSV()
        {
            using (var reader = new StreamReader("PodaciZaClanstva.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var rows = csv.GetRecords<dynamic>();
                foreach (var row in rows)
                {
                    var values = ((IDictionary<String, Object>)row).Values;
                    var elements = values.Select(elem => elem.ToString()).ToList();
                    yield return new object[] { elements[0], DateTime.Parse(elements[1]), DateTime.Parse(elements[2]) };
                }
            }
        }

        [TestMethod]
        [DynamicData("PodaciZaClanstva")]
        public void test1(string stranka, DateTime pocetak, DateTime kraj)
        {
            Clanstvo c = new Clanstvo(stranka, pocetak, kraj);
            Assert.AreEqual("Stranka: " + c.Stranka + ", Clanstvo od: " + c.Pocetak.Day + "." + c.Pocetak.Month + "." + c.Pocetak.Year +
                ", Clanstvo do: " + c.Kraj.Day + "." + c.Kraj.Month + "." + c.Kraj.Year + "\n", c.prikaziClanstvo());
        }

        [TestMethod]
        [DynamicData("Clanstva")]
        public void test2(string stranka, DateTime pocetak, DateTime kraj)
        {
            Clanstvo c = new Clanstvo(stranka, pocetak, kraj);
            Assert.AreEqual("Stranka: " + c.Stranka + ", Clanstvo od: " + c.Pocetak.Day + "." + c.Pocetak.Month + "." + c.Pocetak.Year +
                ", Clanstvo do: " + c.Kraj.Day + "." + c.Kraj.Month + "." + c.Kraj.Year + "\n", c.prikaziClanstvo());
        }

        [TestMethod]
        public void test3()
        {
            Kandidat k = new Kandidat("Neko Nekic", "SDA");
            List<Clanstvo> lista = new List<Clanstvo>();
            lista.Add(new Clanstvo("SDA", new DateTime(2000, 3, 31, 0, 0, 0), new DateTime(2002, 7, 7, 0, 0, 0)));
            lista.Add(new Clanstvo("SDP", new DateTime(2005, 5, 5, 0, 0, 0), new DateTime(2006, 6, 6, 0, 0, 0)));
            k.Clanstva = lista;
            Assert.AreEqual("Stranka: SDA, Clanstvo od: 31.3.2000, Clanstvo do: 7.7.2002\nStranka: SDP, Clanstvo od: 5.5.2005, Clanstvo do: 6.6.2006\n", k.prikaziClanstva());
        }

        [TestMethod]
        public void test4()
        {
            Kandidat k = new Kandidat("Neko Nekic", "SDA");
            List<Clanstvo> lista = new List<Clanstvo>();
            lista.Add(new Clanstvo("SDA", new DateTime(2000, 3, 31, 0, 0, 0), new DateTime(2002, 7, 7, 0, 0, 0)));
            lista.Add(new Clanstvo("SDP", new DateTime(2005, 5, 5, 0, 0, 0), new DateTime(2006, 6, 6, 0, 0, 0)));
            k.Clanstva = lista;
            k.Clanstva[0].Stranka = "NIP";
            Assert.AreEqual("Stranka: NIP, Clanstvo od: 31.3.2000, Clanstvo do: 7.7.2002\nStranka: SDP, Clanstvo od: 5.5.2005, Clanstvo do: 6.6.2006\n", k.prikaziClanstva());
        }
    }
}

