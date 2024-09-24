using MultiShopMicroservice.Order.Application.Features.CQRS.Commands.AddressCommands;
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
    public class CreateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> repository;
        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> _repository)
        {
            repository = _repository;
        }

        public async Task<OrderDetail> Handle(CreateOrderDetailCommand createOrderDetailCommand)
        {
            var detail = new OrderDetail()
            {
                Amount = createOrderDetailCommand.Amount,
                OrderingId = createOrderDetailCommand.OrderingId,
                Price = createOrderDetailCommand.Price,
                ProductId = createOrderDetailCommand.ProductId,
                ProductName = createOrderDetailCommand.ProductName,
                TotalPrice = createOrderDetailCommand.TotalPrice
            };

            await repository.CreateAsync(detail);
            return detail;
        }
    }
}
