using System;
using System.Collections.Generic;

namespace Zadaca1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*string datum = "7/20/2000";
            DateTime dt;
            var jel_ok = DateTime.TryParse(datum, out dt);
            Glasac glasac = new Glasac();
            if (jel_ok)
            {
                try
                {
                    glasac = new Glasac("Harun", "Cehaljic", "Ovdje moze sta hoces jer je adresa", dt, "slova1br0j3v1", "2007000170005");
                    Console.WriteLine("Jedinstveni kod test: " + glasac.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Aplikacija terminirala. Uzrok: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Nije ti dobar datum!");
            }*/

            //HARUN KOD: HaCeOv20sl20

            Kandidat k1 = new Kandidat("Nezir Nezirovic", "NP");
            Kandidat k2 = new Kandidat("Hamid Hamidovic", "NP");
            Kandidat k3 = new Kandidat("Pero Peric", "Nasa stranka");
            Kandidat k4 = new Kandidat("Ana Anic", "Nasa stranka");
            List<Stranka> stranke = new List<Stranka> { new Stranka("NP", new List<Kandidat> { k1, k2}),
                                                        new Stranka("Nasa stranka", new List<Kandidat> { k3, k4})};
            List<Kandidat> kandidati = new List<Kandidat> { k1, k2, k3, k4, new Kandidat("Nezavisni Kandidat", null), new Kandidat("Nezavisni Kandidatopet", null) };

            List<Glasac> glasaci = new List<Glasac>();
            string datum = "7/20/2000";
            DateTime dt;
            var jel_ok = DateTime.TryParse(datum, out dt);
            Glasac glasac = new Glasac("Harun", "Cehaljic", "Ovdje moze sta hoces jer je adresa", dt, "slova1br0j3v1", "2007000170005");
            glasaci.Add(glasac);
            glasaci.Add(new Glasac("Neko", "Nekic", "Izmisljena bb", DateTime.Now.AddYears(-18), "11882233ab", "1111001170005"));
            glasaci.Add(new Glasac("Ena", "Enic", "Gradacacka bb", DateTime.Now.AddYears(-25), "1234ab445vh", "1345567895"));

            Izbori izbori = new Izbori(stranke, kandidati, glasaci);

            bool unesen = false;
            string kod = null;
            Glasac trenutniGlasac = new Glasac();


            bool pronadjen = false;
            while (true)
            {
                Console.WriteLine("\nOdaberite jednu od opcija(unos broja ispred opcije): ");
                Console.WriteLine("1) Glasanje");
                Console.WriteLine("2) Trenutno stanje izbornih rezultata");
                Console.WriteLine("3) Prikaz glasaca koji su glasali");
                Console.WriteLine("4) Unos novog glasaca");
                Console.WriteLine("5) Prikazi glasace koji nisu glasali");
                Console.WriteLine("6) Zavrsi glasanje i zatvori aplikaciju");

                int opcija = Convert.ToInt32(Console.ReadLine().Trim());

                if (opcija == 6)
                    break;

                else if (opcija == 1) {

                    while (true)
                    {
                        Console.WriteLine("Da biste pristupili izborima molimo unesite Vas jedinstveni kod(Unesite -1 za prekid): ");
                        var unos = Console.ReadLine();
                        var pkod = unos.Split()[0];
                        if (unos.Equals("-1"))
                        {
                            pronadjen = false;
                            break;
                        }
                        foreach (Glasac g in glasaci)
                        {
                            if (g.ToString().Equals(pkod))
                            {
                                pronadjen = true;
                                kod = pkod;
                                unesen = true;
                                pkod = "";
                                trenutniGlasac = g;
                                break;
                            }
                        }
                        if (unesen)
                        {
                            Console.WriteLine("Prijavljen glasac: " + trenutniGlasac.ToString());
                            izbori.Glasaj(trenutniGlasac);
                            break;
                        }
                        if (!pronadjen)
                        {
                            Console.WriteLine("Neispravan jedinstveni kod!");
                        }
                    }
                    if (pronadjen)
                        izbori.Glasaj(trenutniGlasac);
                }
                else if (opcija == 2)
                    izbori.TrenutnoStanje();

                else if (opcija == 3)
                    izbori.GlasaciNaIzborima();

                else if (opcija == 4)
                {
                    Console.WriteLine("Unos novih glasaca mora biti obavljen od strane sluzbene komisije. " +
                        "Unesite identifikacioni broj vase komisije: ");
                    string idBroj = Console.ReadLine();
                    if (idBroj.Equals("CIK"))
                    {
                        Glasac gl = izbori.DodajGlasaca();
                        if (gl != null)
                        {
                            glasaci.Add(gl);
                            Console.WriteLine("Uspjesan unos novog glasaca! Sada Vas odjavljujemo sa sistema.");
                            kod = "";
                            pronadjen = false;
                            unesen = false;
                            trenutniGlasac = null;
                            Console.WriteLine("ENTER za nastavak...");
                            Console.ReadLine();
                        }
                        else
                            Console.WriteLine("Nemoguce dodati glasaca.");
                    }
                }

                else if (opcija == 5)
                {
                    izbori.GlasaciKojiNisuGlasali();
                }

            }
        }
    }
}
