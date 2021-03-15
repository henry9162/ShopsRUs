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
    public class CustomerTypesController : ControllerBase
    {
        private readonly ShopsRUsContext _context;

        public CustomerTypesController(ShopsRUsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerType>>> GetCustomerType()
        {
            return await _context.CustomerType.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerType>> GetCustomerType(Guid id)
        {
            var customerType = await _context.CustomerType.FindAsync(id);

            if (customerType == null)
            {
                return NotFound();
            }

            return customerType;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerType(Guid id, CustomerTypeDTO customerType)
        {
            var type = await _context.CustomerType.FindAsync(id);
            if (type == null)
            {
                return BadRequest();
            }

            type.Name = customerType.Name;
            _context.Update(type);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerTypeExists(id))
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

        [HttpPost]
        public async Task<ActionResult<CustomerType>> PostCustomerType(CustomerTypeDTO customerType)
        {
            var type = new CustomerType()
            {
                Name = customerType.Name
            };
            _context.CustomerType.Add(type);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerType", new { id = type.Id }, type);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerType>> DeleteCustomerType(Guid id)
        {
            var customerType = await _context.CustomerType.FindAsync(id);
            if (customerType == null)
            {
                return NotFound();
            }

            _context.CustomerType.Remove(customerType);
            await _context.SaveChangesAsync();

            return Ok("Deleted type successfully");
        }

        private bool CustomerTypeExists(Guid id)
        {
            return _context.CustomerType.Any(e => e.Id == id);
        }
    }
}
