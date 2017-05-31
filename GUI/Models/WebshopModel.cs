using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOGIC;
using KlantDataDummyTestData;

namespace GUI.Models
{
    public class WebshopModel
    {
        public IKlantLogica KlantLogica { get; private set; }

        //ToDo: Pas Interface Declaratie aan.
        public WebshopModel()
        {
            KlantLogica = new Webshop(new KlantDummyData());
        }
    }
}
