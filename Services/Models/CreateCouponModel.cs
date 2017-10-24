using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Enums;

namespace Services.Models
{
    public class CreateCouponModel
    {
        public string CouponTitle { get; set; }
        public string CouponText { get;set; }
        public CouponType CouponType { get; set; }
    }
}
