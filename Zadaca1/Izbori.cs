using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Zadaca1
{
    public class Izbori
    {
        private List<Stranka> stranke;
        private List<Kandidat> kandidati;
        private List<Glasac> glasaci;
        private int ukupno_glasova_na_izborima = 0;
        private Boolean glasanjeUToku;

        public Boolean GlasanjeUToku
        {
            get { return glasanjeUToku; }
            set { glasanjeUToku = value; }
        }

        public int Ukupno_glasova_na_izborima
        {
            get { return ukupno_glasova_na_izborima; }
            set { ukupno_glasova_na_izborima = value; }
        }

        public List<Stranka> Stranke { get => stranke; set => stranke = value; }
        public List<Kandidat> Kandidati { get => kandidati; set => kandidati = value; }
        public List<Glasac> Glasaci { get => glasaci; set => glasaci = value; }

        public Izbori() { }
        public Izbori(List<Stranka> stranke, List<Kandidat> kandidati, List<Glasac> glasaci)
        {
            this.stranke = stranke;
            this.glasaci = glasaci;
            this.kandidati = kandidati;
        }

        private void ispisiKandidate()
        {
            int brojac = 1;
            foreach (Kandidat k in kandidati.FindAll(k => k.Stranka == null))
                Console.WriteLine(brojac++ + ") " + k.Ime_prezime);
        }

        private void ispisiStranke()
        {
            int brojac = 1, brojac_stranaka = 1;
            foreach (Stranka s in stranke)
            {
                Console.WriteLine(brojac_stranaka++ + ") " + s.naziv);
                Console.WriteLine("Kandidati stranke:");
                s.clanovi.ForEach(k => Console.WriteLine(brojac++ + ") " + k.Ime_prezime));
                brojac = 1;
                Console.WriteLine("\n");
            }
        }

        private void projveriInformacijeZaKandidate(Stranka s ,ref string[] uneseno, ref int brojac_kandidati, ref int brojac_niz_uneseni, ref List<Kandidat> kandidati)
        {
            foreach (Kandidat k in kandidati)
            {
                if (uneseno.Length > 1 && k.Stranka != null && k.Stranka.Equals(s.naziv) && brojac_kandidati == Convert.ToInt32(uneseno[brojac_niz_uneseni]) && brojac_niz_uneseni < uneseno.Length)
                {
                    brojac_niz_uneseni++;
                    k.BrojGlasova += 1;
                    s.brojGlasova += 1;
                }
                else if (uneseno.Length == 1 && k.Stranka != null && k.Stranka.Equals(s.naziv))
                {
                    k.BrojGlasova += 1;
                    s.brojGlasova += 1;
                }
            }
        }

        public void Glasaj(Glasac trenutni_glasac)
        {
            if (trenutni_glasac.birao)
            {
                Console.WriteLine("Vi ste vec glasali na izborima. Dovidjenja");
                return;
            }

            Console.WriteLine("\nNEZAVISNI KANDIDATI \nUnesite redni broj kandidata ili 0 ako ne zelite niti za jednog:");
            ispisiKandidate();

            int izbor_kandidata = Convert.ToInt32(Console.ReadLine());
            trenutni_glasac.Glaso.Add(izbor_kandidata);
            if (izbor_kandidata != 0)
                kandidati[izbor_kandidata - 1].BrojGlasova += 1;

            Console.WriteLine("\nSTRANKE \nUnesite redni broj stranke ili redni broj stranke i njene kandidate za koje glasate(Svaki broj razdvojite razmakom):");
            ispisiStranke();

            var izbor_stranka_clanovi = Console.ReadLine();
            string[] uneseno = izbor_stranka_clanovi.Split(' ', StringSplitOptions.None);

            for (int i = 0; i < uneseno.Length; i++)
                trenutni_glasac.Glaso.Add(Convert.ToInt32(uneseno[i]));


            int brojac = 0;
            foreach (Stranka s in stranke)
            {
                brojac++;
                if (brojac == Convert.ToInt32(uneseno[0]))
                {
                    int brojac_kandidati = 0;
                    int brojac_niz_uneseni = 1;
                    projveriInformacijeZaKandidate(s, ref uneseno, ref brojac_kandidati, ref brojac_niz_uneseni, ref kandidati);
                }
            }

            trenutni_glasac.birao = true;
            Console.WriteLine("ENTER za nastavak...");
            Console.ReadLine();
        }

        /*
        public void Glasaj(Glasac trenutni_glasac)
        {
            if (trenutni_glasac.birao)
            {
                Console.WriteLine("Vi ste vec glasali na izborima. Dovidjenja");
                return;
            }

            Console.WriteLine("\nNEZAVISNI KANDIDATI \nUnesite redni broj kandidata ili 0 ako ne zelite niti za jednog:");
            ispisiKandidate();

            int izbor_kandidata = Convert.ToInt32(Console.ReadLine());
            trenutni_glasac.Glaso.Add(izbor_kandidata);
            if (izbor_kandidata != 0)
                kandidati[izbor_kandidata - 1].BrojGlasova += 1;

            Console.WriteLine("\nSTRANKE \nUnesite redni broj stranke ili redni broj stranke i njene kandidate za koje glasate(Svaki broj razdvojite razmakom):");
            ispisiStranke();

            var izbor_stranka_clanovi = Console.ReadLine();
            string[] uneseno = izbor_stranka_clanovi.Split(' ', StringSplitOptions.None);

            for (int i = 0; i < uneseno.Length; i++)
              trenutni_glasac.Glaso.Add(Convert.ToInt32(uneseno[i]));
            
            
            int brojac = 0;
            foreach (Stranka s in stranke)
            {
                brojac++;
                if (brojac == Convert.ToInt32(uneseno[0]))
                {
                        int brojac_kandidati = 0;
                        int brojac_niz_uneseni = 1;
                    
                    foreach (Kandidat k in kandidati)
                    {
                        if (uneseno.Length > 1 && k.Stranka != null && k.Stranka.Equals(s.naziv) && brojac_kandidati == Convert.ToInt32(uneseno[brojac_niz_uneseni]) && brojac_niz_uneseni < uneseno.Length)
                        {
                            brojac_niz_uneseni++;
                            k.BrojGlasova += 1;
                            s.brojGlasova += 1;
                        }
                        else if (uneseno.Length==1 && k.Stranka != null && k.Stranka.Equals(s.naziv))
                        {
                            k.BrojGlasova += 1;
                            s.brojGlasova += 1;
                        }
                    }
                }
            }

            trenutni_glasac.birao = true;
            Console.WriteLine("ENTER za nastavak...");
            Console.ReadLine();
        }
        */


        /*
         * Metoda ispod ovog komentara je ista metoda kao i iznad komentara samo što su ispravljene foreach petlje 
         * u obicne for petlje radi dobijanja kontrolnog grafa kompleksnosti na online alatu. 
         * NAPOMENA: METODA ISPOD SE NEĆE KORISTITI U GLAVNOM PROGRAMU, ONA JE SAMO DA BI SE URADIO DIO ZADAĆE 4
         * 
         * 
        

#include <string>
#include <vector>
#include <iostream>
#include <memory>



void Glasaj(std::shared_ptr<Glasac> trenutni_glasac)
{
			if (trenutni_glasac->birao)
			{
				std::wcout << L"Vi ste vec glasali na izborima. Dovidjenja" << std::endl;
				return;
			}

			std::wcout << L"\nNEZAVISNI KANDIDATI \nUnesite redni broj kandidata ili 0 ako ne zelite niti za jednog:" << std::endl;
			ispisiKandidate();

			int izbor_kandidata = std::stoi(Console::ReadLine());
			trenutni_glasac->Glaso->Add(izbor_kandidata);
			if (izbor_kandidata != 0)
			{
				kandidati[izbor_kandidata - 1].BrojGlasova += 1;
			}

			std::wcout << L"\nSTRANKE \nUnesite redni broj stranke ili redni broj stranke i njene kandidate za koje glasate(Svaki broj razdvojite razmakom):" << std::endl;
			ispisiStranke();

			std::wstring izbor_stranka_clanovi;
			std::getline(std::wcin, izbor_stranka_clanovi);
			std::vector<std::wstring> uneseno = izbor_stranka_clanovi.Split(L' ', StringSplitOptions::None);

			for (int i = 0; i < uneseno.size(); i++)
			{
				trenutni_glasac->Glaso->Add(std::stoi(uneseno[i]));
			}


			int brojac = 0;
			for (std::shared_ptr<Stranka> s : stranke)
			{
				brojac++;
				if (brojac == std::stoi(uneseno[0]))
				{
					int brojac_kandidati = 0;
					int brojac_niz_uneseni = 1;
					projveriInformacijeZaKandidate(s, uneseno, brojac_kandidati, brojac_niz_uneseni, kandidati);
				}
			}

			trenutni_glasac->birao = true;
			std::wcout << L"ENTER za nastavak..." << std::endl;
			std::wstring tempVar;
			std::getline(std::wcin, tempVar);
}

			*/




        public void ispisStranakaIKandidata()
        {
            int brojac_ukupni = 0;
            Console.WriteLine("Kandidati koji su osvojili mandat za sada (min 20% glasova stranke) su:");

            foreach (Stranka s in stranke)
            {
                foreach (Kandidat k in kandidati)
                {
                    double postotak = ((k.BrojGlasova * 1.0) / s.brojGlasova) * 100;
                    if (postotak > 20 && k.Stranka.Equals(s.naziv))
                    {
                        brojac_ukupni++;
                        Console.WriteLine("Stranka: " + s.naziv + " Kandidat: " + k.Ime_prezime);
                    }

                }
            }
            if (brojac_ukupni == 0)
                Console.WriteLine("Za sada nema takvih");

            Console.WriteLine("ENTER za nastavak...");
            Console.ReadLine();
        }


        public void TrenutnoStanje()
        {
            int izlaznost = 0;
            foreach (Glasac g in glasaci)
                if (g.birao == true) izlaznost++;

            Console.WriteLine("\nBroj mogucih glasaca je " + glasaci.Count + ", od kojih je glasalo " + izlaznost + ", sto je ukupno " + ((izlaznost * 1.0) / glasaci.Count) * 100 + "%.");
            Console.WriteLine("Stranke koje su osvojile mandate za sada (min 2% glasova) su: ");
            int brojac_ukupni = 0;
            foreach (Stranka s in stranke)
            {
                if ((s.brojGlasova * 1.0) / ukupno_glasova_na_izborima >= 2)
                {
                    brojac_ukupni++;
                    Console.WriteLine(s.naziv);
                }
            }
            if (brojac_ukupni == 0)
                Console.WriteLine("Za sada nema takvih");
            ispisStranakaIKandidata();

            /*
            Console.WriteLine("Kandidati koji su osvojili mandat za sada (min 20% glasova stranke) su:");
            brojac_ukupni = 0;

            foreach (Stranka s in stranke)
            {
                foreach (Kandidat k in kandidati)
                {
                    double postotak = ((k.BrojGlasova * 1.0) / s.brojGlasova) * 100;
                    if (postotak > 20 && k.Stranka.Equals(s.naziv))
                    {
                        brojac_ukupni++;
                        Console.WriteLine("Stranka: " + s.naziv + " Kandidat: " + k.Ime_prezime);
                    }
                   
                }
            }
            if (brojac_ukupni == 0)
                Console.WriteLine("Za sada nema takvih");

            Console.WriteLine("ENTER za nastavak...");
            Console.ReadLine();
            */
        }

        public void GlasaciNaIzborima()
        {
            Console.WriteLine("Glasaci na ovim izborima su do sada: ");
            int ukupni_brojac = 0;
            foreach (Glasac gl in glasaci)
            {
                if (gl.birao)
                {
                    ukupni_brojac++;
                    Console.WriteLine(gl.ToString());
                }
            }
            if (ukupni_brojac == 0)
                Console.WriteLine("Za sada jos niko nije glasao");
           ukupno_glasova_na_izborima = ukupni_brojac;

           Console.WriteLine("ENTER za nastavak...");
           Console.ReadLine();
        }

        public void GlasaciKojiNisuGlasali()
        {
            Console.WriteLine("Glasaci koji nisu glasali jos uvijek na izborima: ");
            int ukupni_brojac = 0;
            foreach (Glasac gl in glasaci)
            {
                if (!gl.birao)
                {
                    ukupni_brojac++;
                    Console.WriteLine(gl.ToString());
                }
            }
            if (ukupni_brojac == 0)
                Console.WriteLine("Svi glasaci su glasali na ovim izborima");

            Console.WriteLine("ENTER za nastavak...");
            Console.ReadLine();
        }

        public Glasac DodajGlasaca()
        {
            Console.WriteLine("\nDodavanje novog glasaca");
            Console.WriteLine("Unesi ime: ");
            string ime = Console.ReadLine().Trim();

            Console.WriteLine("Unesi prezime: ");
            string prezime = Console.ReadLine().Trim();

            Console.WriteLine("Unesi adresu: ");
            string adresa = Console.ReadLine().Trim();

            Console.WriteLine("Unesi datum rodjenja u formatu dd/mm/yyyy : ");
            string datum = Console.ReadLine().Trim(); ;

            Console.WriteLine("Unesi broj licne: ");
            string brojLicne = Console.ReadLine();

            Console.WriteLine("Unesi JMBG: ");
            string jmbg = Console.ReadLine();

            DateTime dt = DateTime.ParseExact(datum, "dd/MM/yyyy", CultureInfo.CurrentCulture);
            Glasac glasac = new Glasac();
            
                try
                {

                    glasac = new Glasac(ime, prezime, adresa, dt, brojLicne, jmbg);
                Console.WriteLine("Uspjesan unos novog glasaca! Sada Vas odjavljujemo sa sistema.");
                Console.WriteLine("Vas jedinstveni kod je: " + glasac.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Aplikacija terminirala. Uzrok: " + ex.Message);
                }
            return glasac;
        }
        /**
         * author: ahajro2
         * param: none
         * prikaz trenutnih rezultata izbora u bilo kojem trenutku, tako da nije potrebno prekinuti proces za 
         * ovu funkcionalnost
         * Dodatno: napisati testove!!!d
         */
        public string prikazRezultataIzbora()
        {
            if (ukupno_glasova_na_izborima == 0) return "Nema glasova još uvijek";
            string rezultatIzbora = "";
            
            stranke.ForEach(stranka =>
            {       
                rezultatIzbora += "Broj glasova za stranku: " + stranka.brojGlasova + "\n";
                rezultatIzbora += "Postotak od ukupnog broja glasova: " + 
                Math.Round((stranka.brojGlasova / (double)ukupno_glasova_na_izborima) * 100) + "% \n";

                //dodati uslov ukoliko je kraj glasanja a pozove se ova metoda da se ispise broj mandata za svaku stranku
                if(!GlasanjeUToku)
                {
                    int brojOsvojenihMandata = 0;
                    rezultatIzbora += "Kandidati koji su osvojili mandate: \n";
                    //dodajemo i clanove  i rukovodstvo jer se cuvaju u zasebnim listama

                    List<Kandidat> listaKandidata = stranka.clanovi;
                    List<Kandidat> listaKandidataRukovodstva = stranka.rukovodstvoStranke;

                    //moralo se odvojiti u 2 forEach jer nije radilo drugacije
                    listaKandidata.ForEach(kandidat =>
                    {
                        double postotak = Math.Round((kandidat.BrojGlasova / (double)stranka.brojGlasova) * 100);
                        if(postotak > 20)
                        {
                            brojOsvojenihMandata++;
                            rezultatIzbora += kandidat.Ime_prezime + " osvojio je: " + postotak + "% glasova\n";
                        }
                    });

                    listaKandidataRukovodstva.ForEach(kandidat =>
                    {
                        double postotak = Math.Round((kandidat.BrojGlasova / (double)stranka.brojGlasova) * 100);
                        if (postotak > 20)
                        {
                            brojOsvojenihMandata++;
                            rezultatIzbora += kandidat.Ime_prezime + " osvojio je: " + postotak + "% glasova\n";
                        }
                    });

                    rezultatIzbora += "Ukupan broj osvojenih mandata stranke " + stranka.naziv + " je " + brojOsvojenihMandata;
                } 
                else
                {
                    rezultatIzbora += "GLASANJE JE JOŠ UVIJEK U TOKU!";
                }
            });

            return rezultatIzbora;
        }

        /*
         * 
         * Autor: Harun Cehajic
         * 
         */
        public void IzbrisiGlasoveZaGlasaca(Glasac g)
        {

            if (!g.birao)
            {
                throw new Exception("Glasac nije glasao!");
            }

            // smanjenje broja glasova za nezavisne kandidate
            int brojac = 1;
            foreach(Kandidat k in Kandidati)
            {
                if (k.Stranka == null)
                {
                    if (brojac == g.Glaso[0])
                    {
                        Console.WriteLine("Brisem glasove kandidatu: " + k.Ime_prezime);
                        k.BrojGlasova--;
                        break;
                    }
                    brojac++;
                }
            }

            // ukoliko je glasao samo za stranku
            if (g.Glaso.Count < 3)
            {
                // smanjivanje broja glasova za stranku i sve njene clanove
                for (int i = 0; i < Kandidati.Count; i++)
                {
                    if (Kandidati[i].Stranka == Stranke[g.Glaso[1] - 1].naziv && Kandidati[i].Stranka != null)
                    {
                        Console.WriteLine("Brisem glasove za kandidata: " + Kandidati[i].Ime_prezime);
                        Console.WriteLine("Brisem glasove stranki: " + Stranke[g.Glaso[1] - 1].naziv);
                        Kandidati[i].BrojGlasova--;
                        Stranke[g.Glaso[1] - 1].brojGlasova--;
                    }
                }
            }
            else
            {
                List<Kandidat> obrisano = new List<Kandidat>();
                for (int i = g.Glaso[2]; i < g.Glaso.Count; i++)
                {
                    int broj = 1;
                    for (int j = 0; j < Kandidati.Count; j++)
                    {
                        var kan = obrisano.Find(k => k.Ime_prezime.Equals(kandidati[j].Ime_prezime));
                        if (kandidati[j].Stranka == stranke[g.Glaso[1] - 1].naziv && Kandidati[j].Stranka != null && kan == null)
                        {
                            if (broj == g.Glaso[i])
                            {
                                obrisano.Add(kandidati[j]);
                                Kandidati[j].BrojGlasova--;
                                Stranke[g.Glaso[1] - 1].brojGlasova--;
                            }
                            broj++;
                        }
                    }
                }          
            }
               
            g.birao = false;
            Console.WriteLine("Uspjesno obrisani glasovi glasacu!");
        }

        /*
         * 
         * Autor: Harun Cehajic
         * 
         */
        public bool ProvjeriUnesenuTajnuSifru(string sifra)
        {
            string tajniKod = "VVS20222023";

            if (sifra != tajniKod)
            {
                return false;
            }

            return true;
        }
    }
}
