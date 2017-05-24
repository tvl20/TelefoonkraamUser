using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC
{
    public class Merk
    {
        public string Naam { get; private set; }
        public List<Toestel> Toestellen { get; private set; }

        public Merk(string naam, List<Toestel> toestellen)
        {
            Naam = naam;
            Toestellen = toestellen;
        }

        public List<Toestel> GeefToestellen()
        {
            return Toestellen;
        }

        public List<Product> GeefProducten()
        {
            return Toestellen.SelectMany(toestel => toestel.GeefAlleProducten()).ToList();
        }
    }
}
