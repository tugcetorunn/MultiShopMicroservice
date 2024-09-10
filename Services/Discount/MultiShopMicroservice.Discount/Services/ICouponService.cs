using MultiShopMicroservice.Discount.Dtos;

namespace MultiShopMicroservice.Discount.Services
{
    public interface ICouponService
    {
        Task<List<ResultCouponDto>> GetCouponsAsync();
        Task CreateCouponAsync(CreateCouponDto createCouponDto);
        Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);
        Task DeleteCouponAsync(int id);
        Task<GetCouponByIdDto> GetCouponByIdAsync(int id);
    }
}
