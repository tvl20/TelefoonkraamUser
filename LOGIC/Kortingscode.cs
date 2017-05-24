using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC
{
    public class Kortingscode
    {
        public string Code { get; private set; }
        public decimal KortingsPercentage { get; private set; }
        public List<Bestelling> Bestellingen { get; private set; }
        public DateTime IngangsDatum { get; private set; }
        public DateTime EindDatum { get; private set; }

        public Kortingscode(string code, decimal kortingsPercentage, DateTime ingangsDatum, DateTime eindDatum)
        {
            Code = code;
            KortingsPercentage = kortingsPercentage;
            IngangsDatum = ingangsDatum;
            EindDatum = eindDatum;
        }

        public Kortingscode(string code, decimal kortingsPercentage, List<Bestelling> bestellingen, DateTime ingangsDatum, DateTime eindDatum)
        {
            Code = code;
            KortingsPercentage = kortingsPercentage;
            Bestellingen = bestellingen;
            IngangsDatum = ingangsDatum;
            EindDatum = eindDatum;
        }

        public decimal GeefKortingsPercentage()
        {
            throw new NotImplementedException();
        }
    }
}
