using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC
{
    public class Webshop
    {
        public List<Product> Producten { get; private set; }
        public List<Toestel> Toestellen { get; private set; }
        public List<Merk> Merken { get; private set; }
        public List<Categorie> Categorieën { get; private set; }
        public List<Bestelling> Bestellingen { get; private set; }
        public List<Kortingscode> Kortingscodes { get; private set; }
        public Winkelwagen Winkelwagen { get; private set; }

        public Webshop(List<Product> producten, List<Toestel> toestellen, List<Merk> merken, List<Categorie> categorieën, List<Bestelling> bestellingen, List<Kortingscode> kortingscodes, Winkelwagen winkelwagen)
        {
            Producten = producten;
            Toestellen = toestellen;
            Merken = merken;
            Categorieën = categorieën;
            Bestellingen = bestellingen;
            Kortingscodes = kortingscodes;
            Winkelwagen = winkelwagen;
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

        public bool GebruikKortingsCode(string code)
        {
            Kortingscode mogelijkeKortingscode = Kortingscodes.First(kortingscode => kortingscode.Code == code);
            if (mogelijkeKortingscode == null)
            {
                return false;
            }
            if (mogelijkeKortingscode.EindDatum >= DateTime.Today ||
                mogelijkeKortingscode.IngangsDatum >= DateTime.Today)
            {
                return false;
            }
            Winkelwagen.GebruikKortingsCode(mogelijkeKortingscode);
            return true;
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
