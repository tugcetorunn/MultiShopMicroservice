using MediatR;
using MultiShopMicroservice.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShopMicroservice.Order.Application.Features.Mediator.Commands.OrderingCommands
{
    public class CreateOrderingCommand : IRequest
    { // return boş dönecekse bir çıktı yoksa IRequest içine bir şey yazılmaz.
        public string UserId { get; set; }
        public decimal OrderPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
