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
    public class DiscountsController : ControllerBase
    {
        private readonly ShopsRUsContext _context;

        public DiscountsController(ShopsRUsContext context)
        {
            _context = context;
        }

        // GET: api/Discounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Discount>>> GetDiscount()
        {
            return await _context.Discount.ToListAsync();
        }

        // GET: api/Discounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Discount>> GetDiscount(Guid id)
        {
            var discount = await _context.Discount.FindAsync(id);

            if (discount == null)
            {
                return NotFound();
            }

            return discount;
        }

        [HttpGet("getDiscountByType/{id}")]
        public async Task<ActionResult<Discount>> GetDiscountByType(Guid id)
        {
            var discount = await _context.Discount.Where(d=>d.CustomerTypeId == id).FirstOrDefaultAsync();

            if (discount == null)
            {
                return NotFound();
            }

            return discount;
        }

        // PUT: api/Discounts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiscount(Guid id, DiscountDTO discount)
        {
            var updatedDiscount = await _context.Discount.FindAsync(id);
            if (updatedDiscount == null)
            {
                return BadRequest();
            }

            updatedDiscount.CustomerTypeId = discount.CustomerTypeId;
            updatedDiscount.Description = discount.Description;
            updatedDiscount.CustomerorBIllType = discount.CustomerorBIllType;
            updatedDiscount.Key = discount.Key;
            updatedDiscount.Value = discount.Value;
            updatedDiscount.PercentOrFixed = discount.PercentOrFixed;

            _context.Update(updatedDiscount);

            //_context.Entry(discount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiscountExists(id))
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

        // POST: api/Discounts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Discount>> PostDiscount(DiscountDTO discount)
        {
            var newDiscount = new Discount()
            {
                CustomerTypeId = discount.CustomerTypeId,
                Key = discount.Key,
                Value = discount.Value,
                PercentOrFixed = discount.PercentOrFixed,
                CustomerorBIllType = discount.CustomerorBIllType,
                Description = discount.Description
            };

            _context.Discount.Add(newDiscount);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiscount", new { id = newDiscount.Id }, newDiscount);
        }

        // DELETE: api/Discounts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Discount>> DeleteDiscount(Guid id)
        {
            var discount = await _context.Discount.FindAsync(id);
            if (discount == null)
            {
                return NotFound();
            }

            _context.Discount.Remove(discount);
            await _context.SaveChangesAsync();

            return Ok("Deleted discount successfully");
        }

        private bool DiscountExists(Guid id)
        {
            return _context.Discount.Any(e => e.Id == id);
        }
    }
}
