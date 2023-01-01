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
        private string identifikacioniBroj;


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
            brojGlasova = 0;
            identifikacioniBroj = ime_prezime + "/" +  stranka;
        }

        public Kandidat(string ime_prezime, int brojGlasova, string stranka, string identifikacioniBroj)
        {
            this.ime_prezime = ime_prezime;
            this.stranka = stranka;
            this.brojGlasova = brojGlasova;
            this.identifikacioniBroj = identifikacioniBroj;
        }

        /**
         * author: enuhanovic1
         * funkcionalnost: 2.
         * metoda koja prikazuje clanstva kandidata u proslosti
         * Dodatno: napisati testove!!!
         */
        public string prikaziClanstva()
        {
            string rezultat = "";
            foreach (Clanstvo clanstvo in clanstva)
            {
                rezultat += clanstvo.prikaziClanstvo();
            }
            return rezultat;
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

        /**
         * Metoda ispod "ValidirajBrojLicneKarte" je poslije prvog zadatka metoda sa najvećom ciklomatskom kompleksnošću
         * zato ćemo nju koristiti za tuning. Ona svakako ne radi sa konzolom tako da neće biti problema.
         * 
         * POČETNA CIKLOMATSKA KOMPLEKSNOST: 12 
         * Iteracija 1: [ahajro2] 25-26 sekundi izvršavanje u odnosu na 31 sekundu prije refactoringa
         *              Metoda ima veću ciklomatsku kompleksnost, ali brže se izvršava
         * Iteracija 2: [abrulic1] 
         * Iteracija 3: ...
         * Iteracija 4: ...
         * Iteracija 5: ...
         * 
         */

        public static bool ValidirajBrojLicneKarteRefactoring1(string broj_licne)
        {
            if(broj_licne.Length != 9) return false;
            char cetvrti = broj_licne[4];
            if (cetvrti != 'E' && cetvrti != 'K' &&
                    cetvrti != 'J' && cetvrti != 'M' && cetvrti != 'T')
            {
                return false;
            }
            
            int provjera = 0;
            
            int duzina = broj_licne.Length;
            for (int i = 0; i <  duzina - 1; i += 2)
            {
                if (i == 4) i--;

                else if (broj_licne[i] < '0' || broj_licne[i] > '9' || broj_licne[i + 1] < '0' || broj_licne[i + 1] > '9')
                    return false;

            }
            /*
            foreach (char c in broj_licne)
            {
                if (i != 4 && (c < '0' || c > '9'))
                {
                        return false;
                }
                i++;

            }
            */
            return true;
        }

       //izvrsavanje 17.21 s
        public static bool ValidirajBrojLicneKarteRefactoring2(string broj_licne)
        {
            int duzina = broj_licne.Length;
            char cetvrti = broj_licne[4];
            if (duzina!=9 || cetvrti != 'E' && cetvrti != 'K' &&
                    cetvrti != 'J' && cetvrti != 'M' && cetvrti != 'T') return false;

                for (int i = 0; i < duzina - 1; i += 2)
            {
                if (i == 4) i--;

                else if (broj_licne[i] < '0' || broj_licne[i] > '9' || broj_licne[i + 1] < '0' || broj_licne[i + 1] > '9')
                    return false;

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

        public List<Clanstvo> Clanstva
        {
            get { return clanstva; }
            set
            {
                clanstva = value;   
            }
        }
    }
}
