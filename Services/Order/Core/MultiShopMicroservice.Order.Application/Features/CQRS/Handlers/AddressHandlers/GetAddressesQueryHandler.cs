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
    public class GetAddressesQueryHandler
    {
        private readonly IRepository<Address> repository;
        public GetAddressesQueryHandler(IRepository<Address> _repository)
        {
            repository = _repository;
        }

        public async Task<List<GetAddressesQueryResult>> Handle()
        {
            var addresses = await repository.GetAllAsync();
            return addresses.Select(x => new GetAddressesQueryResult() // addresses listesi içindeki seçmek kullanmak için select kullandık.
            {
                AddressId = x.AddressId,
                City = x.City,
                Detail = x.Detail,
                District = x.District,
                UserId = x.UserId
            }).ToList();
        }
    }
}
