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

        public override bool Equals(object obj)
        {
            if (!(obj is Categorie))
            {
                return false;
            }
            Categorie otherCategorie = (Categorie) obj;
            return Naam.Equals(otherCategorie.Naam);
        }

        public override string ToString()
        {
            return Naam;
        }
    }
}
