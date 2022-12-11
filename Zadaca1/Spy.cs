using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1
{
    public class Spy : IProvjera
    {
        public string Opcija { get; set; }
        public bool DaLiJeVecGlasao(string IDBroj)
        {
            if (Opcija == "Glasao")
                return true;
            else
                return false;
        }
    }
}
