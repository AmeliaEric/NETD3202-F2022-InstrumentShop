﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NETD3202_F2022_InstrumentShop.Models
{
    public class Instrument
    {
        [Key]
        public int instrumentID { get; set; }

        public string name { get; set; }

        public string manufacturerID { get; set; }

        public string type { get; set; }

        public string color { get; set; }

        public int quantityBought { get; set; }

        public double priceSold { get; set; }
    }
}