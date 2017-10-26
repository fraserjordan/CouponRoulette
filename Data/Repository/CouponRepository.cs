using System;
using Data.Entities;
using Data.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Data.Enums;
using System.Configuration;

namespace Data.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly DataContext _dataContext;
        private static readonly int maxAvailableCouponLimit = int.Parse(ConfigurationManager.AppSettings["MaxAvaliableCouponLimit"]);
        public CouponRepository()
        {
            _dataContext = new DataContext();
        }
        public void CreateCoupon(string couponTitle, string couponText, CouponType couponType, string userId)
        {
            var user = _dataContext.Users.FirstOrDefault(x => x.Id == userId);
            if (user != null)
            {
                var coupon = new SavedCoupon
                {
                    CouponTitle = couponTitle,
                    CouponText = couponText,
                    CouponType = couponType,
                    Business = user,
                    DateCreated = DateTime.UtcNow,
                    Deleted = false
                };
                _dataContext.SavedCoupons.Add(coupon);
                _dataContext.SaveChanges();
            }
        }

        public void ActivateCoupons(int couponId, int amount, string userId)
        {
            var user = _dataContext.Users.FirstOrDefault(x => x.Id == userId);

            var savedCoupon = _dataContext.SavedCoupons.Include(x => x.Business).FirstOrDefault(x => x.Business.Id == userId && x.Id == couponId);

            if (savedCoupon != null)
            {
                var existingActiveCoupons = _dataContext.AvailableCoupons.Include(x => x.SavedCoupon).Where(x => x.SavedCoupon.Id == couponId && user.Id == userId).ToList();
                if (existingActiveCoupons.Count < maxAvailableCouponLimit)
                {
                    for (int i = 0; i < amount && i + existingActiveCoupons.Count < maxAvailableCouponLimit; i++)
                    {
                        var availableCoupon = new AvailableCoupon
                        {
                            CouponText = savedCoupon.CouponText,
                            SavedCoupon = savedCoupon,
                            Status = AvailableCouponStatus.Available
                        };

                        _dataContext.AvailableCoupons.Add(availableCoupon);
                    }
                }
                _dataContext.SaveChanges();
            }
        }

        public void DeactivateCoupons(int couponId, int amount, string userId)
        {
            var couponsForDeactivation = _dataContext.AvailableCoupons.Include(x => x.SavedCoupon).Where(x => x.SavedCoupon.Id == couponId && x.Status == AvailableCouponStatus.Available).ToList();
            _dataContext.AvailableCoupons.RemoveRange(couponsForDeactivation);
            _dataContext.SaveChanges();

        }

        public void DeleteCoupons(int couponId, string userId)
        {
            var savedCoupon = _dataContext.SavedCoupons.Include(x => x.Business).FirstOrDefault(x => x.Business.Id == userId && x.Id == couponId);
            var availableCoupons = _dataContext.AvailableCoupons.Include(x => x.SavedCoupon).Where(x => x.SavedCoupon.Id == couponId && x.Status == AvailableCouponStatus.Available).ToList();

            if (availableCoupons.Count > 0)
            {
                foreach (var coupon in availableCoupons)
                {
                    _dataContext.AvailableCoupons.Remove(coupon);
                }
            }
            if (savedCoupon != null)
            {
                savedCoupon.Deleted = true;
            }
            _dataContext.SaveChanges();
        }

        public List<AvailableCoupon> GetAvailableCouponsById(string userId)
        {
            var user = _dataContext.Users.FirstOrDefault(x => x.Id == userId);
            if (user != null)
            {
                return _dataContext.AvailableCoupons.Include(x => x.SavedCoupon).Where(x => x.SavedCoupon.Business.Id == userId).ToList();
            }
            return new List<AvailableCoupon>();
        }

        public List<SavedCoupon> GetSavedCouponsById(string userId)
        {
            var user = _dataContext.Users.FirstOrDefault(x => x.Id == userId);
            if (user != null)
            {
                return _dataContext.SavedCoupons.Include(x => x.Business).Where(x => x.Business.Id == userId && x.Deleted == false).ToList();
            }
            return new List<SavedCoupon>();
        }
    }
}
