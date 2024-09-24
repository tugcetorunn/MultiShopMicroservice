using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShopMicroservice.Order.Application.Features.Mediator.Results.OrderingResults
{
    public class GetOrderingByIdQueryResult
    {// kullanıcıya gönderilecek ve gösterilecek parametreler yazılır.
        public int OrderingId { get; set; }
        public string UserId { get; set; }
        public decimal OrderPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
