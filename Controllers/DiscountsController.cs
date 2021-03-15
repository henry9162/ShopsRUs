using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopsRUs.Data;
using ShopsRUs.Model;
using ShopsRUs.Services;
using ShopsRUs.ViewModel;
using static ShopsRUs.CommonClasses.HardCodes;

namespace ShopsRUs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : BaseController
    {
        private readonly IDiscount _repo;

        public DiscountsController(IDiscount repo)
        {
            _repo = repo;
        }

        [HttpGet("GetAllDiscounts")]
        public async Task<ActionResult<Discount>> GetDiscount()
        {
            var discounts =  await _repo.GetAllDiscount();
            return Ok(BindOutput(StatusCodes.Status200OK, RequestState.Success, "Retreived record successfully", discounts));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Discount>> GetDiscount(Guid id)
        {
            try
            {
                var discount = await _repo.GetDiscountById(id);

                if (discount != null)
                    return Ok(BindOutput(StatusCodes.Status200OK, RequestState.Success, "Retrived record successfully", discount));
                else
                    return NotFound(BindOutput(StatusCodes.Status404NotFound, RequestState.Failed, "Unable to retrieve record"));
            }
            catch (Exception ex)
            {
                return BadRequest(BindOutput(StatusCodes.Status400BadRequest, RequestState.Error, ex.Message));
            }
        }

        [HttpGet("getDiscountPercentageByType/{id}")]
        public async Task<ActionResult<Discount>> GetDiscountByType(Guid id)
        {
            try
            {
                var discount = await _repo.GetDiscountByType(id);

                if (discount != null)
                    return Ok(BindOutput(StatusCodes.Status200OK, RequestState.Success, "Retrived record successfully", discount));
                else
                    return NotFound(BindOutput(StatusCodes.Status404NotFound, RequestState.Failed, "Unable to retrieve record"));
            }
            catch (Exception ex)
            {
                return BadRequest(BindOutput(StatusCodes.Status400BadRequest, RequestState.Error, ex.Message));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiscount(Guid id, DiscountDTO discount)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var updatedDiscount = await _repo.UpdateDiscount(id, discount);

                if (updatedDiscount != null)
                    return Ok(BindOutput(StatusCodes.Status200OK, RequestState.Success, "Updated record successfully", updatedDiscount));
                else
                    return NotFound(BindOutput(StatusCodes.Status404NotFound, RequestState.Failed, "Could nnot retrive record"));
            }
            catch (Exception ex)
            {
                return BadRequest(BindOutput(StatusCodes.Status400BadRequest, RequestState.Error, ex.Message));
            }
        }

        [HttpPost]
        public async Task<ActionResult<Discount>> PostDiscount(DiscountDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var discount = await _repo.createDiscount(dto);

                if (discount != null)
                    return Ok(BindOutput(StatusCodes.Status201Created, RequestState.Success, "Retreived Successfuly", discount));
                else
                    return NotFound(BindOutput(StatusCodes.Status404NotFound, RequestState.Failed, "Unable to retrieve record"));
            }
            catch (Exception ex)
            {
                return BadRequest(BindOutput(StatusCodes.Status400BadRequest, RequestState.Error, ex.Message));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Discount>> DeleteDiscount(Guid id)
        {
            try
            {
                var discount = await _repo.deleteDiscount(id);
                if (discount != null)
                    return Ok(BindOutput(StatusCodes.Status200OK, RequestState.Success, "Deleted record successfully"));
                else
                    return NotFound(BindOutput(StatusCodes.Status404NotFound, RequestState.Failed, "Could not retrieve record"));


            }
            catch (Exception ex)
            {
                return BadRequest(BindOutput(StatusCodes.Status400BadRequest, RequestState.Error, ex.Message));
            }
        }
    }
}
