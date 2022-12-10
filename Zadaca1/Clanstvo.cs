using System;
using System.Collections.Generic;

/**
 * author: enuhanovic1
 * funkcionalnost: 2.
 * klasa cuva podatke o clanstvu kandidata u stranci
 * Dodatno: napisati testove!!!
 */
namespace Zadaca1
{
	public class Clanstvo
	{
		private string stranka { get; set; }
		private DateTime pocetak { get; set; }
		private DateTime kraj { get; set; }
		public Clanstvo() { }
		public Clanstvo(string stranka, DateTime pocetak, DateTime kraj)
		{
			this.stranka = stranka;
			this.pocetak = pocetak;
			this.kraj = kraj;
		}
		public string prikaziClanstvo()
		{
			return "Stranka: " + stranka + ", Clanstvo od: " + pocetak.Day + "." + pocetak.Month + "." + pocetak.Year +
				", Clanstvo do: " + kraj.Day + "." + kraj.Month + "." + kraj.Year + "\n";
		}
		public string Stranka
        {
            get { return stranka; }
            set
            {
                stranka = value;
            }
        }
		public DateTime Pocetak
        {
            get { return pocetak; }
            set
            {
                pocetak = value;
            }
        }
		public DateTime Kraj
        {
            get { return kraj; }
            set
            {
                kraj = value;
            }
        }
	}
}
