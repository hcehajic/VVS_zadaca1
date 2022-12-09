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
        private string identifikacioniBroj { get; set; }
        public Kandidat() { }
        public Kandidat(string ime_prezime, string stranka)
        {
            this.ime_prezime = ime_prezime;
            this.stranka = stranka;
        }

        public Kandidat(string ime_prezime, int brojGlasova, string stranka, string identifikacioniBroj)
        {
            Ime_prezime = ime_prezime;
            BrojGlasova = brojGlasova;
            Stranka = stranka;
            IdentifikacioniBroj = identifikacioniBroj;        
        }

        public static bool ValidirajBrojLicneKarte(string broj_licne)
        {
            if (broj_licne.Length != 9) return false;
            int i = 0;
            foreach (char c in broj_licne)
            {
                if (i != 4)
                {
                    if (c < '0' || c > '9')
                        return false;
                }

                else if (i == 4 && (c != 'E' && c != 'K' && c != 'J' && c != 'M' && c != 'T'))
                    return false;

                i++;

            }
            return true;
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

        public string IdentifikacioniBroj
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
