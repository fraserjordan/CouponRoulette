using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Models
{
    public class IndexViewModel
    {
        public string BusinessName { get; set; }
        public List<AvailableCouponViewModel> AvailableCoupons { get; set; }
        public List<SavedCouponViewModel> SavedCoupons { get; internal set; }
    }
}