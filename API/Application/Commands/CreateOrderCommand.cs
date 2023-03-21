using Domain.Aggregates.OrderAggregate;
using MediatR;

namespace API.Application.Commands
{
    public class CreateOrderCommand : IRequest<Order>
    {
        public Order _order { get; private set; }

        public CreateOrderCommand(Order order) 
        {
            _order = order;
        }

    }
}
