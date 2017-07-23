﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Models
{
    public class AvailableCouponViewModel
    {
        public int Id { get; set; }
        public int SavedCouponId { get; set; }
        public string CouponText { get; set; }
        public int AmountLeft { get; set; }
        public int TotalRedeemed { get; set; }
    }
}