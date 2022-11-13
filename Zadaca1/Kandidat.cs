using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1
{
    public class Kandidat
    {
        
        public string ime_prezime { get; set; }
        public int brojGlasova { get; set; }
        public string stranka { get; set; }
        public Kandidat() { }
        public Kandidat(string ime_prezime, string stranka)
        {
            this.ime_prezime = ime_prezime;
            this.stranka = stranka;
        }
    }
}
