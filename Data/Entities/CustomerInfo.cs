using System;
using Data.Enums;

namespace Data.Entities
{
    public class CustomerInfo
    {
        public int Id { get; set; }
        public int CouponExpiredCount { get; set; }
        public int CompaintCount { get; set; }
        public virtual ActiveCoupon ActiveCoupon { get; set; }
    }
}
