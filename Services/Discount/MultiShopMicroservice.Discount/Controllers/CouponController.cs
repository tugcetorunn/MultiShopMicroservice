using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShopMicroservice.Discount.Dtos;
using MultiShopMicroservice.Discount.Services;

namespace MultiShopMicroservice.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly ICouponService couponService;
        public CouponController(ICouponService _couponService)
        {
            couponService = _couponService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCoupons() 
        {
            var coupons = await couponService.GetCouponsAsync();
            return Ok(coupons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCouponByIdAsync(int id)
        {
            var coupon = await couponService.GetCouponByIdAsync(id);
            return Ok(coupon);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoupon(CreateCouponDto createCouponDto)
        {
            await couponService.CreateCouponAsync(createCouponDto);
            return Ok(createCouponDto);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCoupon(int id)
        {
            await couponService.DeleteCouponAsync(id);
            return Ok(id);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCoupon(UpdateCouponDto updateCouponDto)
        {
            await couponService.UpdateCouponAsync(updateCouponDto);
            return Ok(updateCouponDto);
        }
    }
}
