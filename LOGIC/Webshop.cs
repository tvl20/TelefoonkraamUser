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
            throw new NotImplementedException();
        }

        public List<Product> GeefProductenMetCategorie(List<Categorie> Categorieën)
        {
            throw new NotImplementedException();
        }

        public List<Product> GeefProductenGeschiktVoor(List<Toestel> toestellen)
        {
            throw new NotImplementedException();
        }

        public List<Merk> GeefMerken()
        {
            return Merken;
        }

        public List<Product> GeefToestellen(Merk merk)
        {
            throw new NotImplementedException();
        }

        public BestelStatus GeefBestelStatus(int bestelnummer, string emialadres)
        {
            throw new NotImplementedException();
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
