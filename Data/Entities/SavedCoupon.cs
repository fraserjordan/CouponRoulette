namespace Data.Entities
{
    public class SavedCoupon
    {
        public int Id { get; set; }
        public string CouponTitle { get; set; }
        public string CouponText { get; set; }
        public int AmountRedeemed { get; set; }
        public bool Deleted { get; set; }
        public ApplicationUser Business { get; set; }
    }
}
