using MultiShopMicroservice.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
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
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> repository;
        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> _repository)
        {
            repository = _repository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery getOrderDetailByIdQuery)
        {
            var detail = await repository.GetByIdAsync(getOrderDetailByIdQuery.Id);
            return new GetOrderDetailByIdQueryResult()
            {
                OrderDetailId = detail.OrderDetailId,
                Amount = detail.Amount,
                OrderingId = detail.OrderingId,
                Price = detail.Price,
                ProductId = detail.ProductId,
                ProductName = detail.ProductName,
                TotalPrice = detail.TotalPrice
            };
        } 
    }
}
