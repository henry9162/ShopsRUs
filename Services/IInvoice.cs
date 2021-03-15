using ShopsRUs.Model;
using ShopsRUs.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Services
{
    public interface IInvoice
    {
        Task<Invoice> GenerateInvoice(InvoiceDTO Bill);
        Task<IEnumerable<Invoice>> GetAllInvoice();
        Task<Invoice> GetInvoiceById(Guid Id);
        Task<IEnumerable<Invoice>> GetInvoiceByCustomerId(Guid Id);
    }
}
