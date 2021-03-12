using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopsRUs.Data;
using ShopsRUs.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbSeedController : ControllerBase
    {
        private readonly ShopsRUsContext _context;

        public DbSeedController(ShopsRUsContext context)
        {
            _context = context;
        }

        [HttpPost("/CustomerSeeder")]
        public async Task<ActionResult<Customer>> SeedCustomer()
        {
            var customer1 = new Customer()
            {
                Address = "Lagos",
                CUstomerTypeID = new Guid("42597c90-ad38-42e3-9423-6180735a0895"),
                DateCreated = DateTime.Now,
                Email = "henimastic@gmail.com",
                FirstName = "Henry",
                LastName = "LastName",
                Phone = "08125234436"
            };

            var customer2 = new Customer()
            {
                Address = "Lagos",
                CUstomerTypeID = new Guid("1c8ac228-5531-44fc-8f32-b3ae9feb2ce6"),
                DateCreated = DateTime.Now,
                Email = "somto@gmail.com",
                FirstName = "Somto",
                LastName = "Amaugo",
                Phone = "08125234431"
            };

            var customer3 = new Customer()
            {
                Address = "Lagos",
                CUstomerTypeID = new Guid("a97c408a-7991-412b-b686-8cf2cdfd9b7c"),
                DateCreated = DateTime.Now,
                Email = "tobi@gmail.com",
                FirstName = "Tobi",
                LastName = "Okubadejo",
                Phone = "08121134431"
            };

            List<Customer> CustomerList = new List<Customer>();
            CustomerList.Add(customer1);
            CustomerList.Add(customer2);
            CustomerList.Add(customer3);

            foreach(var customer in CustomerList)
            {
                _context.Customer.Add(customer);
            }

            await _context.SaveChangesAsync();

            return Ok("Seed was successful");
        }

        //[HttpPost("/DiscountSeeder")]
        //public async Task<ActionResult<Discount>> SeedDiscount()
        //{
        //    var discount1 = new Discount()
        //    {
        //        CustomerTypeId = new Guid("42597c90-ad38-42e3-9423-6180735a0895"),
        //        Key = "Affiliate",
        //        Value = 0.1m,
        //        PercentOrFixed = true,
        //        Description = "Discount for Affiliate",
        //        CustomerorBIllType = true
        //    };

        //    var discount2 = new Discount()
        //    {
        //        CustomerTypeId = new Guid("1c8ac228-5531-44fc-8f32-b3ae9feb2ce6"),
        //        Key = "Employee",
        //        Value = 0.3m,
        //        PercentOrFixed = true,
        //        Description = "Discount for Employee",
        //        CustomerorBIllType = true,
        //    };

        //    var discount3 = new Discount()
        //    {
        //        CustomerTypeId = new Guid("a97c408a-7991-412b-b686-8cf2cdfd9b7c"),
        //        Key = "2 years",
        //        Value = 0.05m,
        //        PercentOrFixed = true,
        //        Description = "Discount for Customers that has spent over 2 years",
        //        CustomerorBIllType = true
        //    };

        //    var discount4 = new Discount()
        //    {
        //        CustomerTypeId = Guid.Empty,
        //        Key = "100 dollars",
        //        Value = 5,
        //        PercentOrFixed = false,
        //        Description = "For every $100, customer get $5 discount",
        //        CustomerorBIllType = false
        //    };

        //    List<Discount> DiscountList = new List<Discount>();
        //    DiscountList.Add(discount1);
        //    DiscountList.Add(discount2);
        //    DiscountList.Add(discount3);
        //    DiscountList.Add(discount4);

        //    foreach (var discount in DiscountList)
        //    {
        //        _context.Discount.Add(discount);
        //    }

        //    await _context.SaveChangesAsync();

        //    return Ok("Seed was successful");
        //}
    }

    
}
