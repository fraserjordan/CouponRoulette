using Data.Interfaces;
using Data.Repository;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using Data.Entities;
using Services.Models;

namespace Services.Services 
{
    public class CouponService : ICouponService
    {
        private readonly ICouponRepository _couponRepository;
        public CouponService()
        {
            _couponRepository = new CouponRepository();
        }
        public ServiceResponse CreateCoupons(string couponText, string userId)
        {
            var response = new ServiceResponse();
            try
            {
                _couponRepository.CreateCoupon(couponText, userId);
                response.Success = true;
            }
            catch (Exception e) {
                // log error message
                response.Success = false;
            }
            response.Messages.Add(response.Success ? ReturnMessages.CreateCouponSuccess : ReturnMessages.CreateCouponError);
            return response;
        }

        public ServiceResponse ActivateCoupons(int couponId, int amount, string userId)
        {
            var response = new ServiceResponse();
            try
            {
                _couponRepository.ActivateCoupons(couponId, amount, userId);
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Success = false;
            }
            response.Messages.Add(response.Success ? ReturnMessages.ActivateCouponSuccess : ReturnMessages.ActivateCouponError);
            return response;
        }

        public ServiceResponse DeactivateCoupons(int couponId, int amount, string userId)
        {
            var response = new ServiceResponse();
            try
            {
                _couponRepository.DeactivateCoupons(couponId, amount, userId);
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Success = false;
            }
            response.Messages.Add(response.Success ? ReturnMessages.DeactivateCouponSuccess : ReturnMessages.DeactivateCouponError);
            return response;
        }

        public ServiceResponse DeleteCoupon(int couponId, string userId)
        {
            var response = new ServiceResponse();
            try
            {
                _couponRepository.DeleteCoupons(couponId, userId);
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Success = false;
            }
            response.Messages.Add(response.Success ? ReturnMessages.DeleteCouponSuccess : ReturnMessages.DeleteCouponError);
            return response;
        }

        public List<AvailableCoupon> GetActiveCouponsById(string userId)
        {
            try
            {
                return _couponRepository.GetAvailableCouponsById(userId);
            }
            catch(Exception e)
            {
                // log can't find active coupon error
                return null;
            }
        }

        public List<SavedCoupon> GetSavedCouponsById(string userId)
        {
            try
            {
                return _couponRepository.GetSavedCouponsById(userId);
            }
            catch (Exception e)
            {
                // log can't find active coupon error
                return null;
            }
        }
    }
}
