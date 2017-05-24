using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC
{
    public class Bestelregel
    {
        public string ProductNaam { get; private set; }
        public decimal ProductPrijs { get; private set; }
        public string ProductAfbeelding { get; private set; }
        public int Aantal { get; private set; }

        public Bestelregel(string productNaam, decimal productPrijs, string productAfbeelding, int aantal)
        {
            ProductNaam = productNaam;
            ProductPrijs = productPrijs;
            ProductAfbeelding = productAfbeelding;
            Aantal = aantal;
        }
    }
}
