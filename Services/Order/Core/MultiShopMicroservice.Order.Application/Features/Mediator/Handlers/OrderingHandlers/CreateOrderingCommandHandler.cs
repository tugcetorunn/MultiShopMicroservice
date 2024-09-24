using MediatR;
using MultiShopMicroservice.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShopMicroservice.Order.Application.Interfaces;
using MultiShopMicroservice.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShopMicroservice.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class CreateOrderingCommandHandler : IRequestHandler<CreateOrderingCommand>
    {
        private readonly IRepository<Ordering> repository;
        public CreateOrderingCommandHandler(IRepository<Ordering> _repository)
        {
            repository = _repository;
        }
        public async Task Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
        {
            var newOrdering = new Ordering()
            {
                OrderDate = request.OrderDate,
                OrderPrice = request.OrderPrice,
                UserId = request.UserId
            };

            await repository.CreateAsync(newOrdering);
        }
    }
}
