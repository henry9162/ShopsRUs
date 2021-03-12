using Microsoft.EntityFrameworkCore;
using ShopsRUs.Model;
using ShopsRUs.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Data.Implementation
{
    public class MockICustomer : ICustomer
    {
        private readonly ShopsRUsContext _context;
        public MockICustomer(ShopsRUsContext context)
        {
            _context = context;
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

            _context.Customer.Add(newCustomer);
            await _context.SaveChangesAsync();

            return newCustomer;
        }

        public async Task<Customer> deleteCustomer(Guid id)
        {
            var customer = await _context.Customer.FindAsync(id);
            if(customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<List<Customer>> GetAllCustomer()
        {
             return await _context.Customer.Include(c=>c.CustomerType).ToListAsync();
        }

        public async Task<Customer> GetCustomerById(Guid id)
        {
            var customer = await _context.Customer.FindAsync(id);

            return customer;
        }

        public async Task<Customer> GetCustomerByName(String name)
        {
            var customer = await _context.Customer.Where(c => c.FirstName.ToLower() == name || c.LastName.ToLower() == name).FirstOrDefaultAsync();
            return customer;
        }

        public async Task<Customer> UpdateCustomer(Guid id, CustomerDTO customer)
        {
            try
            {
                var customerExist = await _context.Customer.Where(c => c.Id == id).FirstOrDefaultAsync();

                if (customerExist == null)
                {
                    throw new ArgumentNullException(nameof(customerExist));
                }

                customerExist.FirstName = customer.FirstName;
                customerExist.LastName = customer.LastName;
                customerExist.Email = customer.Email;
                customerExist.Address = customer.Address;
                customerExist.Phone = customer.Phone;
                customerExist.CUstomerTypeID = customer.CUstomerTypeID;

                _context.Update(customerExist);
                
                await _context.SaveChangesAsync();

                return customerExist;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
