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
    public class DeleteAddressCommandHandler
    {
        private readonly IRepository<Address> repository;
        public DeleteAddressCommandHandler(IRepository<Address> _repository)
        {
            repository = _repository;
        }

        public async Task<bool> Handle(DeleteAddressCommand deleteAddressCommand)
        {
            var address = await repository.GetByIdAsync(deleteAddressCommand.Id);
            await repository.DeleteAsync(address);
            return true;           
        }
    }
}
