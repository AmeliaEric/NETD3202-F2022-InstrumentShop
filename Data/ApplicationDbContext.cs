using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using NETD3202_F2022_InstrumentShop.Models;

namespace NETD3202_F2022_InstrumentShop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Repair> Repairs { get; set; }
    }
}
