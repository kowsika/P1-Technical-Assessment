using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.ApiResponses;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class FlightsController : ControllerBase
{
    private readonly FlightsContext _context;

    public FlightsController(FlightsContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("Search")]
    public async Task<IEnumerable<FlightResponse>> GetAvailableFlights()
    {
        throw new NotImplementedException();
    }
}