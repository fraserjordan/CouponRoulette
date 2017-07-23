using System;
using Customer.enums;

namespace Customer.Models
{
    public class CouponModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public DateTime Redeemed { get; set; }
        public CouponCategory Category { get; set; }
        public CouponStatus Status { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public decimal Value { get; set; }
        public string BusinessId { get; set; }
        public string CustomerId { get; set; }
    }
}