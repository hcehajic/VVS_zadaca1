﻿using System;
using System.Collections.Generic;
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


        public void Glasaj(Glasac trenutni_glasac)
        {
            if (trenutni_glasac.birao)
            {
                Console.WriteLine("Vi ste vec glasali na izborima. Dovidjenja");
                return;
            }

            Console.WriteLine("\nNEZAVISNI KANDIDATI");
            Console.WriteLine("Unesite redni broj kandidata ili 0 ako ne zelite niti za jednog:");
            int brojac = 1;
            foreach (Kandidat k in kandidati)
                if (k.stranka == null)
                    Console.WriteLine(brojac++ + ") " + k.ime_prezime);
        
            int izbor_kandidata = Convert.ToInt32(Console.ReadLine());
            if (izbor_kandidata != 0)
                kandidati[izbor_kandidata - 1].brojGlasova++;

            Console.WriteLine("\nSTRANKE");
            Console.WriteLine("Unesite redni broj stranke ili redni broj stranke i njene kandidate za koje glasate:");
            brojac = 1;
            int brojac_stranaka = 1;
            foreach (Stranka s in stranke)
            {
                Console.WriteLine(brojac_stranaka++ + ") " + s.naziv);
                Console.WriteLine("Kandidati stranke:");
                foreach (Kandidat k in s.clanovi)
                Console.WriteLine(brojac++ + ") " + k.ime_prezime);
                 
                brojac = 1;
                Console.WriteLine("\n");
            }

            var izbor_stranka_clanovi = Console.ReadLine();
            string[] uneseno = izbor_stranka_clanovi.Split(' ', StringSplitOptions.None);

            brojac = 0;
            foreach (Stranka s in stranke)
            {
                brojac++;
                if (brojac == Convert.ToInt32(uneseno[0]) && uneseno.Length == 1)
                {
                    foreach (Kandidat k in kandidati)
                        if (k.stranka != null && k.stranka.Equals(s.naziv))
                        {
                            s.brojGlasova++;
                            k.brojGlasova++;
                        }
                }

                else if (brojac == Convert.ToInt32(uneseno[0]) && uneseno.Length > 1)
                {
                    int brojac_kandidati = 0;
                    int brojac_niz_uneseni = 1;
                    foreach (Kandidat k in kandidati)
                    {
                        brojac_kandidati++;
                        if (k.stranka != null && k.stranka.Equals(s.naziv) && brojac_kandidati == Convert.ToInt32(uneseno[brojac_niz_uneseni]) && brojac_niz_uneseni < uneseno.Length)
                        {
                            k.brojGlasova++;
                            s.brojGlasova++;
                            brojac_niz_uneseni++;
                        }
                    }
                }
            }
            trenutni_glasac.birao = true;

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

            Console.WriteLine("Kandidati koji su osvojili mandat za sada (min 20% glasova stranke) su:");
            brojac_ukupni = 0;

            foreach (Stranka s in stranke)
            {
                foreach (Kandidat k in kandidati)
                {
                    double postotak = ((k.brojGlasova * 1.0) / s.brojGlasova) * 100;
                    if (postotak > 20 && k.stranka.Equals(s.naziv))
                    {
                        brojac_ukupni++;
                        Console.WriteLine("Stranka: " + s.naziv + " Kandidat: " + k.ime_prezime);
                    }
                   
                }
            }
            if (brojac_ukupni == 0)
                Console.WriteLine("Za sada nema takvih");

            Console.WriteLine("ENTER za nastavak...");
            Console.ReadLine();
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

            Console.WriteLine("Unesi datum rodjenja u formatu mjesec/dan/godina : ");
            string datum = Console.ReadLine().Trim(); ;

            Console.WriteLine("Unesi broj licne: ");
            string brojLicne = Console.ReadLine();

            Console.WriteLine("Unesi JMBG: ");
            string jmbg = Console.ReadLine();

            DateTime dt;
            var jel_ok = DateTime.TryParse(datum, out dt);
            Glasac glasac = new Glasac();
            if (jel_ok)
            {
                try
                {
                    glasac = new Glasac(ime, prezime, adresa, dt, brojLicne, jmbg);
                    Console.WriteLine("Vas jedinstveni kod je: " + glasac.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Aplikacija terminirala. Uzrok: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Neispravan datum!");
            }

            return glasac;
        }
    }
}