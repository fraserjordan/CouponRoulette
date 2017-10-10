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
        void CreateCoupon(string couponText, string userId);
        void ActivateCoupons(int couponId, int amount, string userId);
        void DeactivateCoupons(int couponId, int amount, string userId);
        void DeleteCoupons(int couponId, string userId);
        List<AvailableCoupon> GetAvailableCouponsById(string userId);
        List<SavedCoupon> GetSavedCouponsById(string userId);
    }
}
