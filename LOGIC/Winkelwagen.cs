using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC
{
    public class Winkelwagen
    {
        public List<Product> Producten { get; private set; }
        public Kortingscode Kortingscode { get; private set; }

        public Winkelwagen()
        {
            Producten = new List<Product>();
        }

        public void VoegProductToe(Product product)
        {
            Producten.Add(product);
        }

        public bool VerwijderProduct(Product product)
        {
            return Producten.Remove(product);
        }

        public void GebruikKortingsCode(Kortingscode kortingscode)
        {
            Kortingscode = kortingscode;
        }

        public Bestelling BestelProducten(string klantNaam, string klantEmailadres, string klantAdresLand,
            string klantAdresPostcode, string klantAdresPlaatsnaam, string klantAdresStraatnaam,
            string klantAdresHuisnummer, string klantTelefoonnummer)
        {
            Bestelling bestelling = new Bestelling(Producten, Kortingscode, klantNaam, klantEmailadres, klantAdresLand,
            klantAdresPostcode, klantAdresPlaatsnaam, klantAdresStraatnaam,
            klantAdresHuisnummer, klantTelefoonnummer);
            return bestelling;
        }
    }
}
