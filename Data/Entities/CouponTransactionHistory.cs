using System;

namespace Data.Entities
{
    public class CouponTransactionHistory
    {
        public int Id { get; set; }
        public ApplicationUser Business { get; set; }
        public ApplicationUser Customer { get; set; }
        public SavedCoupon Coupon { get; set; }
        public DateTime TransactionDateTime { get; set; }
    }
}
