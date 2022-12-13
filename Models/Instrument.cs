#region USING STATEMENTS
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
#endregion
namespace NETD3202_F2022_InstrumentShop.Models
{
    /// <summary>
    /// The Instrument class represents an instrument in the instrument shop.
    /// It contains all the relevant information about an instrument, such as its name, manufacturer ID, type,
    /// color, quantity bought, and price sold.
    /// </summary>
    public class Instrument
    {
        #region Properties
        /// <summary>
        /// The primary key of the instrument.
        /// </summary>
        [Key]
        public int instrumentID { get; set; }

        /// <summary>
        /// The name of the instrument.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// The ID of the manufacturer of the instrument.
        /// </summary>
        public int manufacturerID { get; set; }

        /// <summary>
        /// The type of the instrument (e.g. guitar, piano, etc.).
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// The color of the instrument.
        /// </summary>
        public string color { get; set; }

        /// <summary>
        /// The quantity of the instrument that was bought.
        /// </summary>
        public int quantityBought { get; set; }

        /// <summary>
        /// The price at which the instrument was sold.
        /// </summary>
        public double priceSold { get; set; }
        #endregion
    }
}
