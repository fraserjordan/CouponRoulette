namespace Data.Entities
{
    public class AvailableCoupon
    {
        public int Id { get; set; }
        public int AmountLeft { get; set; }
        public string CouponText { get; set; }
        public int SavedCouponId { get; set; }
    }
}
