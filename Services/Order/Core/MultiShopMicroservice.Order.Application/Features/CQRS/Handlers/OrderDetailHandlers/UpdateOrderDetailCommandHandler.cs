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
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> repository;
        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> _repository)
        {
            repository = _repository;
        }

        public async Task<OrderDetail> Handle(UpdateOrderDetailCommand updateOrderDetailCommand)
        {
            var detail = await repository.GetByIdAsync(updateOrderDetailCommand.OrderDetailId);
            
            detail.OrderingId = updateOrderDetailCommand.OrderingId;
            detail.Price = updateOrderDetailCommand.Price;
            detail.TotalPrice = updateOrderDetailCommand.TotalPrice;
            detail.ProductName = updateOrderDetailCommand.ProductName;
            detail.Amount = updateOrderDetailCommand.Amount;
            detail.ProductId = updateOrderDetailCommand.ProductId;

            await repository.UpdateAsync(detail);

            return detail;
            
        }
    }
}
