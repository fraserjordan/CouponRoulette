using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Customer.enums;
using Customer.Entities;
using Customer.Mappers;
using Customer.Models;

namespace Customer.Repository
{
    public class CouponRepository
    {
        private ApplicationDbContext _context;
        private Mapper _mapper;

        public CouponRepository() {
            _context = new ApplicationDbContext();
            _mapper = new Mapper();
        }

        public List<CouponEntity> GetCouponByBusinessId(string businessId) {

            var coupon = _context.Coupons.Where(x => x.Business.Id == businessId).ToList();

            if (coupon == null)
            {
                return new List<CouponEntity>();
            }
            else
            {
                return coupon;
            }
        }

        public ApplicationUser GetUserByEmail(string email) {
            var user  = _context.Users.FirstOrDefault(x => x.Email == email);
            return user;
        }
        public List<CouponEntity> GetAllCoupons() {
            return _context.Coupons.Where(x=> x.Status == CouponStatus.Active).ToList();
        }
        public List<CouponEntity> GetAllRedeemedCoupons()
        {
            return _context.Coupons.Where(x => x.Status == CouponStatus.Redeemed).ToList();
        }
        public void CreateCoupon(SavedCoupon coupon, ApplicationUser user) {

            user.SavedCoupons.Add(coupon);

            _context.SaveChanges();
        }

        public void AddCoupon(CouponEntity coupon, ApplicationUser user) {

            user.Coupons.Add(coupon);

            coupon.Business = user;

            _context.SaveChanges();
        }

        public void deleteCoupon(string couponTitle, ApplicationUser user) {

            var coupon = user.Coupons.FirstOrDefault(x => x.Title == couponTitle);
            if (coupon != null)
            {
                user.Coupons.Remove(coupon);
                _context.Coupons.Remove(coupon);
            }

            _context.SaveChanges();
        }

        public List<ApplicationUser> GetAllBusinesses() {
            return _context.Users.Where(x => x.AccountType == "Business").ToList();
        }
        public void redeemCoupon(ApplicationUser user, CouponEntity coupon) {

            coupon.RedeemCode = RandomString(6);

            coupon.Status = CouponStatus.Redeemed;

            coupon.Customer = user;

            user.Coupons.Add(coupon);

            _context.SaveChanges();
        }
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789@#%&!";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public List<CouponEntity> GetActiveCouponsCustomer(string userId) {
            var activeCoupons = _context.Coupons.Where(x => x.Customer.Id == userId).ToList();

            if (activeCoupons == null) {
                return new List<CouponEntity>();
            }

            return activeCoupons;
        }
        public List<CouponEntity> GetRedeemedCouponsBusiness(string userId)
        {
            var redeemedeCoupons = _context.Coupons.Where(x => x.Business.Id == userId && x.Status == CouponStatus.Redeemed).ToList();

            if (redeemedeCoupons == null)
            {
                return new List<CouponEntity>();
            }

            return redeemedeCoupons;
        }

        public CouponEntity GetRedeemedCouponById(int couponId)
        {
            return _context.Coupons.FirstOrDefault(x => x.Id == couponId && x.Status == CouponStatus.Redeemed);
        }

        public CouponEntity GetCouponById(int couponId) {
            return _context.Coupons.FirstOrDefault(x => x.Id == couponId);
        }

        public List<CouponEntity> GetCoupons(string email)
        {
            var coupons = _context.Coupons.Where(x => x.Business.Email == email).ToList();
            return coupons;
        }

        internal void DeleteSavedCoupon(int id, ApplicationUser user)
        {
            var coupon = user.SavedCoupons.FirstOrDefault(x => x.Id == id);

            if (coupon != null)
            {
                user.SavedCoupons.Remove(coupon);
            }

            _context.SaveChanges();
        }

        public string RedeemCoupon(string code)
        {
            var activeCoupon = _context.Coupons.FirstOrDefault(x => x.RedeemCode == code);

            if (activeCoupon != null)
            {
                var historyCoupon = _mapper.CouponHistoryEntity(activeCoupon);

                _context.Coupons.Remove(activeCoupon);
                _context.CouponHistory.Add(historyCoupon);

                var SavedCoupon = activeCoupon.SavedCoupon;
                SavedCoupon.RedeemedCount = +1;

                _context.SaveChanges();

                return "Successfully redeemed coupon";
            }
            else
            {
                return "We couldn't find this coupon, make sure the code is correctley entered";
            }
        }

        public void EditCoupon(SavedCoupon coupon)
        {
            _context.SavedCoupons.AddOrUpdate(coupon);

            _context.SaveChanges();
        }

        public SavedCoupon GetSavedCouponById(int id)
        {
            return _context.SavedCoupons.FirstOrDefault(x => x.Id == id);
        }

        public void EditSavedCoupon(ApplicationUser user, int id, string title, DateTime fromDate, DateTime toDate, int category, string password)
        {
            var coupon = user.SavedCoupons.FirstOrDefault(x => x.Id == id);

            coupon.Title = title;
            coupon.Category = (CouponCategory) category;
            coupon.ValidFrom = fromDate;
            coupon.ValidTo = toDate;

            _context.SaveChanges();
        }

        public void DeleteAllActiveCoupon(int id, ApplicationUser user)
        {
            var activeCoupons = user.Coupons.Where(x => x.SavedCoupon.Id == id).ToList();

            foreach (var coupon in activeCoupons)
            {
                user.Coupons.Remove(coupon);
            }

            _context.SaveChanges();
        }

        public void DeleteSingleActiveCoupon(int id, ApplicationUser user)
        {
            var activeCoupon = user.Coupons.FirstOrDefault(x => x.SavedCoupon.Id == id);

            user.Coupons.Remove(activeCoupon);

            _context.SaveChanges();
        }
    }
}