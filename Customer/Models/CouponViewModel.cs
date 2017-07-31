namespace Customer.Models
{
    public class CouponViewModel
    {
        public int Id { get; set; }
        public string CouponText { get; set; }
        public BusinessViewModel Business { get; set; }
    }
}