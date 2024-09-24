using MultiShopMicroservice.Order.Application.Features.CQRS.Queries.AddressQueries;
using MultiShopMicroservice.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShopMicroservice.Order.Application.Interfaces;
using MultiShopMicroservice.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShopMicroservice.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler
    {
        private readonly IRepository<Address> repository;
        public GetAddressByIdQueryHandler(IRepository<Address> _repository)
        {
            repository = _repository;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery getAddressByIdQuery)
        {
            var address = await repository.GetByIdAsync(getAddressByIdQuery.Id);
            return new GetAddressByIdQueryResult()
            {
                // mapleme yapmadığımız için yine burada da atama yapıyoruz.
                AddressId = address.AddressId,
                City = address.City,
                Detail = address.Detail,
                District = address.District,
                UserId = address.UserId,
            };

        }
    }
}
