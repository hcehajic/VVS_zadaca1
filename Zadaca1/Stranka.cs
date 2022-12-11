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
        /**
         * author: ahajro2
         * - Dodano rukovodstvo stranke kao da su oni posebni u odnosu na clanove, jer su ujedno
         * oni koji upravljaju strankom pa su ujedno i kandidati.
         * Dodatno: napisati testove!!!
         *
         */
        public List<Kandidat> rukovodstvoStranke { get; set; }

        public Stranka() { rukovodstvoStranke = new List<Kandidat>(); clanovi = new List<Kandidat>(); }
        public Stranka(string naziv, List<Kandidat> clanovi)
        {
            this.naziv = naziv;
            this.clanovi = clanovi;
            rukovodstvoStranke = new List<Kandidat>();
        }
        public Stranka(string naziv, int brojGlasova)
        {
            this.naziv = naziv;
            this.brojGlasova= brojGlasova;
            clanovi = new List<Kandidat>();
            rukovodstvoStranke = new List<Kandidat>();
        }

        public Stranka(string naziv, List<Kandidat> clanovi, int brojGlasova)
        {
            this.naziv = naziv;
            this.clanovi = clanovi;
            this.brojGlasova = brojGlasova;
            rukovodstvoStranke = new List<Kandidat>();
        }


        /**
         * author: akulaglic3
         * param: none
         * funkcionalnost: 4. 
         * Dodane dvije metode: 
         * 1. sumira broj glasova stranke 
         * 2. prikazuje informacije o rukovodstvu u formatiranom stringu
         */

        public int sumarniBrojGlasovaStranke()
        {
            foreach(Kandidat rs in rukovodstvoStranke){
                foreach(Kandidat k in clanovi)
                {
                    if (k.Ime_prezime.Equals(rs.Ime_prezime))
                    {
                        rs.BrojGlasova = k.BrojGlasova;
                    }
                }
            }
            
            int sumaGlasova = 0;
            rukovodstvoStranke.ForEach((k) => { sumaGlasova += k.BrojGlasova; });
            return sumaGlasova;
        }

        public string prikazInformacijaORukovodstvu()
        {
            string formatIspisa = "Ukupan broj glasova: ";
            formatIspisa += sumarniBrojGlasovaStranke() + ";\nKandidati: ";
            rukovodstvoStranke.ForEach(kandidat => {
                formatIspisa += "Identifikacioni broj: " + kandidat.IdentifikacioniBroj + "\n";
            });
            return formatIspisa;
        }
    }
}
