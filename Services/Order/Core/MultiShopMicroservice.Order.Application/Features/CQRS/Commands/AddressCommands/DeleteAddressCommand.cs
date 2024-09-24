using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShopMicroservice.Order.Application.Features.CQRS.Commands.AddressCommands
{
    public class DeleteAddressCommand 
    {
        // delete işleminin parametresi aynı zamanda bu command çağrıldığında constructor üzerinden id yi kendi içindeki id ye atayacak.
        public int Id { get; set; } // handle edilirken kullanılacak property
        public DeleteAddressCommand(int id) // alınacak parametre
        {
            Id = id;
        }
    }
}
