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




    }
}
