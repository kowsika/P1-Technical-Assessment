using Domain.Aggregates.FlightAggregate;
using MediatR;
using System.Collections.Generic;

namespace API.Application.Commands
{
    public class SearchFlightCommand : IRequest<List<Flight>>
    {
        public string Destination { get; private set; }

        public SearchFlightCommand(string destination)
        {
            Destination = destination;
        }
    }
}
