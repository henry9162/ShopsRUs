using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopsRUs.CommonClasses;
using ShopsRUs.Data;
using ShopsRUs.Model;
using ShopsRUs.ViewModel;

namespace ShopsRUs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly ShopsRUsContext _context;

        public InvoiceController(ShopsRUsContext context)
        {
            _context = context;
        }


        // GET: api/Invoices/5
        [HttpPost("GetTotalInvoiceAmount")]
        public async Task<IActionResult> GetTotalInvoiceAmount(InvoiceDTO Bill)
        {
            try
            {
                if (Bill.CustomerId == null || Bill.TotalAmount < 1)
                {
                    return BadRequest("CustomerId and amount cannot be empty");
                }
                //use customer type to get the discount by customer
                var customerDetails = _context.Customer.Include(s => s.CustomerType).Where(x => x.Id == Bill.CustomerId).FirstOrDefault();
                if (customerDetails != null)
                {
                    var discount = _context.Discount.Where(c => c.CustomerTypeId == customerDetails.CUstomerTypeID).FirstOrDefault();

                    if (discount != null)
                    {
                        var balanceDue = 0.0m;
                        //if the customer has spent upto 2 years
                        if ((customerDetails.CustomerType.Name == HardCodes.CustomerTypeCodes.Customer && customerDetails.DateCreated.AddYears(2) <= DateTime.Now)
                            || (customerDetails.CustomerType.Name == HardCodes.CustomerTypeCodes.Affiliate)
                            || (customerDetails.CustomerType.Name == HardCodes.CustomerTypeCodes.Employee))
                        {
                            balanceDue = Bill.TotalAmount - (discount.Value * Bill.TotalAmount);

                            return Ok(balanceDue);
                        }
                        else
                        {
                            discount = _context.Discount.Where(s => s.CustomerTypeId == null).FirstOrDefault();
                            int amount = (int)(Bill.TotalAmount / Convert.ToDecimal(discount.Key));
                            balanceDue = Bill.TotalAmount - ((discount.Value * amount));

                            return Ok(balanceDue);

                        }
                    }
                }

                return Ok(Bill.TotalAmount);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
           
    }
}
