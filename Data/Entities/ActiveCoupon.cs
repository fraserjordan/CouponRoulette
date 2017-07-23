using System;

namespace Data.Entities
{
    public class ActiveCoupon
    {
        public int Id { get; set; }
        public string CouponText { get; set; }
        public DateTime DateTimeRedeemed { get; set; }
    }
}
