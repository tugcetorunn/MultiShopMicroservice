using Dapper;
using MultiShopMicroservice.Discount.Context;
using MultiShopMicroservice.Discount.Dtos;

namespace MultiShopMicroservice.Discount.Services
{
    public class CouponService : ICouponService
    {
        private readonly DapperContext context;
        public CouponService(DapperContext _context)
        {
            context = _context;
        }
        public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            string query = "insert into Coupons (CouponName, Code, Rate, IsActive, ValidDate) values (@couponName, @code, @rate, @isActive, @validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@couponName", createCouponDto.CouponName);
            parameters.Add("@code", createCouponDto.Code);
            parameters.Add("@rate", createCouponDto.Rate);
            parameters.Add("@isActive", createCouponDto.IsActive);
            parameters.Add("@validDate", createCouponDto.ValidDate);

            using (var connection = context.CreateConnection()) // context te çağrıldığında yeni bir db bağlantısı oluşturan metodu çağırıyoruz.
            {
                await connection.ExecuteAsync(query, parameters); // yukarıda parametrelerle gönderdiğimiz sorguyu bağlantıya gönderir ve uygular.
            }
        }

        public async Task DeleteCouponAsync(int id)
        {
            string query = "delete from Coupons where CouponId = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", id);

            using(var connection = context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetCouponByIdDto> GetCouponByIdAsync(int id)
        {
            string query = "select * from Coupons where CouponId = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", id);

            using(var connection = context.CreateConnection())
            {
                var coupon = await connection.QueryFirstOrDefaultAsync<GetCouponByIdDto>(query, parameters);
                return coupon;
            }
        }

        public async Task<List<ResultCouponDto>> GetCouponsAsync()
        {
            string query = "select * from Coupons";
            
            using(var connection = context.CreateConnection())
            {
                var coupons = await connection.QueryAsync<ResultCouponDto>(query);
                return coupons.ToList();
            }
        }

        public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            string query = "update Coupons set CouponName = @couponName, Code = @code, Rate = @rate, IsActive = @isActive, ValidDate = @validDate where CouponId = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponName", updateCouponDto.CouponName);
            parameters.Add("@code", updateCouponDto.Code);
            parameters.Add("@rate", updateCouponDto.Rate);
            parameters.Add("@isActive", updateCouponDto.IsActive);
            parameters.Add("@validDate", updateCouponDto.ValidDate);
            parameters.Add("@couponId", updateCouponDto.CouponId);

            using (var connection = context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }
    }
}
