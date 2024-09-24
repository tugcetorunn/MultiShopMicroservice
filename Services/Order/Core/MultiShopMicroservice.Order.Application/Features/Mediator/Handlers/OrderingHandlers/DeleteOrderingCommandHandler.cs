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
    public class DeleteOrderingCommandHandler : IRequestHandler<DeleteOrderingCommand>
    {
        private readonly IRepository<Ordering> repository;
        public DeleteOrderingCommandHandler(IRepository<Ordering> _repository)
        {
            repository = _repository;
        }
        public async Task Handle(DeleteOrderingCommand request, CancellationToken cancellationToken)
        {
            var ordering = await repository.GetByIdAsync(request.Id);
            await repository.DeleteAsync(ordering);
        }
    }
}
