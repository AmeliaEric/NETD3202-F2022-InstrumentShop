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
    /// The Manufacturer class represents a manufacturer of instruments in the instrument shop.
    /// It contains all the relevant information about a manufacturer, such as its name, owner, phone,
    /// email, address, city, province, and postal code.
    /// </summary>
    public class Manufacturer
    {
        #region Properties

        /// <summary>
        /// The primary key of the manufacturer.
        /// </summary>
        [Key]
        public int manufacturerID { get; set; }

        /// <summary>
        /// The name of the manufacturer.
        /// </summary>
        public string name { get; set; }


        /// <summary>
        /// The name of the owner of the manufacturer.
        /// </summary>
        public string owner { get; set; }


        /// <summary>
        /// The phone number of the manufacturer.
        /// </summary>
        public string phone { get; set; }


        /// <summary>
        /// The email address of the manufacturer.
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// The address of the manufacturer.
        /// </summary>
        public string address { get; set; }

        /// <summary>
        /// The city where the manufacturer is located.
        /// </summary>
        public string city { get; set; }

        /// <summary>
        /// The province where the manufacturer is located.
        /// </summary>
        public string province { get; set; }

        /// <summary>
        /// The postal code of the manufacturer's location.
        /// </summary>
        public string postalCode { get; set; }
        #endregion
    }
}
