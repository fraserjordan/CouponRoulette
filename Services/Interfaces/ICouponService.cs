using System.Collections.Generic;
using Data.Entities;
using Services.Models;

namespace Services.Interfaces
{
    public interface ICouponService
    {
        ServiceResponse CreateCoupons(string couponText, string userId);
        ServiceResponse ActivateCoupons(int couponId, int amount, string userId);
        ServiceResponse DeactivateCoupons(int couponId, int amount, string userId);
        ServiceResponse DeleteCoupon(int couponId, string userId);
        List<AvailableCoupon> GetActiveCouponsById(string userId);
        List<SavedCoupon> GetSavedCouponsById(string userId);
    }
}
