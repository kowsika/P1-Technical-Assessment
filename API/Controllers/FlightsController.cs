using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using API.ApiResponses;
using Domain.Aggregates.FlightAggregate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class FlightsController : ControllerBase
{
    /// <summary>
    /// Get available flights
    /// </summary>
    /// <remarks>Get list of flights</remarks>
    /// <param name="destination">specific destination</param>
    /// <response code="200">Returned</response>
    /// <response code="400">Bad Request</response>
    /// <response code="401">Authorization fail</response>

    private IFlightRepository flightRepo;

    [HttpGet]
    [Route("Search")]
    public ActionResult GetAvailableFlights(string destination)
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

                    Task<List<Flight>> res = flightRepo.GetFlights(destination);
                    if (res.IsCompletedSuccessfully)
                    {
                        List<FlightResponse> res1 = new List<FlightResponse>();
                        if (res.Result.Count > 0)
                        {
                            foreach (var item in res.Result)
                            {

                                string DepartureAirportCode = item.OriginAirportId.ToString();
                                string ArrivalAirportCode = item.DestinationAirportId.ToString();
                                DateTimeOffset Departure = item.Departure;
                                DateTimeOffset Arrival = item.Arrival;
                                decimal PriceFrom = item.Rates.Min(r => r.Price).Value;
                                res1.Add(new FlightResponse(DepartureAirportCode, ArrivalAirportCode, Departure, Arrival, PriceFrom));
                            }

                            return Ok(res1);
                        }
                        else
                        {
                            return NoContent();
                        }


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

}
