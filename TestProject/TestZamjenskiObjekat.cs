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
    public class TestZamjenskiObjekat
    {
        [TestMethod]
        public void TestGlasacNijePrethodnoGlasao()
        {
            Glasac glasac = new Glasac();
            Spy spy = new Spy();
            spy.Opcija = "Nije glasao";
            Assert.IsTrue(glasac.VjerodostojnostGlasaca(spy));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Glasač je već izvršio glasanje!")]
        public void TestGlasacJePrethodnoGlasao()
        {
            Glasac glasac = new Glasac();
            Spy spy = new Spy();
            spy.Opcija = "Glasao";
            glasac.VjerodostojnostGlasaca(spy);
        }
    }
}
