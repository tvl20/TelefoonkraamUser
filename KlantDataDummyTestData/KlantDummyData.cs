using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOGIC;

namespace KlantDataDummyTestData
{
    public class KlantDummyData : IKlantData
    {
        public List<Merk> Merken { get; private set; }
        public List<Toestel> Toestellen { get; private set; }
        public List<Product> Producten { get; private set; }
        public List<Categorie> Categorieën { get; private set; }

        private int _bestelnummer = 0;

        public KlantDummyData()
        {
            MaakCategorieënAan();
            MaakProductenAan();
            MaakToestellenAan();
            MaakMerkenAan();
        }

        public Kortingscode ControleerKortingsCode(string kortingscode)
        {
            switch (kortingscode)
            {
                case "TestValide":
                    return new Kortingscode(kortingscode, 10, DateTime.Now.AddDays(-1),DateTime.Now.AddDays(1));
                case "TestVerlopen":
                    return new Kortingscode(kortingscode, 25, DateTime.Now.AddDays(-20), DateTime.Now.AddDays(-5));
                case "TestToekomstig":
                    return new Kortingscode(kortingscode, 15, DateTime.Now.AddDays(5), DateTime.Now.AddDays(20));
                default:
                    return null;
            }
        }

        public int BestellingVerzenden(Bestelling bestelling)
        {
            if (bestelling == null)
            {
                return -1;
            }
            if (bestelling.Bestelregels.Count <= 0)
            {
                return -1;
            }
            _bestelnummer++;
            return _bestelnummer;
        }

        public List<Merk> HaalAlleMerkenOp()
        {
            return Merken;
        }

        private void MaakCategorieënAan()
        {
            Categorieën = new List<Categorie>
            {
                new Categorie("Opladers"),
                new Categorie("Hoesjes"),
                new Categorie("Screensavers"),
                new Categorie("Oortjes"),
                new Categorie("Auto")
            };
        }

        private void MaakProductenAan()
        {
            Producten = new List<Product>
            {
                new Product("Universele Oplader", new List<Categorie>
                {
                    Categorieën.First(categorie => categorie.Naam == "Opladers")
                }, null, 5, 3, 20, 2),
                new Product("Samsung Galaxy S6 Beschermhoesje", new List<Categorie>
                {
                    Categorieën.First(categorie => categorie.Naam == "Hoesjes")
                }, null, 20, 16, 3, 3),
                new Product("Samsung Galaxy S6 Screensaver", new List<Categorie>
                {
                    Categorieën.First(categorie => categorie.Naam == "Screensavers")
                }, null, 25, 19, 1, 3),
                new Product("Oortjes", new List<Categorie>
                {
                    Categorieën.First(categorie => categorie.Naam == "Oortjes")
                }, null, 20, 16, 3, 3),
                new Product("Samsung Galaxy S7 Edge Beschermhoesje", new List<Categorie>
                {
                    Categorieën.First(categorie => categorie.Naam == "Hoesjes")
                }, null, 30, 26, 12, 1),
                new Product("Samsung Galaxy S7 Edge Screensaver", new List<Categorie>
                {
                    Categorieën.First(categorie => categorie.Naam == "Screensavers")
                }, null, 34, 30, 4, 2),
                new Product("Sony Xperia Z5 Beschermhoesje", new List<Categorie>
                {
                    Categorieën.First(categorie => categorie.Naam == "Hoesjes")
                }, null, 18, 15, 0, 5),
                new Product("Sony Xperia Z5 Screensaver", new List<Categorie>
                {
                    Categorieën.First(categorie => categorie.Naam == "Screensavers")
                }, null, 20, 17, 0, 4),
                new Product("Oplader Iphone", new List<Categorie>
                {
                    Categorieën.First(categorie => categorie.Naam == "Opladers")
                }, null, 9, 6, 26, 1),
                new Product("Iphone 6 Beschermhoesje", new List<Categorie>
                {
                    Categorieën.First(categorie => categorie.Naam == "Hoesjes")
                }, null, 31, 26, 5, 2),
                new Product("Iphone 6 Screensaver", new List<Categorie>
                {
                    Categorieën.First(categorie => categorie.Naam == "Screensavers")
                }, null, 30, 24, 9, 1),
                new Product("Iphone 6 plus Beschermhoesje", new List<Categorie>
                {
                    Categorieën.First(categorie => categorie.Naam == "Hoesjes")
                }, null, 42, 38, 4, 2),
                new Product("Iphone 6 plus Screensaver", new List<Categorie>
                {
                    Categorieën.First(categorie => categorie.Naam == "Screensavers")
                }, null, 39, 32, 7, 1),
                new Product("USB Oplader Auto", new List<Categorie>
                {
                    Categorieën.First(categorie => categorie.Naam == "Opladers"),
                    Categorieën.First(categorie => categorie.Naam == "Auto")
                }, null, 4, 2, 15, 1)
            };
        }

        private void MaakToestellenAan()
        {
            Toestellen = new List<Toestel>
            {
                new Toestel("Samsung Galaxy S6", new List<Product>
                {
                    Producten.First(product => product.Naam == "Samsung Galaxy S6 Beschermhoesje"),
                    Producten.First(product => product.Naam == "Samsung Galaxy S6 Screensaver"),
                    Producten.First(product => product.Naam == "Universele Oplader"),
                    Producten.First(product => product.Naam == "USB Oplader Auto"),
                    Producten.First(product => product.Naam == "Oortjes")
                }, null),
                new Toestel("Samsung Galaxy S7 Edge", new List<Product>
                {
                    Producten.First(product => product.Naam == "Samsung Galaxy S7 Edge Beschermhoesje"),
                    Producten.First(product => product.Naam == "Samsung Galaxy S7 Edge Screensaver"),
                    Producten.First(product => product.Naam == "Universele Oplader"),
                    Producten.First(product => product.Naam == "USB Oplader Auto"),
                    Producten.First(product => product.Naam == "Oortjes")
                }, null),
                new Toestel("Sony Xperia Z5", new List<Product>
                {
                    Producten.First(product => product.Naam == "Sony Xperia Z5 Beschermhoesje"),
                    Producten.First(product => product.Naam == "Sony Xperia Z5 Screensaver"),
                    Producten.First(product => product.Naam == "Universele Oplader"),
                    Producten.First(product => product.Naam == "USB Oplader Auto"),
                    Producten.First(product => product.Naam == "Oortjes")
                }, null),
                new Toestel("Iphone 6", new List<Product>
                {
                    Producten.First(product => product.Naam == "Iphone 6 Beschermhoesje"),
                    Producten.First(product => product.Naam == "Iphone 6 Screensaver"),
                    Producten.First(product => product.Naam == "Oplader Iphone"),
                    Producten.First(product => product.Naam == "USB Oplader Auto"),
                    Producten.First(product => product.Naam == "Oortjes")
                }, null),
                new Toestel("Iphone 6 plus", new List<Product>
                {
                    Producten.First(product => product.Naam == "Iphone 6 plus Beschermhoesje"),
                    Producten.First(product => product.Naam == "Iphone 6 plus Screensaver"),
                    Producten.First(product => product.Naam == "Oplader Iphone"),
                    Producten.First(product => product.Naam == "USB Oplader Auto"),
                    Producten.First(product => product.Naam == "Oortjes")
                }, null)
            };
        }

        private void MaakMerkenAan()
        {
            Merken = new List<Merk>
            {
                new Merk("Samsung", new List<Toestel>
                {
                    Toestellen.First(toestel => toestel.Naam == "Samsung Galaxy S6"),
                    Toestellen.First(toestel => toestel.Naam == "Samsung Galaxy S7 Edge")
                }),
                new Merk("Sony", new List<Toestel>
                {
                    Toestellen.First(toestel => toestel.Naam == "Sony Xperia Z5")
                }),
                new Merk("Apple", new List<Toestel>
                {
                    Toestellen.First(toestel => toestel.Naam == "Iphone 6"),
                    Toestellen.First(toestel => toestel.Naam == "Iphone 6 plus")
                })
            };
        }
    }
}
