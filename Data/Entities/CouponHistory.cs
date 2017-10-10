using System;
using Data.Enums;

namespace Data.Entities
{
    public class CouponHistory
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public CouponHistoryReason ReasonCreated { get; set; }
        public SavedCoupon SavedCoupon { get; set; }
        public ApplicationUser Customer { get; set; }
    }
}
