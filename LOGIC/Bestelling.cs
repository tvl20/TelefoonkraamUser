using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC
{
    public class Bestelling
    {
        public int OrderNummer { get; private set; }
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

        public Bestelling(int orderNummer, List<Bestelregel> bestelregels, BestelStatus bestelStatus, Kortingscode kortingscode, string klantNaam, string klantEmailadres, string klantAdresLand, string klantAdresPostcode, string klantAdresPlaatsnaam, string klantAdresStraatnaam, string klantAdresHuisnummer, string klantTelefoonnummer)
        {
            OrderNummer = orderNummer;
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
            OrderNummer = orderNummer;
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
            throw new NotImplementedException();
        }
    }
}
