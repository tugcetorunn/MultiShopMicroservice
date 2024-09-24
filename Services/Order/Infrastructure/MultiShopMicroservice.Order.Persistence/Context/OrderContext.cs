using Microsoft.EntityFrameworkCore;
using MultiShopMicroservice.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShopMicroservice.Order.Persistence.Context
{
    public class OrderContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {                                   // host, port
            optionsBuilder.UseSqlServer("Server=localhost,1440;Database=MultiShopOrder;User=sa;Password=2704Tt2704**");
            // migration yapmadan önce tools paketlerini webApi projesine de yükledikten sonra programın ayağa kalkacağı projeyi webApi (çünkü sql
            // bağlantısını oradan kuracağız), package manager console(pmc) daki default projeyi de context sınıfımızın olduğu persistence projesini seçiyoruz.
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Ordering> Orderings { get; set; }
    }
}
