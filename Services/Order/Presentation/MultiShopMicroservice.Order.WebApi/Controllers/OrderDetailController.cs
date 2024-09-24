using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShopMicroservice.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShopMicroservice.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShopMicroservice.Order.Application.Features.CQRS.Queries.OrderDetailQueries;

namespace MultiShopMicroservice.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly GetOrderDetailsQueryHandler getOrderDetailsQueryHandler;
        private readonly GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler;
        private readonly CreateOrderDetailCommandHandler createOrderDetailCommandHandler;
        private readonly UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler;
        private readonly DeleteOrderDetailCommandHandler deleteOrderDetailCommandHandler;

        public OrderDetailController(GetOrderDetailsQueryHandler _getOrderDetailesQueryHandler, GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryHandler, CreateOrderDetailCommandHandler _createOrderDetailCommandHandler, UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler, DeleteOrderDetailCommandHandler _deleteOrderDetailCommandHandler)
        {
            getOrderDetailsQueryHandler = _getOrderDetailesQueryHandler;
            getOrderDetailByIdQueryHandler = _getOrderDetailByIdQueryHandler;
            createOrderDetailCommandHandler = _createOrderDetailCommandHandler;
            updateOrderDetailCommandHandler = _updateOrderDetailCommandHandler;
            deleteOrderDetailCommandHandler = _deleteOrderDetailCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderDetailes()
        {
            var details = await getOrderDetailsQueryHandler.Handle();
            return Ok(details);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetailById(int id)
        {                                                           // mediatr olmadığı için parametre alan query lere kendimiz ulaşıyoruz.
            var detail = await getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));
            return Ok(detail);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            var result = await deleteOrderDetailCommandHandler.Handle(new DeleteOrderDetailCommand(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
        {
            var newOrderDetail = await createOrderDetailCommandHandler.Handle(command);
            return Ok(newOrderDetail);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
        {
            var OrderDetail = await updateOrderDetailCommandHandler.Handle(command);
            return Ok(OrderDetail);
        }
    }
}
