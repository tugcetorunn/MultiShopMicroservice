using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShopMicroservice.Order.Application.Features.CQRS.Queries.AddressQueries
{
    public class GetAddressByIdQuery // query ler get işlemlerinin parametrelerini tutacak, gösterilecek propertyler değil gerekli olan parametreler
    {
        public int Id { get; set; }

        // bir de bunu bir controllerda çağırırken constructor üzerinden yani örneği oluşturarak çağıracağız. bu yüzden constructora ihtiyacımız var.
        public GetAddressByIdQuery(int id)
        {
            Id = id;
        }
        // getAddresses işleminde parametre vermediğimiz için query sini oluşturmamıza gerek yok.
    }
}
