using MultiShopMicroservice.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShopMicroservice.Order.Application.Interfaces;
using MultiShopMicroservice.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShopMicroservice.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class CreateAddressCommandHandler
    {
        // onion architecture kullandığımız order microservice inde merkez katman domain (merkez katman) her yere referans verebilir.
        private readonly IRepository<Address> repository;
        public CreateAddressCommandHandler(IRepository<Address> _repository)
        {
            repository = _repository;
        }

        public async Task<Address> Handle(CreateAddressCommand createAddressCommand)
        {
            var newAddress = new Address()
            { // mapleme yapmadığımız için tek tek atama yapmalıyız.
                UserId = createAddressCommand.UserId,
                City = createAddressCommand.City,
                Detail = createAddressCommand.Detail,
                District = createAddressCommand.District
            };
            await repository.CreateAsync(newAddress);
            return newAddress;           
            
        }

    }
}
