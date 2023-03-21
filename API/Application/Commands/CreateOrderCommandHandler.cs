using Domain.Aggregates.OrderAggregate;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
    {
        private readonly IOrderRepository _orderRepositoryy;

        public CreateOrderCommandHandler(IOrderRepository orderRepositoryy)
        {
            _orderRepositoryy = orderRepositoryy;
        }

        public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _orderRepositoryy.Add(request._order); 

            await _orderRepositoryy.UnitOfWork.SaveEntitiesAsync();

            return order;

        }

    }
}
