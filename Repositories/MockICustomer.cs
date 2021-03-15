using Microsoft.AspNetCore.Mvc;
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
    public class MockICustomer : ICustomer
    {
        private readonly ShopsRUsContext _context;
        public MockICustomer(ShopsRUsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomer()
        {
            return await _context.Customer.Include(c => c.CustomerType).ToListAsync();
        }

        public async Task<Customer> GetCustomerById(Guid id)
        {
            return await _context.Customer.FindAsync(id);
        }

        public async Task<Customer> GetCustomerByName(String name)
        {
            return await _context.Customer.Where(c => c.FirstName.ToLower() == name || c.LastName.ToLower() == name).FirstOrDefaultAsync();
        }

        public async Task<Customer> createCustomer(CustomerDTO customer)
        {
            var newCustomer = new Customer()
            {
                Address = customer.Address,
                CUstomerTypeID = customer.CUstomerTypeID,
                DateCreated = DateTime.Now,
                Email = customer.Email,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Phone = customer.Phone
            };

            return await saveChanges(newCustomer, SaveChangesCodes.Add);
        }

        public async Task<Customer> UpdateCustomer(Guid id, CustomerDTO customer)
        {
            var customerExist = await _context.Customer.Where(c => c.Id == id).FirstOrDefaultAsync();

            customerExist.FirstName = customer.FirstName;
            customerExist.LastName = customer.LastName;
            customerExist.Email = customer.Email;
            customerExist.Address = customer.Address;
            customerExist.Phone = customer.Phone;
            customerExist.CUstomerTypeID = customer.CUstomerTypeID;

            return await saveChanges(customerExist, SaveChangesCodes.Update);
        }

        public async Task<Customer> deleteCustomer(Guid id)
        {
            var customer = await _context.Customer.Where(c => c.Id == id).FirstOrDefaultAsync();
           
            return await saveChanges(customer, SaveChangesCodes.Delete);
        }

        private async Task<Customer> saveChanges(Customer customer, int type)
        {
            if (type == SaveChangesCodes.Add)
            {
                _context.Customer.Add(customer);
               await _context.SaveChangesAsync();
            }
            else if (type == SaveChangesCodes.Update)
            {
                _context.Customer.Update(customer);
                await _context.SaveChangesAsync();
            }
            else if(type == SaveChangesCodes.Delete)
            {
                _context.Customer.Remove(customer);
                await _context.SaveChangesAsync();
            }

            return customer;
        }
    }
}
