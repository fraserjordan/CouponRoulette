using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Models
{
    public class SavedCouponViewModel
    {
        public int Id { get; set; }
        public string CouponText { get; set; }
        public int AmountRedeemed { get; set; }
    }
}