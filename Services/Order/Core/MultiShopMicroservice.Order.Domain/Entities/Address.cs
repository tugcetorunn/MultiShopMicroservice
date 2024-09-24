using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShopMicroservice.Order.Domain.Entities
{
    public class Address
    {
        public int AddressId { get; set; }
        public string UserId { get; set; } // kullanıcı id sine göre adres bilgisi alacağız.
        public string City { get; set; }
        public string District { get; set; }
        public string Detail { get; set; } // adres için geri kalan detaylar
    }
}
