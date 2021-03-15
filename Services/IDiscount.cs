using ShopsRUs.Model;
using ShopsRUs.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Services
{
    public interface IDiscount
    {
        Task<IEnumerable<Discount>> GetAllDiscount();
        Task<Discount> GetDiscountById(Guid id);
        Task<Discount> GetDiscountByType(Guid id);
        Task<Discount> createDiscount(DiscountDTO discount);
        Task<Discount> deleteDiscount(Guid id);
        Task<Discount> UpdateDiscount(Guid id, DiscountDTO Discount);
    }
}
