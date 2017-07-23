using Data.Entities;
using Data.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly DataContext _dataContext;
        public CouponRepository() {
            _dataContext = new DataContext();
        }
        public bool CreateCoupon(string couponText, string userId)
        {
            var user = _dataContext.Users.FirstOrDefault(x => x.Id == userId);
            if (user != null)
            {
                var coupon = new SavedCoupon {
                    AmountRedeemed = 0,
                    CouponText = couponText
                };
                user.BusinessInfo.SavedCoupons.Add(coupon);
                return _dataContext.SaveChanges() > 0;
            }
            return false;
        }

        public bool ActivateCoupons(int couponId, int amount, string userId)
        {
            var user = _dataContext.Users.FirstOrDefault(x => x.Id == userId);

            var savedCoupon = user?.BusinessInfo.SavedCoupons.FirstOrDefault(x => x.Id == couponId);

            if (savedCoupon != null)
            {
                var existingActiveCoupon = _dataContext.AvailableCoupons.FirstOrDefault(x => x.SavedCouponId == couponId && user.Id == userId);
                if (existingActiveCoupon != null)
                {
                    existingActiveCoupon.AmountLeft += amount;
                    return _dataContext.SaveChanges() != 0;
                }

                var activeCoupon = new AvailableCoupon
                {
                    AmountLeft = amount,
                    CouponText = savedCoupon.CouponText,
                    SavedCouponId = savedCoupon.Id
                };
                user.BusinessInfo.AvailableCoupons.Add(activeCoupon);
                return _dataContext.SaveChanges() > 0;
            }
            return false;
        }

        public bool DeactivateCoupons(int couponId, int amount, string userId)
        {
            var user = _dataContext.Users.FirstOrDefault(x => x.Id == userId);
            var availableCoupon = user?.BusinessInfo.AvailableCoupons.FirstOrDefault(x => x.Id == couponId);
            if (availableCoupon != null)
            {
                if (availableCoupon.AmountLeft <= amount)
                {
                    _dataContext.AvailableCoupons.Remove(availableCoupon);
                    return _dataContext.SaveChanges() != 0;
                }
                availableCoupon.AmountLeft -= amount;
                return _dataContext.SaveChanges() > 0;
            }
            return false;
        }

        public bool DeleteCoupons(int couponId, string userId)
        {
            var user = _dataContext.Users.FirstOrDefault(x => x.Id == userId);
            var savedCoupon = user?.BusinessInfo.SavedCoupons.FirstOrDefault(x => x.Id == couponId);
            var availableCoupons = user?.BusinessInfo.AvailableCoupons.Where(x => x.SavedCouponId == couponId).ToList();

            if (availableCoupons != null && availableCoupons.Count > 0)
            {
                foreach (var activeCoupon in availableCoupons) {
                    _dataContext.AvailableCoupons.Remove(activeCoupon);
                }
            }
            if (savedCoupon != null)
            {
                _dataContext.SavedCoupons.Remove(savedCoupon);
            }
            else
            {
                return false;
            }
            return _dataContext.SaveChanges() > 0;
        }

        public List<AvailableCoupon> GetAvailableCouponsById(string userId)
        {
            var user = _dataContext.Users.FirstOrDefault(x => x.Id == userId);
            var availableCoupons = user?.BusinessInfo.AvailableCoupons.ToList();
            return availableCoupons?.Count > 0 ? availableCoupons : new List<AvailableCoupon>();
        }

        public List<SavedCoupon> GetSavedCouponsById(string userId)
        {
            var user = _dataContext.Users.FirstOrDefault(x => x.Id == userId);
            var coupons = user.BusinessInfo.SavedCoupons.ToList();
            return coupons.Count > 0 ? coupons : new List<SavedCoupon>();
        }
    }
}
