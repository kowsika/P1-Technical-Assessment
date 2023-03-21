
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions;
using Domain.SeedWork;

namespace Domain.Aggregates.OrderAggregate
{
    public class Order : Entity, IAggregateRoot 
    {
        public Guid DepartFromId { get; private set; }
        
        public Guid DestinationAirportId { get; private set; }

        public DateTimeOffset DepartureDate { get; private set; }
        
        public DateTimeOffset ReturnDate { get; private set; }

        public string classCode { get; private set; }

        public int NumberOfTraveller { get; private set; } 


    }
}
