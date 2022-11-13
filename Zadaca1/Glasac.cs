using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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

        public bool birao { get; set; }

        public Glasac() { }

        public Glasac(string ime, string prezime, string adresa, DateTime datum_rodjenja, string broj_licne, string jmbg)
        {
            ValidirajUnos(ime, prezime, broj_licne, jmbg);
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

    
        void ValidirajUnos(string ime, string prezime, string broj_licne, string jmbg)
        {
            if (!ValidirajSlova(ime))
            {
                throw new ArgumentException("Neispravno ime!");
            }
            if (!ValidirajSlova(prezime))
            {
                throw new ArgumentException("Neispravno prezime!");
            }
            if (!ValidirajSlovaBrojeve(broj_licne))
            {
                throw new ArgumentException("Neispravan broj licne!");
            }
            if (!ValidirajBrojeve(jmbg))
            {
                throw new ArgumentException("Neispravan JMBG!");
            }
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

        bool ValidirajBrojeve(string jmbg)
        {
            foreach (char c in jmbg)
            {
                if (c > '9' || c < '0')
                {
                    return false;
                }
            }
            return true;
        }

        public override string ToString()
        {
            return kod;
        }
    }
}
