using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadaca1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    
    [TestClass]
    public class ObuhvatTest
    {
        [TestMethod]
        public void TestPotpuniObuhvatOdluka()
        {
            Assert.IsFalse(Kandidat.ValidirajBrojLicneKarte("123A32"));
            Assert.IsFalse(Kandidat.ValidirajBrojLicneKarte("C000E0009"));
            Assert.IsFalse(Kandidat.ValidirajBrojLicneKarte("0000A0009"));
            Assert.IsTrue(Kandidat.ValidirajBrojLicneKarte("0000E0009"));
        }

        [TestMethod]
        public void TestPotpuniObuhvatUslova()
        {
            Assert.IsFalse(Kandidat.ValidirajBrojLicneKarte("123A32"));
            Assert.IsFalse(Kandidat.ValidirajBrojLicneKarte("C000A0009"));
            Assert.IsFalse(Kandidat.ValidirajBrojLicneKarte("C000E0009"));
            Assert.IsFalse(Kandidat.ValidirajBrojLicneKarte("0000A0009"));
            Assert.IsTrue(Kandidat.ValidirajBrojLicneKarte("0000E0009"));
        }
    }
    
}
