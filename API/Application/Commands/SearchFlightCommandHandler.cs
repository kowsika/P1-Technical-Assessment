using Domain.Aggregates.FlightAggregate;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Commands
{
   
    public class SearchFlightCommandHandler : IRequestHandler<SearchFlightCommand, List<Flight>>
    {
        private readonly IFlightRepository _flightRepository;

        public SearchFlightCommandHandler(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }


        //public async List<Flight> Handle(SearchFlightCommand request, CancellationToken cancellationToken)
        //{
        //    List<Flight> flights = _flightRepository.GetFlights(request.Destination);

        //    return flights;
        //}

        Task<List<Flight>> IRequestHandler<SearchFlightCommand, List<Flight>>.Handle(SearchFlightCommand request, CancellationToken cancellationToken)
        {
            Task<List<Flight>> flights = _flightRepository.GetFlights(request.Destination);
            return flights;
        }
    }
}
