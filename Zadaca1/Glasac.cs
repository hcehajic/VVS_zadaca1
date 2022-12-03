using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Zadaca1
{
    public class Glasac
    {
        /*
        (ime i prezime, adresa, datum rođenja), broj lične karte, matični broj
        Potrebno je onemogućiti pristup svim
        informacijama osobama koje vrše identifikaciju glasača, osim jedinstvenom
        identifikacionom kodu.
        */
        

        private string ime;
        private string prezime;
        private string adresa;
        private DateTime datum_rodjenja;
        private string broj_licne;
        private string jmbg;
        private string kod;

        public string Ime  
        {
            get { return ime; }   
            set {
                if (ValidirajIme(value))
                    ime = value;
                else throw new ArgumentException("Neispravno ime");

            }  
        }

        public string Prezime
        {
            get { return prezime; }
            set
            {
                if (ValidirajPrezime(value))
                    prezime = value;
                else throw new ArgumentException("Neispravno prezime");
            }

        }


        public bool birao { get; set; }

        public Glasac() { }

        public Glasac(string ime, string prezime, string adresa, DateTime datum_rodjenja, string broj_licne, string jmbg)
        {
            ValidirajUnos(ime, prezime, broj_licne, jmbg, adresa, datum_rodjenja);
            this.ime = ime;
            this.prezime = prezime;
            this.adresa = adresa;
            this.broj_licne = broj_licne;
            this.datum_rodjenja = datum_rodjenja;
            this.jmbg = jmbg;
            birao = false;
            KreirajJedinstveniKod();
        }

        /* 
                jedinstveni identifikacijski kod koji predstavlja kombinaciju prva dva
                karaktera svih informacija o glasaču
        */
        void KreirajJedinstveniKod()
        {
            kod = "";
            kod = kod + ime[0] + ime[1];
            kod = kod + prezime[0] + prezime[1];
            kod = kod + adresa[0] + adresa[1];
            string dan = "";
            if (datum_rodjenja.Day < 10)
            {
                dan = "0";
            }
            kod = kod + dan + datum_rodjenja.Day.ToString();
            kod = kod + broj_licne[0] + broj_licne[1];
            kod = kod + jmbg[0] + jmbg[1];
        }

    
        void ValidirajUnos(string ime, string prezime, string broj_licne, string jmbg, string adresa, DateTime datum_rodjenja)
        {
            if (!ValidirajIme(ime))
            {
                throw new ArgumentException("Neispravno ime!");
            }
            if (!ValidirajPrezime(prezime))
            {
                throw new ArgumentException("Neispravno prezime!");
            }
      
            if (!ValidirajBrojLicneKarte(broj_licne))
            {
                throw new ArgumentException("Neispravan broj licne!");
            }
            if (!ValidirajJMBG(jmbg))
            {
                throw new ArgumentException("Neispravan JMBG!");
            }
            if (!ValidirajAdresu(adresa))
                throw new ArgumentException("Neispravna adresa!");
            if (!ValidirajDatumRodjenja(datum_rodjenja))
            {
                throw new ArgumentException("Neispravan datum rodjenja!");
            }
        }

        bool ValidirajJedinstveniKod(string kod)
        {
            if (kod.Length != 12) return false;
            int dan = int.Parse(jmbg.Substring(0, 2));
            int mjesec = int.Parse(jmbg.Substring(2, 2));
            int godina = int.Parse(jmbg.Substring(4, 3)) + 1000;
            if (mjesec!=datum_rodjenja.Month || dan!=datum_rodjenja.Day || godina!=datum_rodjenja.Year)
            return false;
          
           return true;
        }

        bool ValidirajBrojLicneKarte(string broj_licne)
        {
            if (broj_licne.Length != 9) return false;
            int i = 0;
            foreach(char c in broj_licne)
            {
                if (i!=4)
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
        bool ValidirajDatumRodjenja(DateTime datum_rodjenja)
        {
            if (datum_rodjenja > DateTime.Now)
                return false;

            int years = DateTime.Now.Year - datum_rodjenja.Year;
            int months = DateTime.Now.Month - datum_rodjenja.Month;
            int days = DateTime.Now.Day - datum_rodjenja.Day;
            if (years > 18)
                return true;
            else if (years == 18 && months > 0)
                return true;
            else if (years == 18 && months == 0 && days > 0)
                return true;
            return false;
        }
    bool ValidirajAdresu(string adresa)
        {
            if (adresa.Length == 0)
                return false;
            return true;
        }


        bool ValidirajSlova(string naziv)
        {
            //string velikaSlovaIme = naziv.ToUpper();
            //if (velikaSlovaIme.Any(char.IsDigit)) return false;
            //da se provjeri i jesu li i neki spec simboli ..... 

            foreach (char c in naziv)
            {

                //Konvertujem char u string pa string pretvaram u veliak slova pa onda string prebacujem u niz charova sto je u stvari
                //niz sa samo jednim elementom uvijek i pristupam mu onda pomocu indeksa 0 i tako dobijam uvijek veliko slovo

                if (c.ToString().ToUpper().ToCharArray()[0] > 'Z' || c.ToString().ToUpper().ToCharArray()[0] < 'A')
                {
                    return false;
                }
            }
            return true;
        }

      public static bool ValidirajIme(string naziv)
        {
            if (naziv.Length == 0)
                return false;
            //string velikaSlovaIme = naziv.ToUpper();
            //if (velikaSlovaIme.Any(char.IsDigit)) return false;
            //da se provjeri i jesu li i neki spec simboli ..... 
            bool vratiVrijednost = false;
            foreach (char c in naziv)
            {

                //Konvertujem char u string pa string pretvaram u veliak slova pa onda string prebacujem u niz charova sto je u stvari
                //niz sa samo jednim elementom uvijek i pristupam mu onda pomocu indeksa 0 i tako dobijam uvijek veliko slovo

                 
                if (Char.ToUpper(c) <= 'Z' && Char.ToUpper(c) >= 'A' || c == '-')
                    vratiVrijednost = true;
                else
                    return false;

            }
            if (naziv.Length < 2 || naziv.Length > 40)
                vratiVrijednost = false;

            return vratiVrijednost;
        }

        public static bool  ValidirajPrezime(string naziv)
        {
            if (naziv.Length == 0)
                return false;
            //string velikaSlovaIme = naziv.ToUpper();
            //if (velikaSlovaIme.Any(char.IsDigit)) return false;
            //da se provjeri i jesu li i neki spec simboli ..... 
            bool vratiVrijednost = false;
            foreach (char c in naziv)
            {

                //Konvertujem char u string pa string pretvaram u veliak slova pa onda string prebacujem u niz charova sto je u stvari
                //niz sa samo jednim elementom uvijek i pristupam mu onda pomocu indeksa 0 i tako dobijam uvijek veliko slovo

                if (c.ToString().ToUpper().ToCharArray()[0] <= 'Z' && c.ToString().ToUpper().ToCharArray()[0] >= 'A' || c == '-')
                        vratiVrijednost = true;
                else
                    return false;
                
            }
            if (naziv.Length < 3 || naziv.Length > 50)
                vratiVrijednost = false;

            return vratiVrijednost;
        }


        bool ValidirajBrojeve(string naziv)
        {
            foreach (char c in naziv)
            {
                if (c > '9' || c < '0')
                {
                    return false;
                }
            }
            return true;
        }

        bool ValidirajSlovaBrojeve(string licna)
        {
            foreach (char c in licna)
            {
                /* Nije ok ako nije ni slovo ni broj */
                if (!ValidirajSlova(c.ToString()) && !ValidirajBrojeve(c.ToString()))
                {
                    return false;
                }
            }
            return true;
        }

        bool ValidirajJMBG(string jmbg)
        {
            if (jmbg.Length != 13)
            {
                return false;
            }
            foreach (char c in jmbg)
            {
                if (c > '9' || c < '0')
                {
                    return false;
                }
            }
            /* Provjera validnosti mjeseca rodjenja */
            int mjesec = int.Parse(jmbg.Substring(2, 2));
            if (mjesec > 12)
            {
                return false;
            }
            /* Izdvajanje dana i godine rodjenja */
            int dan = int.Parse(jmbg.Substring(0, 2));
            int godina = int.Parse(jmbg.Substring(4, 3)) + 1000;
            if (godina < 1900)
            {
                godina += 1000;
            }
            int[] mjeseci = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            /* Prestupne godine */
            if (godina % 400 == 0 || (godina % 4 == 0 && godina % 100 != 0))
            {
                mjeseci[1]++;
            }
            /* Provjera validnosti dana rodjenja */
            if (dan > mjeseci[mjesec - 1])
            {
                return false;
            }
            
            /* Provjera regije rodjenja - od 10 do 19 Bosna i Hercegovina */
            //if (jmbg[7] != '1') return false;
            /* Provjera kontrolne cifre */
            ///int kontrolna = 11 - ((7 * (jmbg[0] + jmbg[6] - 2 * '0') + 6 * (jmbg[1] + jmbg[7] - 2 * '0') + 5 * (jmbg[2] + jmbg[8] - 2 * '0') + 4 * (jmbg[3] + jmbg[9] - 2 * '0') + 3 * (jmbg[4] + jmbg[10] - 2 * '0') + 2 * (jmbg[5] + jmbg[11] - 2 * '0')) % 11);
            //if (kontrolna > 9) kontrolna = 0;
           // if (jmbg[12] - '0' != kontrolna)
            //{
            //    return false;
           // }
            return true;
        }

        public override string ToString()
        {
            return kod;
        }
    }
}
