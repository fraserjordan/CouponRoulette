using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Customer.enums;
using Customer.Models;
using Data.Entities;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Customer.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationUserManager _userManager;
        // GET: Customer

        public CustomerController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }
        public CustomerController()
        {
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public string RedeemCoupon(string couponTitle)
        {
            return null;
        }

        [HttpGet]
        public string GetCouponCode(int couponId)
        {
            return null;
        }

        public ActionResult Search(string Address, string Latitude, string Longitude, string Name, int Category)//, int ValidFrom, int ValidTo)
        {
//            var fromDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, ValidFrom, 0, 0);
//            var toDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, ValidTo, 0, 0);
//
//            const int TOLERANCE = 2;
//            var businesses = new List<ApplicationUser>();
//            var model = new List<ApplicationUser>();
//
//            //model = _repository.GetAllBusinesses();
//
//            if (!Address.IsNullOrWhiteSpace() && !Latitude.IsNullOrWhiteSpace() && !Longitude.IsNullOrWhiteSpace())
//            {
//                var sCoord = new GeoCoordinate(Convert.ToDouble(Latitude), Convert.ToDouble(Longitude));
//
//                model =
//                    model.OrderBy(
//                        x =>
//                            sCoord.GetDistanceTo(new GeoCoordinate()
//                            {
//                                Latitude = Convert.ToDouble(x.L),
//                                Longitude = Convert.ToDouble(x.Longitude)
//                            })).ToList();
//            }
//            if (!Name.IsNullOrWhiteSpace())
//            {
//                string businessName = Name.ToLower();
//                model = model.Where(p =>
//                {
//                    //Check Contains
//                    bool contains = p.BusinessName.ToLower().Contains(businessName);
//                    if (contains) return true;
//
//                    //Check LongestCommonSubsequence
//                    bool subsequenceTolerated = LongestCommonSubsequence(p.BusinessName, businessName) >= businessName.Length - TOLERANCE;
//                    return subsequenceTolerated;
//
//                }).ToList();
//
//            }
//            if (Category != 0)
//            {
//                model = model.Where(x => x.Type == (BusinessFoodCategory) Category).ToList();
//            }

            return PartialView("CouponList");
        }

        private static int Max(int int1, int int2)
        {
            return int1 > int2 ? int1 : int2;
        }

        public static int LongestCommonSubsequence(string str1, string str2)
        {
            int[,] arr = new int[str1.Length + 1, str2.Length + 1];

            for (int i = 0; i <= str2.Length; i++)
            {
                arr[0, i] = 0;
            }
            for (int i = 0; i <= str1.Length; i++)
            {
                arr[i, 0] = 0;
            }

            for (int i = 1; i <= str1.Length; i++)
            {
                for (int j = 1; j <= str2.Length; j++)
                {
                    if (str1[i - 1] == str2[j - 1])
                    {
                        arr[i, j] = arr[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        arr[i, j] = Max(arr[i - 1, j], arr[i, j - 1]);
                    }
                }
            }
            return arr[str1.Length, str2.Length];
        }

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }

            return RedirectToAction("Login", "Account", new {returnUrl = "/Home/Index"});
        }

        public string GetModel() {

            var user = UserManager.FindByName(User.Identity.Name);

            //var model = _customerFactory.CreateIndexModel(user);

            if (User.Identity.IsAuthenticated)
            {
                //return new JavaScriptSerializer().Serialize(model);
            }

            return null;
        }
    }
}