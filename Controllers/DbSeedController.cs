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


        [HttpPost("/CustomerTypeSeeder")]
        public async Task<ActionResult<CustomerType>> SeedCustomerTypes()
        {
            var customerType1 = new CustomerType()
            {
                Id = new Guid("42597c90-ad38-42e3-9423-6180735a0895"),
                Name = "Affiliate"
            };

            var customerType2 = new CustomerType()
            {
                Id = new Guid("1c8ac228-5531-44fc-8f32-b3ae9feb2ce6"),
                Name = "Employee"
            };

            var customerType3 = new CustomerType()
            {
                Id = new Guid("a97c408a-7991-412b-b686-8cf2cdfd9b7c"),
                Name = "OldCustomer"
            };

            var customerType4 = new CustomerType()
            {
                Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                Name = "NewCustomer"
            };

            List<CustomerType> CustomerTypeList = new List<CustomerType>();
            CustomerTypeList.Add(customerType1);
            CustomerTypeList.Add(customerType2);
            CustomerTypeList.Add(customerType3);
            CustomerTypeList.Add(customerType4);

            foreach (var customerType in CustomerTypeList)
            {
                _context.CustomerType.Add(customerType);
            }

            await _context.SaveChangesAsync();

            return Ok("Seed was successful");
        }


        [HttpPost("/CustomerSeeder")]
        public async Task<ActionResult<Customer>> SeedCustomer()
        {
            var customer1 = new Customer()
            {
                Id = new Guid("1e84b757-7dc6-4b9c-b409-7c4da5f340f1"),
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
                Id = new Guid("d2f7ae47-6130-4437-a924-d9a32c1c9154"),
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
                Id = new Guid("1ee76981-1a5d-41ec-9d3e-5d58209ed345"),
                Address = "Lagos",
                CUstomerTypeID = new Guid("a97c408a-7991-412b-b686-8cf2cdfd9b7c"),
                DateCreated = DateTime.Now,
                Email = "tobi@gmail.com",
                FirstName = "Tobi",
                LastName = "Okubadejo",
                Phone = "08121134431"
            };

            var customer4 = new Customer()
            {
                Id = new Guid("af95be87-57c3-4656-b84f-653f6a6ef8e8"),
                Address = "Abuja",
                CUstomerTypeID = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                DateCreated = DateTime.Now,
                Email = "pelumi@gmail.com",
                FirstName = "Pelumi",
                LastName = "Okubadejo",
                Phone = "08120034431"
            };

            List<Customer> CustomerList = new List<Customer>();
            CustomerList.Add(customer1);
            CustomerList.Add(customer2);
            CustomerList.Add(customer3);
            CustomerList.Add(customer4);

            foreach (var customer in CustomerList)
            {
                _context.Customer.Add(customer);
            }

            await _context.SaveChangesAsync();

            return Ok("Seed was successful");
        }

        [HttpPost("/DiscountSeeder")]
        public async Task<ActionResult<Discount>> SeedDiscount()
        {
            var discount1 = new Discount()
            {
                Id = new Guid("804dd5e3-4379-436c-b2fd-4bebf1d8f823"),
                CustomerTypeId = new Guid("42597c90-ad38-42e3-9423-6180735a0895"),
                Key = "Affiliate",
                Value = 0.1m,
                IsPercent = true,
                IsFixed = false,
                Description = "Discount for Affiliate"
            };

            var discount2 = new Discount()
            {
                Id = new Guid("2d1c5282-f48f-461f-ad68-9185ef7304f0"),
                CustomerTypeId = new Guid("1c8ac228-5531-44fc-8f32-b3ae9feb2ce6"),
                Key = "Employee",
                Value = 0.3m,
                IsPercent = true,
                IsFixed = false,
                Description = "Discount for Employee",
            };

            var discount3 = new Discount()
            {
                Id = new Guid("3045c41b-7186-464f-afa5-e76279f16ea1"),
                CustomerTypeId = new Guid("a97c408a-7991-412b-b686-8cf2cdfd9b7c"),
                Key = "OldCustomer",
                Value = 0.05m,
                IsPercent = true,
                IsFixed = false,
                Description = "Discount for Customers that has spent over 2 years"
            };

            var discount4 = new Discount()
            {
                Id = new Guid("11a922f2-dd3e-48c0-b5b2-65b7c46de0ab"),
                CustomerTypeId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                Key = "NewCustomer",
                Value = 5,
                IsPercent = false,
                IsFixed = true,
                Description = "For every $100, customer get $5 discount",
            };

            List<Discount> DiscountList = new List<Discount>();
            DiscountList.Add(discount1);
            DiscountList.Add(discount2);
            DiscountList.Add(discount3);
            DiscountList.Add(discount4);

            foreach (var discount in DiscountList)
            {
                _context.Discount.Add(discount);
            }

            await _context.SaveChangesAsync();

            return Ok("Seed was successful");
        }
    }

    
}
