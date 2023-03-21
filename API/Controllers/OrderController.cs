using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using API.ApiResponses;
using Domain.Aggregates.FlightAggregate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Domain.Aggregates.OrderAggregate;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private IOrderRepository iOrderRepo;

        /// <summary>
        /// Place order
        /// </summary>
        /// <remarks>Place order</remarks>
        /// <param name="Order">specific order</param>
        /// <response code="200">Returned</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Authorization fail</response>
        [HttpPost]
        [Route("PlaceOrder")]
        public ActionResult PlaceAnOrder(Order order)
        {
            try
            {
                if (!User.Identity.IsAuthenticated)
                {
                    return Unauthorized("This user is not allow to view the available flights");

                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        var res = iOrderRepo.Add(order); 
                        if (res.Id .ToString()!= string.Empty) 
                        {
                            return Ok(res);

                        }
                        else
                        {
                            return Forbid();
                        }
                    }
                    else
                    {
                        return BadRequest("Invalid model");

                    }
                }
            }
            catch (Exception)
            {

                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Route("ConfirmOrder")]
        public ActionResult ConfirmAnOrder()
        {
            try
            {
                if (!User.Identity.IsAuthenticated)
                {
                    return Unauthorized("This user is not allow to view the available flights");

                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        return Ok();
                    }
                    else
                    {
                        return BadRequest("Invalid model");

                    }
                }
            }
            catch (Exception)
            {

                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
