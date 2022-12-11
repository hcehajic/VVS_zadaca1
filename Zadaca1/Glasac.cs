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
         * 
         * Rijeseni geteri, seteri, validacije i dodani regioni
         * Funkcionalnost 1
         * 
         * Autor promjena: Almina Brulic
         * 
         */

        #region Atributes
        private string ime;
        private string prezime;
        private string adresa;
        private DateTime datum_rodjenja;
        private string broj_licne;
        private string jmbg;
        private string kod;
        private List<int> glaso;
        #endregion

        #region Properties


        public List<int> Glaso
        {
            get
            {
                return glaso;
            }

            set
            {
                glaso = value;
            }
        }

        public string Ime
        {
            get { return ime; }
            set
            {
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

        public string Adresa
        {
            get { return adresa; }
            set
            {
                if (!ValidirajAdresu(value))
                    throw new ArgumentException("Neispravna adresa");
                else adresa = value;
            }
        }

        public DateTime DatumRodjenja
        {
            get { return datum_rodjenja; }
            set
            {
                if (!ValidirajDatumRodjenja(value))
                    throw new ArgumentException("Neispravan datum rodjenja");
                else datum_rodjenja = value;
            }
        }

        public string BrojLicneKarte
        {
            get
            {
                return broj_licne;
            }
            set
            {
                if (ValidirajBrojLicneKarte(value))
                    broj_licne = value;
                else throw new ArgumentException("Neispravan broj licne karte");
            }
        }

        public string JMBG
        {
            get { return jmbg; }
            set
            {
                if (ValidirajJMBG(value, datum_rodjenja))
                    jmbg = value;
                else throw new ArgumentException("Neispravan JMBG");
            }
        }
        public bool birao { get; set; }
        #endregion

        #region Constructors
        public Glasac() { glaso = new List<int>(); }

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
            glaso = new List<int>();
        }
        #endregion

        #region Methods
        private void KreirajJedinstveniKod()
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
            if (!ValidirajJMBG(jmbg, datum_rodjenja))
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

        /*
        public bool ValidirajJedinstveniKod(string kod)
        {
            if (kod.Length != 12) return false;
            int dan = int.Parse(jmbg.Substring(0, 2));
            int mjesec = int.Parse(jmbg.Substring(2, 2));
            int godina = int.Parse(jmbg.Substring(4, 3)) + 1000;
            if (mjesec!=datum_rodjenja.Month || dan!=datum_rodjenja.Day || godina!=datum_rodjenja.Year)
            return false;
          
           return true;
        }*/

        public bool ValidirajJedinstveniKod(string kod)
        {
            if (kod.Length != 12) return false;
            if (kod.Substring(0, 2) != this.Ime.Substring(0, 2) || kod.Substring(2, 2) != this.Prezime.Substring(0, 2) || this.Adresa.Substring(0, 2) != kod.Substring(4, 2)) return false;
            string dan = "";
            if (datum_rodjenja.Day < 10)
            {
                dan = "0";
            }
            dan = dan + datum_rodjenja.Day.ToString();
            if (dan != kod.Substring(6, 2) || kod.Substring(8, 2) != this.JMBG.Substring(0, 2) || kod.Substring(10, 2) != this.BrojLicneKarte.Substring(0, 2)) return false;
            return true;
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
        public static bool ValidirajDatumRodjenja(DateTime datum_rodjenja)
        {
            //glasac mora biti punoljetan, zbog toga smo stavili da ovdje ide i ta validacija. U suprotnom, nije glasac
            if (datum_rodjenja > DateTime.Now)
                return false;

            int years = DateTime.Now.Year - datum_rodjenja.Year;
            int months = DateTime.Now.Month - datum_rodjenja.Month;
            int days = DateTime.Now.Day - datum_rodjenja.Day;
            if (years > 18)
                return true;
            if (years == 18 && months > 0)
                return true;
            if (years == 18 && months == 0 && days > 0)
                return true;
            return false;
        }
        public static bool ValidirajAdresu(string adresa)
        {
            if (adresa.Length == 0)
                return false;
            return true;
        }

        public static bool ValidirajIme(string naziv)
        {
            if (naziv.Length == 0)
                return false;
            bool vratiVrijednost = false;
            foreach (char c in naziv)
            {
                if (Char.ToUpper(c) <= 'Z' && Char.ToUpper(c) >= 'A' || c == '-')
                    vratiVrijednost = true;
                else
                    return false;
            }
            if (naziv.Length < 2 || naziv.Length > 40)
                vratiVrijednost = false;

            return vratiVrijednost;
        }

        public static bool ValidirajPrezime(string naziv)
        {
            if (naziv.Length == 0)
                return false;
            bool vratiVrijednost = false;
            foreach (char c in naziv)
            {
                if (c.ToString().ToUpper().ToCharArray()[0] <= 'Z' && c.ToString().ToUpper().ToCharArray()[0] >= 'A' || c == '-')
                    vratiVrijednost = true;
                else
                    return false;
            }
            if (naziv.Length < 3 || naziv.Length > 50)
                vratiVrijednost = false;

            return vratiVrijednost;
        }

        public static bool ValidirajJMBG(string jmbg, DateTime datum_rodjenja)
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
            int dan = int.Parse(jmbg.Substring(0, 2));
            int mjesec = int.Parse(jmbg.Substring(2, 2));
            int godina = int.Parse(jmbg.Substring(4, 3)) + 1000;
            if (godina < 1900)
            {
                godina += 1000;
            }
            if (dan != datum_rodjenja.Day || mjesec != datum_rodjenja.Month || godina != datum_rodjenja.Year) return false;
            return true;
        }

        public override string ToString()
        {
            return kod;
        }
        #endregion


        public string IdentifikacijskiBroj { get; set; }
        public bool VjerodostojnostGlasaca(IProvjera sigurnosnaProvjera)
        {
            if (sigurnosnaProvjera.DaLiJeVecGlasao(IdentifikacijskiBroj))
                throw new Exception("Glasač je već izvršio glasanje!");
            return true;
        }

    }
}
