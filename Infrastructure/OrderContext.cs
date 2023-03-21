using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.SeedWork;
using System.Threading;
using MediatR;

namespace Infrastructure
{
    public class OrderContext : DbContext, IUnitOfWork
    {
        private readonly IMediator _mediator;

        public OrderContext(DbContextOptions<FlightsContext> options) : base(options) { }

        public OrderContext(DbContextOptions<OrderContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEventsAsync(this);

            var result = await base.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
