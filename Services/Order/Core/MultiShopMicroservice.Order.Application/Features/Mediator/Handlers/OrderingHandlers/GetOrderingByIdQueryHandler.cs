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
    public class GetOrderingByIdQueryHandler : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
    {
        private readonly IRepository<Ordering> repository;
        public GetOrderingByIdQueryHandler(IRepository<Ordering> _repository)
        {
            repository = _repository;
        }
        public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
        {// cancellation token -> mesela bir sayfada post yapıyoruz, ama sayfa bir türlü yüklenmiyor. sekmeyi kapattığımızda da
         // işlemi iptal eden cancellation token oluyor.
            var ordering = await repository.GetByIdAsync(request.Id);
            return new GetOrderingByIdQueryResult()
            {
                OrderingId = ordering.OrderingId,
                OrderDate = ordering.OrderDate,
                OrderPrice = ordering.OrderPrice,
                UserId = ordering.UserId,
            };
        }
    }
}
