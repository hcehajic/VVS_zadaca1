using System;

namespace TestProject
{
	[TestClass]
	public class Funkcionalnost2Test
	{
        static IEnumerable<object[]> Stranke
        {
            get
            {
                return new[]
                {
                    new object[] {"NES", 2000},
                    new object[] {"SDA", 4000},
                    new object[] {"NIP", 3500},
                    new object[] {"BHIF", 20000},
                    new object[] {"SDP", 20200},
                };
            }
        }
    }
}
