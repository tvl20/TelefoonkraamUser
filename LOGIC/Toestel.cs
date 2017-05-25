using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC
{
    public class Toestel
    {
        public string Naam { get; private set; }
        public List<Product> Producten { get; private set; }
        public string Afbeelding { get; private set; }

        public Toestel(string naam, List<Product> producten, string afbeelding)
        {
            Naam = naam;
            Producten = producten;
            Afbeelding = afbeelding;
        }

        public List<Product> GeefAlleProducten()
        {
            return Producten;
        }

        public override string ToString()
        {
            return Naam;
        }
    }
}
