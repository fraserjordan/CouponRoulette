using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.Interfaces
{
    public interface ICouponRepository
    {
        bool CreateCoupon(string couponText, string userId);
        bool ActivateCoupons(int couponId, int amount, string userId);
        bool DeactivateCoupons(int couponId, int amount, string userId);
        bool DeleteCoupons(int couponId, string userId);
        List<AvailableCoupon> GetAvailableCouponsById(string userId);
        List<SavedCoupon> GetSavedCouponsById(string userId);
    }
}
