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
    /// Creates all the attributes for the database/class
    /// </summary>
    public class Instrument
    {
        [Key]
        // The Primary Key
        public int instrumentID { get; set; }

        public string name { get; set; }

        public int manufacturerID { get; set; }

        public string type { get; set; }

        public string color { get; set; }

        public int quantityBought { get; set; }

        public double priceSold { get; set; }
    }
}
