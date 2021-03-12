using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopsRUs.Data;
using ShopsRUs.Model;
using ShopsRUs.ViewModel;

namespace ShopsRUs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ShopsRUsContext _context;

        public CustomersController(ShopsRUsContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomer()
        {
            return await _context.Customer.Include(s => s.CustomerType).ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(Guid id)
        {
            var customer = await _context.Customer.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // GET: api/Customers/5
        [HttpGet("getCustomerByName/{name}")]
        public async Task<ActionResult<Customer>> GetCustomer(String name)
        {
            var customer = await _context.Customer.Where(c=>c.FirstName.ToLower() == name || c.LastName.ToLower() == name ).FirstOrDefaultAsync();

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(Guid id, CustomerDTO customer)
        {
            var customerExist = await _context.Customer.Where(c => c.Id == id).FirstOrDefaultAsync();

            if (customerExist == null)
            {
                return BadRequest();
            }

            customerExist.FirstName = customer.FirstName;
            customerExist.LastName = customer.LastName;
            customerExist.Email = customer.Email;
            customerExist.Address = customer.Address;
            customerExist.Phone = customer.Phone;
            customerExist.CUstomerTypeID = customer.CUstomerTypeID;

            _context.Update(customerExist);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Customers
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(CustomerDTO dto)
        {
            var customer = new Customer()
            {
                Address = dto.Address,
                CUstomerTypeID = dto.CUstomerTypeID,
                DateCreated = DateTime.Now,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Phone = dto.Phone
            };

            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(Guid id)
        {
            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();

            return Ok("Successfully deleted customer");
        }

        private bool CustomerExists(Guid id)
        {
            return _context.Customer.Any(e => e.Id == id);
        }
    }
}
