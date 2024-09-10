using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MultiShopMicroservice.Discount.Entities;
using System.Data;

namespace MultiShopMicroservice.Discount.Context
{
    public class DapperContext : DbContext
    {
        // appsettings ten connStr alacağız.
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        public DapperContext(IConfiguration _configuration)
        {
            configuration = _configuration;
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // tablolarımızı en başta bu bağlantı ile göndereceğiz. daha sonra appsettings ten alacağız.
            //optionsBuilder.UseSqlServer("Server=DESKTOP-ATVPBPS;Database=MultiShopDiscount;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True");
        }

        public DbSet<Coupon> Coupons { get; set; }
        // bu metod çağrıldığı zaman yeni bir sql connection bağlantısı oluşturacak.
        public IDbConnection CreateConnection() => new SqlConnection(connectionString);
    }
}
