using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Business.Attributes;
using Business.Models;
using Microsoft.AspNet.Identity.Owin;
using Services.Interfaces;
using Services.Models;
using Services.Services;

namespace Business.Controllers
{
    [Authorize]
    [AddressVerified]
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;
        private readonly IUserService _userService;

        public CouponController()
        {
            _couponService = new CouponService();
            _userService = new UserService();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Create(CreateCouponModel model)
        {
            var user = _userService.GetUserByEmail(User.Identity.Name);

            var response = _couponService.CreateCoupons(model, user.Id);

            return new JsonResult
            {
                ContentType = "application/json",
                Data = response
            };
        }

        [HttpPost]
        public JsonResult ActivateCoupons(int couponId, int amount)
        {
            var user = _userService.GetUserByEmail(User.Identity.Name);
            var response = _couponService.ActivateCoupons(couponId, amount, user.Id);

            return new JsonResult
            {
                ContentType = "application/json",
                Data = response
            };
        }

        [HttpPost]
        public JsonResult DeactivateCoupons(int couponId, int amount)
        {
            var user = _userService.GetUserByEmail(User.Identity.Name);
            var response = _couponService.DeactivateCoupons(couponId, amount, user.Id);

            return new JsonResult
            {
                ContentType = "application/json",
                Data = response
            };
        }

        [HttpPost]
        public JsonResult DeleteCoupons(int couponId)
        {
            var user = _userService.GetUserByEmail(User.Identity.Name);
            var response = _couponService.DeleteCoupon(couponId, user.Id);

            return new JsonResult
            {
                ContentType = "application/json",
                Data = response
            };
        }
    }
}