using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC
{
    public class Categorie
    {
        public string Naam { get; private set; }

        public Categorie(string naam)
        {
            Naam = naam;
        }

        public override string ToString()
        {
            return Naam;
        }
    }
}
