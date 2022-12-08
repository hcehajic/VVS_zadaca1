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
{
    [TestClass]
    public class Funkcionalnost3Test
    {
        static IEnumerable<object[]> PodaciZaTestiranjeKandidata
        {
            get
            {
                return UcitajKandidateCSV();
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
                    yield return new object[] { elements[0], elements[1], elements[2], DateTime.Parse(elements[3]), elements[4], elements[5] };
                }
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
                    yield return new object[] { elements[0], elements[1], elements[2], DateTime.Parse(elements[3]), elements[4], elements[5] };
                }
            }
        }
    }



}
