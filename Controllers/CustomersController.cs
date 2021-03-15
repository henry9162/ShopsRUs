using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopsRUs.Model;
using ShopsRUs.Services;
using ShopsRUs.ViewModel;
using static ShopsRUs.CommonClasses.HardCodes;

namespace ShopsRUs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : BaseController
    {
        private readonly ICustomer _repo;

        public CustomersController(ICustomer repo)
        {
            _repo = repo;
        }

        [HttpGet("GetAllCustomers")]
        public async Task<ActionResult<Customer>> GetCustomer()
        {
            var customers =  await _repo.GetAllCustomer();
            return Ok(BindOutput(StatusCodes.Status200OK, RequestState.Success, "Retrived record successfully", customers));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(Guid id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var customer = await _repo.GetCustomerById(id);

                if (customer != null)
                    return Ok(BindOutput(StatusCodes.Status200OK, RequestState.Success, "Retrived record successfully", customer));
                else
                    return NotFound(BindOutput(StatusCodes.Status404NotFound, RequestState.Failed, "Unable to retrieve record"));
            } catch(Exception ex)
            {
                return BadRequest(BindOutput(StatusCodes.Status400BadRequest, RequestState.Error, ex.Message));
            }
            
        }

        [HttpGet("getCustomerByName/{name}")]
        public async Task<ActionResult<Customer>> GetCustomer(String name)
        {
            try
            {
                var customer = await _repo.GetCustomerByName(name);

                if (customer != null)
                    return Ok(BindOutput(StatusCodes.Status200OK, RequestState.Success, "Retrived record successfully", customer));
                else
                    return NotFound(BindOutput(StatusCodes.Status404NotFound, RequestState.Failed, "Unable to retrieve record"));
            }
            catch (Exception ex)
            {
                return BadRequest(BindOutput(StatusCodes.Status400BadRequest, RequestState.Error, ex.Message));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(Guid id, CustomerDTO customer)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                
                var updatedCustomer = await _repo.UpdateCustomer(id, customer);

                if (updatedCustomer != null)
                    return Ok(BindOutput(StatusCodes.Status200OK, RequestState.Success, "Updated record successfully", updatedCustomer));
                else
                    return NotFound(BindOutput(StatusCodes.Status404NotFound, RequestState.Failed, "Could nnot retrive record"));
            }
            catch(Exception ex)
            {
                return BadRequest(BindOutput(StatusCodes.Status400BadRequest, RequestState.Error, ex.Message));
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomer(CustomerDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var customer = await _repo.createCustomer(dto);

                if (customer != null)
                    return Ok(BindOutput(StatusCodes.Status201Created, RequestState.Success, "Retreived Successfuly", customer));
                else
                    return NotFound(BindOutput(StatusCodes.Status404NotFound, RequestState.Failed, "Unable to retrieve record"));
            }
            catch(Exception ex)
            {
                return BadRequest(BindOutput(StatusCodes.Status400BadRequest, RequestState.Error, ex.Message));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(Guid id)
        {
            try
            {
                var customer = await _repo.deleteCustomer(id);
                if (customer != null)
                    return Ok(BindOutput(StatusCodes.Status200OK, RequestState.Success, "Deleted record successfully"));
                else
                    return NotFound(BindOutput(StatusCodes.Status404NotFound, RequestState.Failed, "Could not retrieve record"));
                

            } catch (Exception ex)
            {
                return BadRequest(BindOutput(StatusCodes.Status400BadRequest, RequestState.Error, ex.Message));
            }
        }
    }
}
