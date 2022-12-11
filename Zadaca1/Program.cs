using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Zadaca1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool glasanjeUToku = true;
            /* string datum = "7/20/2000";
             DateTime dt;
             var jel_ok = DateTime.TryParse(datum, out dt);
             Glasac glasac = new Glasac();
             if (jel_ok)
             {
                 try
                 {
                     glasac = new Glasac("Harun", "Cehajic", "Ovdje moze sta hoces jer je adresa", dt, "slova1br0j3v1", "2007000170005");
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

            //HARUN KOD: HaCeOv202020

             Kandidat k1 = new Kandidat("Nezir Nezirovic", "NP");
             Kandidat k2 = new Kandidat("Hamid Hamidovic", "NP");
             Kandidat k3 = new Kandidat("Pero Peric", "Nasa stranka");
             Kandidat k4 = new Kandidat("Ana Anic", "Nasa stranka");
             List<Stranka> stranke = new List<Stranka> { new Stranka("NP", new List<Kandidat> { k1, k2}),
                                                         new Stranka("Nasa stranka", new List<Kandidat> { k3, k4})};
             List<Kandidat> kandidati = new List<Kandidat> { k1, k2, k3, k4, new Kandidat("Nezavisni Kandidat", null), new Kandidat("Nezavisni Kandidatopet", null) };

             List<Glasac> glasaci = new List<Glasac>();
             string datum = "07.20.2000.00:00:00";
             DateTime dt;
             dt = new DateTime(2000, 7, 20, 0, 0, 0);
             Glasac glasac = new Glasac("Harun", "Cehajic", "Ovdje moze sta hoces jer je adresa", dt, "2034K5678", "2007000170005");
             glasaci.Add(glasac);
             glasaci.Add(new Glasac("Neko", "Nekic", "Izmisljena bb", dt, "1234K5678", "2007000170009"));
             glasaci.Add(new Glasac("Ena", "Enic", "Gradacacka bb", dt, "1234K5678", "2007000170009"));

         
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
                 Console.WriteLine("7) Prikazi rezultate glasanja za stranke");
                 Console.WriteLine("8) Proglasi glasanje gotovim");
                 Console.WriteLine("9) Prikazi rukovodstvo stranke");
                 Console.WriteLine("10) Ponistavanje glasova za glasaca");

                int opcija = 10000;
                try
                {
                    opcija = Convert.ToInt32(Console.ReadLine().Trim());
                }
                catch {
                    Console.WriteLine("Nevalidna opcija!");
                    opcija = 1000;
                }
                if (opcija < 1 || opcija > 10) continue;

                if (opcija == 6)
                    break;

                else if (opcija == 1)
                {

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
                else if (opcija == 7)
                {
                    Console.WriteLine(izbori.prikazRezultataIzbora());
                }
                else if (opcija == 8)
                {
                    izbori.GlasanjeUToku = false;
                    glasanjeUToku = false;
                }
                else if (opcija == 9)
                {
                    stranke.ForEach(stranka => Console.WriteLine(stranka.prikazInformacijaORukovodstvu()));
                }
                else if (opcija == 10)
                {
                    int brojac = 3;
                    bool tacanUnos = false;
                    bool naso = false;

                    Glasac trenutni = null;
                    while (brojac != 0 && tacanUnos == false)
                    {
                        Console.WriteLine("Unesite  vas jedinstveni identifikacijski kod:");
                        var sifraGlasaca = Console.ReadLine().Trim();
                        naso = false;
                        foreach (Glasac g in glasaci)
                        {
                            if (g.ToString().Equals(sifraGlasaca))
                            {
                                naso = true;
                                trenutni = g;
                                break;
                            }
                        }

                        if (naso == false)
                        {
                            Console.WriteLine("Pogresan unos! Pokusajte ponovo");
                            brojac--;
                        }
                        else tacanUnos = true; 
                    }

                    if (naso == false)
                    {
                        Console.WriteLine("Pogresan unos 3 puta. Program se zavrsava.");
                        break;
                    }

                    brojac = 2;

                    Console.WriteLine("Za pristup ovoj mogucnosti morate unijeti tajnu sifru za brisanje glasova:");
                    var sifra = Console.ReadLine();
                    while (brojac != 0 && izbori.ProvjeriUnesenuTajnuSifru(sifra) == false)
                    {
                        Console.WriteLine("Za pristup ovoj mogucnosti morate unijeti tajnu administratorsku sifru za brisanje glasova:");
                        sifra = Console.ReadLine();
                    }

                    if (brojac == 0)
                    {
                        Console.WriteLine("Pogresan unos 3 puta. Program se zavrsava.");
                        break;
                    }
                    
                    izbori.IzbrisiGlasoveZaGlasaca(trenutni);
                }
            }
        }
    }
}
