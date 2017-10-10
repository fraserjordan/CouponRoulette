using System;
using Data.Enums;

namespace Data.Entities
{
    public class CustomerInfo
    {
        public int Id { get; set; }
        public int CouponUnRedeemedCount { get; set; }
        public int CouponRedeemedCount { get; set; }
        public int ComplaintCount { get; set; }
    }
}
