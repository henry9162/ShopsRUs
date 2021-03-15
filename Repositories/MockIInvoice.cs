using Microsoft.EntityFrameworkCore;
using ShopsRUs.CommonClasses;
using ShopsRUs.Data;
using ShopsRUs.Model;
using ShopsRUs.Services;
using ShopsRUs.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Repositories
{
    public class MockIInvoice : IInvoice
    {
        private readonly ShopsRUsContext _context;
        public MockIInvoice(ShopsRUsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Invoice>> GetAllInvoice()
        {
            return await _context.Invoice.Include(x=>x.Customer).ToListAsync();
        }

        public async Task<Invoice> GetInvoiceById(Guid Id)
        {
            return await _context.Invoice.Include(x => x.Customer).Where(x=>x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Invoice>> GetInvoiceByCustomerId(Guid Id)
        {
            return await _context.Invoice.Include(x => x.Customer).Where(i => i.CustomerId == Id).ToListAsync();
        }

        public async Task<Invoice> GenerateInvoice(InvoiceDTO Bill)
        {
            var invoice = new Invoice()
            {
                CustomerId = Bill.CustomerId,
                TotalAmount = (int)Convert.ToDecimal(Bill.TotalAmount),
                TotalBillAmount = (int) Convert.ToDecimal(0.0m),
                DateCreated = DateTime.Now
            };

            var customerDetails = await _context.Customer.Include(s => s.CustomerType).Where(x => x.Id == Bill.CustomerId).FirstOrDefaultAsync();

            if (customerDetails != null)
            {
                var discount = _context.Discount.Where(c => c.CustomerTypeId == customerDetails.CUstomerTypeID).FirstOrDefault();

                if (discount != null)
                {
                    var balanceDue = 0.0m;

                    if ((customerDetails.CustomerType.Name == HardCodes.CustomerTypeCodes.OldCustomer && customerDetails.DateCreated.AddYears(2) >= DateTime.Now)
                        || (customerDetails.CustomerType.Name == HardCodes.CustomerTypeCodes.Affiliate)
                        || (customerDetails.CustomerType.Name == HardCodes.CustomerTypeCodes.Employee))
                    {
                        balanceDue = Bill.TotalAmount - (discount.Value * Bill.TotalAmount);

                        invoice.TotalBillAmount = (int)Convert.ToDecimal(balanceDue);

                        return await saveChanges(invoice);
                    }
                    else
                    {
                        discount = _context.Discount.Where(s => s.IsFixed == true).FirstOrDefault();
                        int amount = (int)(Bill.TotalAmount / HardCodes.DiscountFrequency.Value);
                        balanceDue = Bill.TotalAmount - ((discount.Value * amount));

                        invoice.TotalBillAmount = (int)Convert.ToDecimal(balanceDue);

                        return await saveChanges(invoice);
                    }
                }

            }

            throw new ArgumentNullException(nameof(customerDetails));
        }

        private async Task<Invoice> saveChanges(Invoice Invoice)
        {
            _context.Invoice.Add(Invoice);
            await _context.SaveChangesAsync();

            return Invoice;
        }
    }
}
