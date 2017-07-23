using System.Collections.Generic;

namespace Customer.Models
{
    public class BusinessViewModel
    {
        public string Id { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string BusinessName { get; set; }
        public string BusinessAddress { get; set; }
        public string BusinessPhone { get; set; }
        public string BusinessWebsite { get; set; }
        public List<CouponModel> Coupons { get; set; }
    }
}