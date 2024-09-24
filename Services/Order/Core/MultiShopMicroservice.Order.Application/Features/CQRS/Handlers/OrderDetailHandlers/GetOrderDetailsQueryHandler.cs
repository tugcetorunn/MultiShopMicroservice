using MultiShopMicroservice.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShopMicroservice.Order.Application.Interfaces;
using MultiShopMicroservice.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShopMicroservice.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailsQueryHandler
    {
        private readonly IRepository<OrderDetail> repository;
        public GetOrderDetailsQueryHandler(IRepository<OrderDetail> _repository)
        {
            repository = _repository;
        }

        public async Task<List<GetOrderDetailsQueryResult>> Handle()
        {
            var details = await repository.GetAllAsync();
            return details.Select(x => new GetOrderDetailsQueryResult()
            {
                OrderDetailId = x.OrderDetailId,
                Amount = x.Amount,
                OrderingId = x.OrderingId,
                Price = x.Price,
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                TotalPrice = x.TotalPrice
            }).ToList();
        }
    }
}
