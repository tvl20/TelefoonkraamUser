using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC
{
    public interface IKlantLogica
    {
        bool BestelWinkelmandje(string kortingscode, string klantNaam, string klantEmailadres,
            string klantAdresLand, string klantAdresPostcode, string klantAdresPlaatsnaam, string klantAdresStraatnaam,
            string klantAdresHuisnummer, string klantTelefoonnummer);

        List<Product> ZoekProduct(string zoekterm);

        List<Product> GeefProductenMetCategorie(List<Categorie> categorieën);

        List<Product> GeefProductenGeschiktVoor(List<Toestel> toestellen);

        List<Merk> GeefMerken();

        List<Toestel> GeefToestellen(Merk merk);

        BestelStatus GeefBestelStatus(int bestelnummer, string emailadres);

        void RegistreerVoorNieuwsbrief(string emailadres);

        void ContactOpnemen(string naam, string emailadres, string bericht);

        List<string> GeefVeelgesteldeVragen();

        List<string> GeefAlgemeneVoorwaarden();
    }
}
