using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1
{
    public class Kandidat
    {
        
        private string ime_prezime { get; set; }
        private int brojGlasova { get; set; }
        private string stranka { get; set; }
        /**
         * author: ahajro2
         * funkcionalnost: 4. 
         * Dodan identifikacioniBroj za kandidata jer je on ujedno i glasac
         *
         */
        private int identifikacioniBroj { get; set; }
        /**
         * author: enuhanovic1
         * funkcionalnost: 2.
         * atribut koji cuva listu clanstava kandidata u proslosti
         * Dodatno: napisati testove!!!
         */
        public List<Clanstvo> clanstva { get; set; }
        public Kandidat() { }
        public Kandidat(string ime_prezime, string stranka)
        {
            this.ime_prezime = ime_prezime;
            this.stranka = stranka;
        }

        public string Ime_prezime
        {
            get { return ime_prezime; }
            set
            {
                ime_prezime = value;
            }
        }

        public string Stranka
        {
            get { return stranka;  }
            set
            {
                stranka = value;
            }
        }

        public int IdentifikacioniBroj
        {
            get { return identifikacioniBroj; }
            set
            {
                identifikacioniBroj = value;
            }
        }

        public int BrojGlasova
        {
            get { return brojGlasova; }
            set
            {
                brojGlasova = value;
            }
        }
    }
}
