﻿namespace MultiShopMicroservice.Discount.Entities
{
    public class Coupon
    {
        public int CouponId { get; set; }
        public string CouponName { get; set; }
        public string Code { get; set; }
        public int Rate { get; set; } // indirim oranı
        public bool IsActive { get; set; }
        public DateTime ValidDate { get; set; } // son geçerlilik tarihi

    }
}
