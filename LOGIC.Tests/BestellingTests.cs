using Microsoft.VisualStudio.TestTools.UnitTesting;
using LOGIC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Tests
{
    [TestClass()]
    public class BestellingTests
    {
        public List<Product> Producten { get; private set; }

        public BestellingTests()
        {
            Producten = new List<Product>()
            {
                new Product("TelefoonHoesje Samsung S6", null, null, 35, 25, 6, 3),
                new Product("TelefoonHoesje Samsung S6", null, null, 35, 25, 6, 3),
                new Product("Oplader Iphone", null, null, 10, 5, 6, 3)
            };
        }

        [TestMethod()]
        public void BestellingTest()
        {
            Bestelling bestelling = new Bestelling(Producten, null, "TestKlant", "testKlantEmailadres", "TestKlantLand", "TestKlantPostcode", "TestKlantPlaatsnaam", "TestKlantStraatnaam", "TestKlantHuisnummer", "TestKlantTelefoonnummer");

            int aantalbestelregels = bestelling.Bestelregels.Count;

            Assert.AreEqual(2, aantalbestelregels);
        }
    }
}