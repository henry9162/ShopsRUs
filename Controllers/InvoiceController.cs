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
using ShopsRUs.Services;
using ShopsRUs.ViewModel;
using static ShopsRUs.CommonClasses.HardCodes;

namespace ShopsRUs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : BaseController
    {
        private readonly IInvoice _repo;

        public InvoiceController(IInvoice repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<Invoice>> GetAllInvoice()
        {
            var invoices =  await _repo.GetAllInvoice();

            return Ok(BindOutput(StatusCodes.Status200OK, RequestState.Success, "Retrived record successfully", invoices));
        }

        [HttpGet("GetInvoiceByCustomerId/{id}")]
        public async Task<ActionResult<Invoice>> GetInvoiceByCustomerId(Guid id)
        {
            var invoices = await _repo.GetInvoiceByCustomerId(id);

            return Ok(BindOutput(StatusCodes.Status200OK, RequestState.Success, "Retrived record successfully", invoices));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetInvoiceById(Guid id)
        {
            try
            {
                var invoice = await _repo.GetInvoiceById(id);

                if (invoice != null)
                    return Ok(BindOutput(StatusCodes.Status200OK, RequestState.Success, "Retrived record successfully", invoice));
                else
                    return NotFound(BindOutput(StatusCodes.Status404NotFound, RequestState.Failed, "Unable to retrieve record"));
            }
            catch (Exception ex)
            {
                return BadRequest(BindOutput(StatusCodes.Status400BadRequest, RequestState.Error, ex.Message));
            }

        }

        [HttpPost("GenerateInvoice")]
        public async Task<IActionResult> GenerateInvoice(InvoiceDTO Bill)
        {
            try
            {
                if (Bill.CustomerId == null || Bill.TotalAmount < 1)
                {
                    return BadRequest("CustomerId and amount cannot be empty");
                }

                var invoice = await _repo.GenerateInvoice(Bill);

                return Ok(BindOutput(StatusCodes.Status200OK, RequestState.Success, "Retrieved record successfully", invoice));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
           
    }
}
