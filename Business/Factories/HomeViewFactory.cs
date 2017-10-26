using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Business.Models;
using Data.Enums;
using Services.Interfaces;
using Services.Services;

namespace Business.Factories
{
    public class HomeViewFactory
    {
        private readonly ICouponService _couponService;

        public HomeViewFactory()
        {
            _couponService = new CouponService();
        }

        public IndexViewModel CreateIndexViewModel(string userId)
        {
            var availableCoupons = _couponService.GetAvailableCouponsById(userId);
            var savedCoupons = _couponService.GetSavedCouponsById(userId);

            var model = new IndexViewModel
            {
                SavedCoupons = Mapper.Map<List<SavedCouponViewModel>>(savedCoupons)
            };

            foreach (var savedCoupon in model.SavedCoupons)
            {
                savedCoupon.AmountAvailable = availableCoupons.Count(x =>
                    x.CouponText == savedCoupon.CouponText && x.Status == AvailableCouponStatus.Available);
                savedCoupon.AmountRedeemed = availableCoupons.Count(x =>
                    x.CouponText == savedCoupon.CouponText && x.Status == AvailableCouponStatus.Assigned);
            }

            return model;
        }
    }
}