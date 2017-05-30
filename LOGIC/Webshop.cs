using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LOGIC
{
    public class Webshop
    {
        private IKlantData KlantData { get; set; }
        public List<Product> Producten { get; private set; }
        public List<Toestel> Toestellen { get; private set; }
        public List<Merk> Merken { get; private set; }
        public List<Categorie> Categorieën { get; private set; }
        public List<Bestelling> Bestellingen { get; private set; }
        public Kortingscode Kortingscode { get; private set; }
        public Winkelwagen Winkelwagen { get; private set; }

        public Webshop(IKlantData klantData, List<Product> producten, List<Toestel> toestellen, List<Merk> merken,
            List<Categorie> categorieën, List<Bestelling> bestellingen, Kortingscode kortingscode,
            Winkelwagen winkelwagen)
        {
            KlantData = klantData;
            Producten = producten;
            Toestellen = toestellen;
            Merken = merken;
            Categorieën = categorieën;
            Bestellingen = bestellingen;
            Kortingscode = kortingscode;
            Winkelwagen = winkelwagen;
        }

        public bool BestelWinkelmandje(string kortingscode, string klantNaam, string klantEmailadres,
            string klantAdresLand, string klantAdresPostcode, string klantAdresPlaatsnaam, string klantAdresStraatnaam,
            string klantAdresHuisnummer, string klantTelefoonnummer)
        {
            Kortingscode valideKortingscode = null;
            if (kortingscode != null)
            {
                try
                {
                    valideKortingscode = KlantData.ControleerKortingsCode(kortingscode);
                }
                catch
                {
                    //ToDo: Exception handling
                }
            }
            List<Product> besteldeProducten = Winkelwagen.Producten;
            Bestelling bestelling = new Bestelling(besteldeProducten, valideKortingscode, klantNaam, klantEmailadres, klantAdresLand, klantAdresPostcode, klantAdresPlaatsnaam, klantAdresStraatnaam, klantAdresHuisnummer, klantTelefoonnummer);
            int bestelnummer = KlantData.BestellingVerzenden(bestelling);
            bestelling.SetBestelNummer(bestelnummer);
            return VerzendBestelBevestiging(bestelling);

        }

        private bool VerzendBestelBevestiging(Bestelling bestelling)
        {
            string emailadresAfzender = null;
            string wachtwoordAfzender = null;
            string ontvangerEmailadres

            MailMessage mail = new MailMessage(emailadresAfzender, klantEmailadres);
            SmtpClient client = new SmtpClient
            {
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = "smtp-mail.outlook.com",
                EnableSsl = true,
                Credentials = new NetworkCredential(emailadresAfzender, wachtwoordAfzender)
            };
            mail.Subject = "Bestelling op Telefoonkraam.nl";
            mail.Body = "Beste " + klantNaam + ",\n\nBedankt voor je bestelling met nummer " +
                        Convert.ToString(ordernummer) +
                        ".\n\nU heeft besteld:\n'Producteninformatie'\n\nWij verzenden jouw bestelling naar:\n" +
                        klantAdresStraatnaam + " " + klantAdresHuisnummer + "\n" + klantAdresPostcode + " " +
                        klantAdresPlaatsnaam + "\n" + klantAdresLand +
                        "\n\nMet vriendelijke groet,\nTelefoonkraam.nl";

            try
            {
                Console.WriteLine(@"Bezig met verzenden");
                client.Send(mail);
                Console.WriteLine(@"Bericht verzonden");
            }
            catch (SmtpFailedRecipientsException exception)
            {
                for (int i = 0; i < exception.InnerExceptions.Length; i++)
                {
                    SmtpStatusCode status = exception.InnerExceptions[i].StatusCode;
                    if (status == SmtpStatusCode.MailboxBusy ||
                        status == SmtpStatusCode.MailboxUnavailable)
                    {
                        Console.WriteLine(@"Delivery failed - retrying in 5 seconds.");
                        System.Threading.Thread.Sleep(5000);
                        client.Send(mail);
                    }
                    else
                    {
                        Console.WriteLine(@"Failed to deliver message to {0}",
                            exception.InnerExceptions[i].FailedRecipient);
                    }
                }
            }
            return true;
        }
    }

        public List<Product> ZoekProduct(string zoekterm)
        {
            return Producten.Where(product => product.ToString().Contains(zoekterm)).ToList();
        }

        public List<Product> GeefProductenMetCategorie(List<Categorie> categorieën)
        {
            return (from product in Producten from categorie in categorieën where product.Categorieën.Contains(categorie) select product).ToList();
        }

        public List<Product> GeefProductenGeschiktVoor(List<Toestel> toestellen)
        {
            return Toestellen.SelectMany(toestel => toestel.Producten).ToList();
        }

        public List<Merk> GeefMerken()
        {
            return Merken;
        }

        public List<Toestel> GeefToestellen(Merk merk)
        {
            return merk.Toestellen;
        }

        public BestelStatus GeefBestelStatus(int bestelnummer, string emailadres)
        {
            return Bestellingen.First(bestelling => bestelling.BestelNummer == bestelnummer &&
                                             bestelling.KlantEmailadres == emailadres).BestelStatus;
        }

        public void RegistreerVoorNieuwsbrief(string emailadres)
        {
            throw new NotImplementedException();
        }

        public void ContactOpnemen(string naam, string emailadres, string bericht)
        {
            throw new NotImplementedException();
        }

        public List<string> GeefVeelgesteldeVragen()
        {
            throw new NotImplementedException();
        }

        public List<string> GeefAlgemeneVoorwaarden()
        {
            throw new NotImplementedException();
        }
    }
}
