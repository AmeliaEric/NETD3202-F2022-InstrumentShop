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
    /// The Repair class represents a repair for an instrument in the instrument shop.
    /// It contains all the relevant information about a repair, such as the instrument ID,
    /// owner, phone, email, address, city, province, and postal code.
    /// </summary>
    public class Repair
    {

        #region Properties

        /// <summary>
        /// The primary key of the repair.
        /// </summary>
        [Key]
        public int repairID { get; set; }

        /// <summary>
        /// The ID of the instrument that is being repaired.
        /// </summary>
        public int instrumentID { get; set; }

        /// <summary>
        /// The name of the owner of the instrument being repaired.
        /// </summary>
        public string owner { get; set; }

        /// <summary>
        /// The phone number of the owner of the instrument being repaired.
        /// </summary>
        public string phone { get; set; }

        /// <summary>
        /// The email address of the owner of the instrument being repaired.
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// The address of the owner of the instrument being repaired.
        /// </summary>
        public string address { get; set; }

        /// <summary>
        /// The city where the owner of the instrument being repaired lives.
        /// </summary>
        public string city { get; set; }

        /// <summary>
        /// The province where the owner of the instrument being repaired lives.
        /// </summary>
        public string province { get; set; }

        /// <summary>
        /// The postal code of where the owner of the instrument being repaired lives.
        /// </summary>
        public string postalCode { get; set; }
        #endregion
    }
}
