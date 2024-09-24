using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShopMicroservice.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShopMicroservice.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShopMicroservice.Order.Application.Features.Mediator.Queries.OrderingQueries;

namespace MultiShopMicroservice.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingController : ControllerBase
    {
        private readonly IMediator mediator;
        public OrderingController(IMediator _mediator)
        {
            mediator = _mediator; // bu atamayı unutursak program şu hatayı fırlatıyor. -> System.NullReferenceException: 'Object reference not set to an instance of an object.'
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderingsAsync()
        {
            var orderings = await mediator.Send(new GetOrderingsQuery());
            return Ok(orderings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderingByIdAsync(int id) 
        {
            var ordering = await mediator.Send(new GetOrderingByIdQuery(id));
            return Ok(ordering);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderingAsync(CreateOrderingCommand command)
        {
            // await mediator.Send(new CreateOrderingCommand() { OrderDate = command.OrderDate, OrderPrice = command.OrderPrice, UserId = command.UserId});
            // normalde mediator ün hangi handlerı tetikleyeceğini send olarak gönderdiğimiz command veya querylerle sağlarız.
            // fakat controller metodunun parametresinde zaten command gönderiyoruz. bunu mediator e verdiğimiz tipinden nereyi
            // tetiklemesi gerektiğini anlayacaktır.
            await mediator.Send(command);
            return Ok(command);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderingAsync(UpdateOrderingCommand command)
        {
            //await mediator.Send(new UpdateOrderingCommand() { OrderDate = command.OrderDate, UserId = command.UserId, OrderPrice = command.OrderPrice, OrderingId = command.OrderingId});
            await mediator.Send(command);
            return Ok(command);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrderingAsync(int id)
        {
            await mediator.Send(new DeleteOrderingCommand(id));
            return Ok(id);
        }
    }
}
