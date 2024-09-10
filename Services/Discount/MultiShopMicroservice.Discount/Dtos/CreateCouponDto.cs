﻿namespace MultiShopMicroservice.Discount.Dtos
{
    public class CreateCouponDto
    {
        public string CouponName { get; set; }
        public string Code { get; set; }
        public int Rate { get; set; }
        public bool IsActive { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
