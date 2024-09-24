using MultiShopMicroservice.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShopMicroservice.Order.Application.Interfaces;
using MultiShopMicroservice.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShopMicroservice.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class DeleteOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> repository;
        public DeleteOrderDetailCommandHandler(IRepository<OrderDetail> _repository)
        {
            repository = _repository;
        }

        public async Task<bool> Handle(DeleteOrderDetailCommand deleteOrderDetailCommand)
        {
            var detail = await repository.GetByIdAsync(deleteOrderDetailCommand.Id);
            await repository.DeleteAsync(detail);
            return true;
        }
    }
}
