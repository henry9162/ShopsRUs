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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerType>().HasData(
                new CustomerType { Id = new Guid("42597c90-ad38-42e3-9423-6180735a0895"), Name = "Affiliate" },
                new CustomerType { Id = new Guid("1c8ac228-5531-44fc-8f32-b3ae9feb2ce6"), Name = "Employee" },
                new CustomerType { Id = new Guid("a97c408a-7991-412b-b686-8cf2cdfd9b7c"), Name = "Customer" }
            );
        }
    }
}
