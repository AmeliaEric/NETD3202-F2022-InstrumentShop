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
    public class Repair
    {
        [Key]
        // The Primary Key
        public int repairID { get; set; }

        public int instrumentID { get; set; }

        public string owner { get; set; }

        public string phone { get; set; }

        public string email { get; set; }

        public string address { get; set; }

        public string city { get; set; }

        public string province { get; set; }

        public string postalCode { get; set; }
    }
}
