using Microsoft.EntityFrameworkCore;
using ShopsRUs.Data;
using ShopsRUs.Model;
using ShopsRUs.Services;
using ShopsRUs.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ShopsRUs.CommonClasses.HardCodes;

namespace ShopsRUs.Repositories
{
    public class MockIDiscount : IDiscount
    {
        private readonly ShopsRUsContext _context;
        public MockIDiscount(ShopsRUsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Discount>> GetAllDiscount()
        {
            return await _context.Discount.Include(c => c.CustomerType).ToListAsync();
        }

        public async Task<Discount> GetDiscountById(Guid id)
        {
            return await _context.Discount.FindAsync(id);
        }

        public async Task<Discount> GetDiscountByType(Guid id)
        {
            return await _context.Discount.Where(d => d.CustomerTypeId == id).FirstOrDefaultAsync();
        }

        public async Task<Discount> createDiscount(DiscountDTO discount)
        {
            var newDiscount = new Discount()
            {
                CustomerTypeId = discount.CustomerTypeId,
                Key = discount.Key,
                Value = discount.Value,
                Description = discount.Description,
                IsPercent = discount.IsPercent,
                IsFixed = discount.IsFixed
            };

            return await saveChanges(newDiscount, SaveChangesCodes.Add);
        }

        public async Task<Discount> UpdateDiscount(Guid id, DiscountDTO Discount)
        {
            var discountExist = await _context.Discount.Where(c => c.Id == id).FirstOrDefaultAsync();

            discountExist.Key = Discount.Key;
            discountExist.Value = Discount.Value;
            discountExist.Description = Discount.Description;
            discountExist.IsPercent = Discount.IsPercent;
            discountExist.IsFixed = Discount.IsFixed;
            discountExist.CustomerTypeId = Discount.CustomerTypeId;

            return await saveChanges(discountExist, SaveChangesCodes.Update);
        }

        public async Task<Discount> deleteDiscount(Guid id)
        {
            var discount = await _context.Discount.Where(c => c.Id == id).FirstOrDefaultAsync();

            return await saveChanges(discount, SaveChangesCodes.Delete);
        }

        private async Task<Discount> saveChanges(Discount discount, int type)
        {
            if (type == SaveChangesCodes.Add)
            {
                _context.Discount.Add(discount);
                await _context.SaveChangesAsync();
            }
            else if (type == SaveChangesCodes.Update)
            {
                _context.Discount.Update(discount);
                await _context.SaveChangesAsync();
            }
            else if (type == SaveChangesCodes.Delete)
            {
                _context.Discount.Remove(discount);
                await _context.SaveChangesAsync();
            }

            return discount;
        }
    }
}
