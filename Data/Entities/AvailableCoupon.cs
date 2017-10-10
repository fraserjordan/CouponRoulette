using Data.Enums;

namespace Data.Entities
{
    public class AvailableCoupon
    {
        public int Id { get; set; }
        public int AmountLeft { get; set; }
        public string CouponText { get; set; }
        public AvailableCouponStatus Status { get; set; }
        public SavedCoupon SavedCoupon { get; set; }
        public ApplicationUser Customer { get; set; }
    }
}
