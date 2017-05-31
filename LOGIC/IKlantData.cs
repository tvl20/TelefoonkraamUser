using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC
{
    public interface IKlantData
    {
        /// <summary>
        /// Contoleerd kortingscode op code en datum.
        /// </summary>
        /// <param name="kortingscode"></param>
        /// <returns>Return kortingscode als deze gevonden is. Return null als niet gevonden</returns>
        Kortingscode ControleerKortingsCode(string kortingscode);


        /// <summary>
        /// Slaat de bestelling van de klant op.
        /// </summary>
        /// <param name="bestelling"></param>
        /// <returns></returns>
        int BestellingVerzenden(Bestelling bestelling);

        List<Merk> HaalAlleMerkenOp();
    }
}
