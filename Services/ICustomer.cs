using Microsoft.AspNetCore.Mvc;
using ShopsRUs.Model;
using ShopsRUs.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Services
{
    public interface ICustomer
    {
        Task<IEnumerable<Customer>> GetAllCustomer();
        Task<Customer> GetCustomerById(Guid id);
        Task<Customer> GetCustomerByName(String name);
        Task<Customer> createCustomer(CustomerDTO customer);
        Task<Customer> deleteCustomer(Guid id);
        Task<Customer> UpdateCustomer(Guid id, CustomerDTO customer);
    }
}
