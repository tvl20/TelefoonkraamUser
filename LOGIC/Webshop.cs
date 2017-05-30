using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LOGIC
{
    public class Webshop
    {
        private IKlantData KlantData { get; set; }
        public List<Product> Producten { get; private set; }
        public List<Toestel> Toestellen { get; private set; }
        public List<Merk> Merken { get; private set; }
        public List<Categorie> Categorieën { get; private set; }
        public List<Bestelling> Bestellingen { get; private set; }
        public Kortingscode Kortingscode { get; private set; }
        public Winkelwagen Winkelwagen { get; private set; }

        public Webshop(IKlantData klantData, List<Product> producten, List<Toestel> toestellen, List<Merk> merken,
            List<Categorie> categorieën, List<Bestelling> bestellingen, Kortingscode kortingscode,
            Winkelwagen winkelwagen)
        {
            KlantData = klantData;
            Producten = producten;
            Toestellen = toestellen;
            Merken = merken;
            Categorieën = categorieën;
            Bestellingen = bestellingen;
            Kortingscode = kortingscode;
            Winkelwagen = winkelwagen;
        }

        public bool BestelWinkelmandje(string kortingscode, string klantNaam, string klantEmailadres,
            string klantAdresLand, string klantAdresPostcode, string klantAdresPlaatsnaam, string klantAdresStraatnaam,
            string klantAdresHuisnummer, string klantTelefoonnummer)
        {
            Kortingscode valideKortingscode = null;
            if (kortingscode != null)
            {
                try
                {
                    valideKortingscode = KlantData.ControleerKortingsCode(kortingscode);
                }
                catch
                {
                    //ToDo: Exception handling
                }
            }
            List<Product> besteldeProducten = Winkelwagen.Producten;
            Bestelling bestelling = new Bestelling(besteldeProducten, valideKortingscode, klantNaam, klantEmailadres, klantAdresLand, klantAdresPostcode, klantAdresPlaatsnaam, klantAdresStraatnaam, klantAdresHuisnummer, klantTelefoonnummer);
            int bestelnummer = KlantData.BestellingVerzenden(bestelling);
            bestelling.SetBestelNummer(bestelnummer);
            return VerzendBestelBevestiging(bestelling);

        }

        public bool VerzendBestelBevestiging(Bestelling bestelling)
        {
            throw new NotImplementedException();
        }

        public List<Product> ZoekProduct(string zoekterm)
        {
            return Producten.Where(product => product.ToString().Contains(zoekterm)).ToList();
        }

        public List<Product> GeefProductenMetCategorie(List<Categorie> categorieën)
        {
            return (from product in Producten from categorie in categorieën where product.Categorieën.Contains(categorie) select product).ToList();
        }

        public List<Product> GeefProductenGeschiktVoor(List<Toestel> toestellen)
        {
            return Toestellen.SelectMany(toestel => toestel.Producten).ToList();
        }

        public List<Merk> GeefMerken()
        {
            return Merken;
        }

        public List<Toestel> GeefToestellen(Merk merk)
        {
            return merk.Toestellen;
        }

        public BestelStatus GeefBestelStatus(int bestelnummer, string emailadres)
        {
            return Bestellingen.First(bestelling => bestelling.BestelNummer == bestelnummer &&
                                             bestelling.KlantEmailadres == emailadres).BestelStatus;
        }

        public void RegistreerVoorNieuwsbrief(string emailadres)
        {
            throw new NotImplementedException();
        }

        public void ContactOpnemen(string naam, string emailadres, string bericht)
        {
            throw new NotImplementedException();
        }

        public List<string> GeefVeelgesteldeVragen()
        {
            throw new NotImplementedException();
        }

        public List<string> GeefAlgemeneVoorwaarden()
        {
            throw new NotImplementedException();
        }
    }
}
