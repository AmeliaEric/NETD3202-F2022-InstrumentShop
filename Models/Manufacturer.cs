using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NETD3202_F2022_InstrumentShop.Models
{
    public class Manufacturer
    {
        [Key]
        public int manufacturerID { get; set; }

        public string name { get; set; }

        public string owner { get; set; }

        public string phone { get; set; }

        public string email { get; set; }

        public string address { get; set; }

        public string city { get; set; }

        public string province { get; set; }

        public string postalCode { get; set; }
    }
}
