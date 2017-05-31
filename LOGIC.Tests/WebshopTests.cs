using Microsoft.VisualStudio.TestTools.UnitTesting;
using LOGIC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlantDataDummyTestData;

namespace LOGIC.Tests
{
    [TestClass()]
    public class WebshopTests
    {
        Webshop webshop;
        Bestelling bestelling;

        [TestMethod]
        public void WebshopTest()
        {
            IKlantData dummyKlantData = new KlantDummyData();
            webshop = new Webshop(dummyKlantData);
            KlantDummyData dummyData = (KlantDummyData) dummyKlantData;
            Assert.AreEqual(dummyData.Merken.Count, webshop.Merken.Count);
            Assert.AreEqual(dummyData.Toestellen.Count, webshop.Toestellen.Count);
            Assert.AreEqual(dummyData.Producten.Count, webshop.Producten.Count);
            Assert.AreEqual(dummyData.Categorieën.Count, webshop.Categorieën.Count);
        }
    }
}