using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Data.Enums;

namespace Data.Interfaces
{
    public interface ICouponRepository
    {
        void CreateCoupon(string couponTitle, string couponText, CouponType couponType, string userId);
        void ActivateCoupons(int couponId, int amount, string userId);
        void DeactivateCoupons(int couponId, int amount, string userId);
        void DeleteCoupons(int couponId, string userId);
        List<AvailableCoupon> GetAvailableCouponsById(string userId);
        List<SavedCoupon> GetSavedCouponsById(string userId);
    }
}
