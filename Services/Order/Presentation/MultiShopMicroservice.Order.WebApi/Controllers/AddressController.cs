using Microsoft.AspNetCore.Mvc;
using MultiShopMicroservice.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShopMicroservice.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShopMicroservice.Order.Application.Features.CQRS.Queries.AddressQueries;

namespace MultiShopMicroservice.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        // mediator (arabulucu) patterni kullanılmadığında aşağıdaki gibi handlerlarla doğrudan iletişim kurarak kaotik bir bağımlılık
        // oluşmuş oldu. burada 5 tane ama yüzlerce handler kullandığımız projeler olabilir.
        // mediator ün arabulucu özelliği kule ile uçaklardaki pilotların arasındaki gibidir. kule hangi uçağın nereye ne zaman ineceğini
        // bildirir. yazılımda da mediator içinde bulundurduğu send metodu ile sadece command ve query gönderdiğimizde hangi handlerın
        // çağrılacağını bilir. bunu belli interfaceler ile yapar. mediator böylelikle merkezi bir sistem olmuş olur.
        private readonly GetAddressesQueryHandler getAddressesQueryHandler;
        private readonly GetAddressByIdQueryHandler getAddressByIdQueryHandler;
        private readonly CreateAddressCommandHandler createAddressCommandHandler;
        private readonly UpdateAddressCommandHandler updateAddressCommandHandler;
        private readonly DeleteAddressCommandHandler deleteAddressCommandHandler;

        public AddressController(GetAddressesQueryHandler _getAddressesQueryHandler, GetAddressByIdQueryHandler _getAddressByIdQueryHandler, CreateAddressCommandHandler _createAddressCommandHandler, UpdateAddressCommandHandler _updateAddressCommandHandler, DeleteAddressCommandHandler _deleteAddressCommandHandler)
        {
            getAddressesQueryHandler = _getAddressesQueryHandler;
            getAddressByIdQueryHandler = _getAddressByIdQueryHandler;
            createAddressCommandHandler = _createAddressCommandHandler;
            updateAddressCommandHandler = _updateAddressCommandHandler;
            deleteAddressCommandHandler = _deleteAddressCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAddresses()
        {
            var addresses = await getAddressesQueryHandler.Handle();
            return Ok(addresses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressById(int id)
        {                                                           // mediatr olmadığı için parametre alan query lere kendimiz ulaşıyoruz.
            var address = await getAddressByIdQueryHandler.Handle(new GetAddressByIdQuery(id));
            return Ok(address);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var result = await deleteAddressCommandHandler.Handle(new DeleteAddressCommand(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
        {
            var newAddress = await createAddressCommandHandler.Handle(command);
            return Ok(newAddress);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand command)
        {
            var address = await updateAddressCommandHandler.Handle(command);
            return Ok(address);
        }
    }
}
