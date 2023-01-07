using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadaca1;

namespace TestProject
{
    [TestClass]
    internal class ObuhvatTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            AssertFalse(Kandidat.ValidirajBrojLicneKarte("123A32"));
        }
    }
}
