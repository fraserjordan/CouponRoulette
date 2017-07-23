using System.Collections.Generic;
using AutoMapper;
using Business.Models;
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
            var activeCoupons = _couponService.GetActiveCouponsById(userId);
            var savedCoupons = _couponService.GetSavedCouponsById(userId);

            var model = new IndexViewModel
            {
                AvailableCoupons = Mapper.Map<List<AvailableCouponViewModel>>(activeCoupons),
                SavedCoupons = Mapper.Map<List<SavedCouponViewModel>>(savedCoupons)
            };

            return model;
        }
    }
}