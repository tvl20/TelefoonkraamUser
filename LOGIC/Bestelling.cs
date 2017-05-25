using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC
{
    public class Bestelling
    {
        public int BestelNummer { get; private set; }
        public List<Bestelregel> Bestelregels { get; private set; }
        public BestelStatus BestelStatus { get; private set; }
        public Kortingscode Kortingscode { get; private set; }
        public string KlantNaam { get; private set; }
        public string KlantEmailadres { get; private set; }
        public string KlantAdresLand { get; private set; }
        public string KlantAdresPostcode { get; private set; }
        public string KlantAdresPlaatsnaam { get; private set; }
        public string KlantAdresStraatnaam { get; private set; }
        public string KlantAdresHuisnummer { get; private set; }
        public string KlantTelefoonnummer { get; private set; }

        public Bestelling(List<Product> products, Kortingscode kortingscode, string klantNaam, string klantEmailadres, string klantAdresLand,
            string klantAdresPostcode, string klantAdresPlaatsnaam, string klantAdresStraatnaam,
            string klantAdresHuisnummer, string klantTelefoonnummer)
        {
            Kortingscode = kortingscode;
            KlantNaam = klantNaam;
            KlantEmailadres = klantEmailadres;
            KlantAdresLand = klantAdresLand;
            KlantAdresPostcode = klantAdresPostcode;
            KlantAdresPlaatsnaam = klantAdresPlaatsnaam;
            KlantAdresStraatnaam = klantAdresStraatnaam;
            KlantAdresHuisnummer = klantAdresHuisnummer;
            KlantTelefoonnummer = klantTelefoonnummer;
            List<Product> verschillendeProducten = products.Distinct().ToList();
            foreach (Product product in verschillendeProducten)
            {
                Bestelregels.Add(new Bestelregel(product.Naam, product.VerkoopPrijs, product.Afbeelding, products.Count(product1 => product1.Equals(product))));
            }
            //TODO: Voeg bestelling toe aan Database
            //TODO: Geef Bestelnummer zijn waarde
            BestelStatus = BestelStatus.Besteld;
            //TODO: Bevestigingsemail verzenden
        }

        public Bestelling(int orderNummer, List<Bestelregel> bestelregels, BestelStatus bestelStatus, Kortingscode kortingscode, string klantNaam, string klantEmailadres, string klantAdresLand, string klantAdresPostcode, string klantAdresPlaatsnaam, string klantAdresStraatnaam, string klantAdresHuisnummer, string klantTelefoonnummer)
        {
            BestelNummer = orderNummer;
            Bestelregels = bestelregels;
            BestelStatus = bestelStatus;
            Kortingscode = kortingscode;
            KlantNaam = klantNaam;
            KlantEmailadres = klantEmailadres;
            KlantAdresLand = klantAdresLand;
            KlantAdresPostcode = klantAdresPostcode;
            KlantAdresPlaatsnaam = klantAdresPlaatsnaam;
            KlantAdresStraatnaam = klantAdresStraatnaam;
            KlantAdresHuisnummer = klantAdresHuisnummer;
            KlantTelefoonnummer = klantTelefoonnummer;
        }
        public Bestelling(int orderNummer, List<Bestelregel> bestelregels, BestelStatus bestelStatus, string klantNaam, string klantEmailadres, string klantAdresLand, string klantAdresPostcode, string klantAdresPlaatsnaam, string klantAdresStraatnaam, string klantAdresHuisnummer, string klantTelefoonnummer)
        {
            BestelNummer = orderNummer;
            Bestelregels = bestelregels;
            BestelStatus = bestelStatus;
            KlantNaam = klantNaam;
            KlantEmailadres = klantEmailadres;
            KlantAdresLand = klantAdresLand;
            KlantAdresPostcode = klantAdresPostcode;
            KlantAdresPlaatsnaam = klantAdresPlaatsnaam;
            KlantAdresStraatnaam = klantAdresStraatnaam;
            KlantAdresHuisnummer = klantAdresHuisnummer;
            KlantTelefoonnummer = klantTelefoonnummer;
        }

        public BestelStatus GeefBestelStatus()
        {
            return BestelStatus;
        }
    }
}
