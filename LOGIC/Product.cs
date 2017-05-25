using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC
{
    public class Product
    {
        public string Naam { get; private set; }
        public List<Categorie> Categorieën { get; private set; }
        public string Afbeelding { get; private set; }
        public decimal VerkoopPrijs { get; private set; }
        public decimal InkoopPrijs { get; private set; }
        public int AantalAanwezig { get; private set; }
        public int VerwachteLevertijd { get; private set; }

        public Product(string naam, List<Categorie> categorieën, string afbeelding, decimal verkoopPrijs, decimal inkoopPrijs, int aantalAanwezig, int verwachteLevertijd)
        {
            Naam = naam;
            Categorieën = categorieën;
            Afbeelding = afbeelding;
            VerkoopPrijs = verkoopPrijs;
            InkoopPrijs = inkoopPrijs;
            AantalAanwezig = aantalAanwezig;
            VerwachteLevertijd = verwachteLevertijd;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Product))
            {
                return false;
            }
            Product product = obj as Product;
            if (Naam == product.Naam && VerkoopPrijs == product.VerkoopPrijs && Afbeelding == product.Afbeelding)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return Naam;
        }
    }
}
