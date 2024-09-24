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
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> repository;
        public UpdateAddressCommandHandler(IRepository<Address> _repository)
        {
            repository = _repository;
        }

        public async Task<Address> Handle(UpdateAddressCommand updateAddressCommand)
        {
            var address = await repository.GetByIdAsync(updateAddressCommand.AddressId);
            address.UserId = updateAddressCommand.UserId;
            address.District = updateAddressCommand.District;
            address.Detail = updateAddressCommand.Detail;
            address.City = updateAddressCommand.City;
            await repository.UpdateAsync(address);

            return address;
        }
    }
}
