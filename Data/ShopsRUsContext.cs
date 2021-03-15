using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopsRUs.Model;

namespace ShopsRUs.Data
{
    public class ShopsRUsContext : DbContext
    {
        public ShopsRUsContext(DbContextOptions<ShopsRUsContext> options)
            : base(options)
        {
        }

        public DbSet<ShopsRUs.Model.Customer> Customer { get; set; }

        public DbSet<ShopsRUs.Model.Discount> Discount { get; set; }

        public DbSet<ShopsRUs.Model.Invoice> Invoice { get; set; }

        public DbSet<ShopsRUs.Model.CustomerType> CustomerType { get; set; }

    }
}
