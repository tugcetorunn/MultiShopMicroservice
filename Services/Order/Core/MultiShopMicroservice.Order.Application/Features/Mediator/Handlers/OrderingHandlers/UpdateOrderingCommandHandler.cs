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
    public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand>
    {
        private readonly IRepository<Ordering> repository;
        public UpdateOrderingCommandHandler(IRepository<Ordering> _repository)
        {
            repository = _repository;
        }
        public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
        {
            var ordering = await repository.GetByIdAsync(request.OrderingId);
            ordering.OrderDate = request.OrderDate;
            ordering.OrderPrice = request.OrderPrice;
            ordering.UserId = request.UserId;

            await repository.UpdateAsync(ordering);
        }
    }
}
