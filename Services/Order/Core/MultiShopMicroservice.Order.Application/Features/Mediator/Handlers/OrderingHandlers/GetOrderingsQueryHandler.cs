using MediatR;
using MultiShopMicroservice.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MultiShopMicroservice.Order.Application.Features.Mediator.Results.OrderingResults;
using MultiShopMicroservice.Order.Application.Interfaces;
using MultiShopMicroservice.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShopMicroservice.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingsQueryHandler : IRequestHandler<GetOrderingsQuery, List<GetOrderingsQueryResult>>
    {
        private readonly IRepository<Ordering> repository;
        public GetOrderingsQueryHandler(IRepository<Ordering> _repository)
        {
            repository = _repository;
        }
        public async Task<List<GetOrderingsQueryResult>> Handle(GetOrderingsQuery request, CancellationToken cancellationToken)
        {
            var orderings = await repository.GetAllAsync();
            return orderings.Select(x => new GetOrderingsQueryResult()
            {
                OrderDate = x.OrderDate,
                OrderPrice = x.OrderPrice,
                UserId = x.UserId
            }).ToList();
        }
    }
}
