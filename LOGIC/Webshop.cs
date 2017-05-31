using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LOGIC
{
    public class Webshop : IKlantLogica
    {
        private IKlantData KlantData { get; set; }
        public List<Product> Producten { get; private set; }
        public List<Toestel> Toestellen { get; private set; }
        public List<Merk> Merken { get; private set; }
        public List<Categorie> Categorieën { get; private set; }
        public List<Bestelling> Bestellingen { get; private set; }
        public Kortingscode Kortingscode { get; private set; }
        public Winkelwagen Winkelwagen { get; private set; }

        public Webshop(IKlantData klantData)
        {
            KlantData = klantData;
            try
            {
                Merken = klantData.HaalAlleMerkenOp();
            }
            catch (Exception)
            {
                //ToDo: Vang exceptions af
            }
            
            Toestellen = new List<Toestel>();
            foreach (Merk merk in Merken)
            {
                foreach (Toestel toestel in merk.Toestellen)
                {
                    Toestellen.Add(toestel);
                }
            }
            Producten = new List<Product>();
            foreach (Toestel toestel in Toestellen)
            {
                foreach (Product product in toestel.Producten)
                {
                    if(!Producten.Contains(product))
                    {
                        Producten.Add(product);
                    }
                }
            }
            Categorieën = new List<Categorie>();
            foreach (Product product in Producten)
            {
                foreach (Categorie categorie in product.Categorieën)
                {
                    if (!Categorieën.Contains(categorie))
                    {
                        Categorieën.Add(categorie);
                    }
                    
                }
            }
            Winkelwagen = new Winkelwagen();
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
            MailAddress from, to, bcc;
            string klant, klantAdresStraatnaam, klantAdresHuisnummer, klantAdresPostcode, klantAdresPlaatsnaam, klantAdresLand, productTable;
            int bestelnummer;
            BereidMailVoor(bestelling, out from, out to, out bcc, out klant, out bestelnummer, out klantAdresStraatnaam, out klantAdresHuisnummer, out klantAdresPostcode, out klantAdresPlaatsnaam, out klantAdresLand, out productTable);

            var mail = new MailMessage(from, to);
            SmtpClient client = new SmtpClient
            {
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = "smtp-mail.outlook.com",
                EnableSsl = true,
                //ToDo: Wachtwoord toevoegen
                Credentials = new NetworkCredential("lars.van.driel@hotmail.com", "Password")
            };
            mail.Bcc.Add(bcc);
            mail.Subject = "Bestelling op Telefoonkraam.nl";
            mail.Body = "Beste " + klant + ",<br /><br />Bedankt voor je bestelling met nummer " +
                        Convert.ToString(bestelnummer) +
                        ".<br /><br />U hebt besteld:<br />" + productTable + "<br /><br />Wij verzenden jouw bestelling naar:<br />" +
                        klantAdresStraatnaam + " " + klantAdresHuisnummer + "<br />" + klantAdresPostcode + " " +
                        klantAdresPlaatsnaam + "<br />" + klantAdresLand +
                        "<br /><br />Met vriendelijke groet,<br />Telefoonkraam.nl";
            mail.IsBodyHtml = true;
            try
            {
                Console.WriteLine(@"Bezig met verzenden");
                client.Send(mail);
                Console.WriteLine(@"Bericht verzonden");
            }
            catch (SmtpFailedRecipientsException exception)
            {
                foreach (SmtpFailedRecipientException innerException in exception.InnerExceptions)
                {
                    SmtpStatusCode status = innerException.StatusCode;
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
                            innerException.FailedRecipient);
                    }
                }
            }
            return true;
        }

        private static void BereidMailVoor(Bestelling bestelling, out MailAddress from, out MailAddress to, out MailAddress bcc, out string klant, out int bestelnummer, out string klantAdresStraatnaam, out string klantAdresHuisnummer, out string klantAdresPostcode, out string klantAdresPlaatsnaam, out string klantAdresLand, out string productTable)
        {
            from = new MailAddress("lars.van.driel@hotmail.com", "Telefoonkraam.nl");
            to = new MailAddress(bestelling.KlantEmailadres);
            bcc = new MailAddress("lars.van.driel@hotmail.com", "Lars van Driel");
            klant = bestelling.KlantNaam;
            bestelnummer = bestelling.BestelNummer;
            klantAdresStraatnaam = bestelling.KlantAdresStraatnaam;
            klantAdresHuisnummer = bestelling.KlantAdresHuisnummer;
            klantAdresPostcode = bestelling.KlantAdresPostcode;
            klantAdresPlaatsnaam = bestelling.KlantAdresPlaatsnaam;
            klantAdresLand = bestelling.KlantAdresLand;

            //ToDo: Bepaal Verzendkosten
            decimal verzendkosten = Convert.ToDecimal(0.25);

            //ToDo: Bepaal Betaalkosten
            decimal betaalkosten = Convert.ToDecimal(0.50);
            decimal subTotaalprijsBestelling = bestelling.Bestelregels.Sum(bestelregel => bestelregel.Aantal * bestelregel.ProductPrijs);
            subTotaalprijsBestelling += verzendkosten;
            subTotaalprijsBestelling += betaalkosten;
            decimal kortingspercentage = bestelling.Kortingscode.KortingsPercentage;
            decimal korting = 0;
            if (bestelling.Kortingscode != null)
            {
                korting = subTotaalprijsBestelling * kortingspercentage;
            }
            decimal totaalPrijs = subTotaalprijsBestelling - korting;

            productTable = "<style>table{border-collapse: collapse;} table, th, td {border: 1px solid black}</style><table><tr><th>Product</th><th>Aantal</th><th>PrijsPerProduct</th></tr>";
            foreach (var bestelregel in bestelling.Bestelregels)
            {
                productTable += "<tr><td> " + bestelregel.ProductNaam + " </td><td>" + bestelregel.Aantal +
                                "</td><td> €" + Convert.ToDecimal(bestelregel.ProductPrijs) + " </td></tr>";
            }
            productTable += "<tr><td colspan = 2><b>Verzendkosten</b></td><td> €" + verzendkosten +
                            "</td></tr><tr><td colspan = 2><b>Betaalwijze</b></td><td> €" + betaalkosten +
                            "</td></tr><tr><td colspan = 2><b>SubTotaalprijs</b></td><td> €" +
                            subTotaalprijsBestelling + "</td></tr><tr><td colspan = 2><b>" + kortingspercentage +
                            "% korting</b></td><td> €" + korting +
                            "</td></tr><tr><td colspan = 2><b>Totaalprijs</b></td><td> €" + totaalPrijs +
                            "</td></tr></table>";
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
