using System;
using Data.Enums;

namespace Data.Entities
{
    public class SavedCoupon
    {
        public int Id { get; set; }
        public string CouponTitle { get; set; }
        public string CouponText { get; set; }
        public bool Deleted { get; set; }
        public DateTime DateCreated { get; set; }
        public CouponType CouponType { get; set; }
        public ApplicationUser Business { get; set; }
    }
}
