using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1
{
    public class Stranka
    {
        public string naziv { get; set; }
        public List<Kandidat> clanovi { get; set; }
        public int brojGlasova { get; set; }
        public Stranka() { }
        public Stranka(string naziv, List<Kandidat> clanovi)
        {
            this.naziv = naziv;
            this.clanovi = clanovi;
        }
    }
}
