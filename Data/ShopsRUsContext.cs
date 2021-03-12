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
        public ShopsRUsContext (DbContextOptions<ShopsRUsContext> options)
            : base(options)
        {
        }

        public DbSet<ShopsRUs.Model.Customer> Customer { get; set; }

        public DbSet<ShopsRUs.Model.Discount> Discount { get; set; }

        public DbSet<ShopsRUs.Model.Invoice> Invoice { get; set; }

        public DbSet<ShopsRUs.Model.CustomerType> CustomerType { get; set; }

    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Entity<CustomerType>().HasData(
    //            new CustomerType { Id = new Guid("42597c90-ad38-42e3-9423-6180735a0895"), Name = "Affiliate" },
    //            new CustomerType { Id = new Guid("1c8ac228-5531-44fc-8f32-b3ae9feb2ce6"), Name = "Employee" },
    //            new CustomerType { Id = new Guid("a97c408a-7991-412b-b686-8cf2cdfd9b7c"), Name = "Customer" }
    //        );
    //        modelBuilder.Entity<Customer>().HasData(
    //            new Customer
    //            {
    //                Id = new Guid("f441f952-0345-43b1-8e0e-6df94d6f2d4a"),
    //                CUstomerTypeID = new Guid("42597c90-ad38-42e3-9423-6180735a0895"),
    //                FirstName = "Henry",
    //                LastName = "Ekwonwa",
    //                Address = "Lagos",
    //                Phone = "08125234436",
    //                Email = "henimastic@gmail.com"
    //            },
    //            new Customer
    //            {
    //                Id = new Guid("5540638b-2410-445a-be25-cd2dbe584ad6"),
    //                CUstomerTypeID = new Guid("1c8ac228-5531-44fc-8f32-b3ae9feb2ce6"),
    //                FirstName = "Daniel",
    //                LastName = "Amoko",
    //                Address = "Lagos",
    //                Phone = "08125234433",
    //                Email = "danielamoko@gmail.com"
    //            },
    //            new Customer
    //            {
    //                Id = new Guid("5a3f4b12-3067-4609-aeb2-66dd86ba508e"),
    //                CUstomerTypeID = new Guid("a97c408a-7991-412b-b686-8cf2cdfd9b7c"),
    //                FirstName = "Somto",
    //                LastName = "Amaugo",
    //                Address = "Lagos",
    //                Phone = "08125244436",
    //                Email = "somto@gmail.com"
    //            }
    //        );
    //        modelBuilder.Entity<Discount>().HasData(
    //            new Discount
    //            {
    //                Id = new Guid("e14ad1cb-cd48-433f-96d2-849c30bbd184"),
    //                CustomerTypeId = new Guid("42597c90-ad38-42e3-9423-6180735a0895"),
    //                Key = "Affiliate",
    //                Value = 0.1m,
    //                PercentOrFixed = true,
    //                Description = "Discount for Affiliate",
    //                CustomerorBIllType = true
    //            },
    //            new Discount
    //            {
    //                Id = new Guid("456d0c56-fced-4324-8e10-15c85aa3d5cb"),
    //                CustomerTypeId = new Guid("1c8ac228-5531-44fc-8f32-b3ae9feb2ce6"),
    //                Key = "Employee",
    //                Value = 0.3m,
    //                PercentOrFixed = true,
    //                Description = "Discount for Employee",
    //                CustomerorBIllType = true,
    //            },
    //            new Discount
    //            {
    //                Id = new Guid("e92e4be2-7fbd-44f4-b5b6-1006b218fc5d"),
    //                CustomerTypeId = new Guid("a97c408a-7991-412b-b686-8cf2cdfd9b7c"),
    //                Key = "2 years",
    //                Value = 0.05m,
    //                PercentOrFixed = true,
    //                Description = "Discount for Customers that has spent over 2 years",
    //                CustomerorBIllType = true
    //            },
    //            new Discount
    //            {
    //                Id = new Guid("12858bf9-d0ea-4da8-b0d5-d28e955ac40b"),
    //                CustomerTypeId = Guid.Empty,
    //                Key = "100 dollars",
    //                Value = 5,
    //                PercentOrFixed = false,
    //                Description = "For every $100, customer get $5 discount",
    //                CustomerorBIllType = false
    //            }
    //        );
    //    }
    //}
}
