﻿using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Customer.Models;
using Data.Entities;
using Data.Enums;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Services;
using Services.Interfaces;
using Services.Services;

namespace Customer.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private readonly ICustomerInfoService _customerInfoService;
        private readonly IEmailService _emailService;
        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        public AccountController()
        {
            _customerInfoService = new CustomerInfoService();
            _emailService = new Services.Services.EmailService();
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
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

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            var user = UserManager.FindByEmail(model.Email);

            if (user != null)
            {
                if (UserManager.IsEmailConfirmedAsync(user.Id).Result)
                {
                        var result = SignInManager.PasswordSignIn(model.Email, model.Password, model.RememberMe, shouldLockout: true);

                        switch (result)
                        {
                            case SignInStatus.Success:
                                return RedirectToAction("Index", "Home");
                            case SignInStatus.Failure:
                                ModelState.AddModelError("", "Incorrect email or password.");
                                return View();
                            case SignInStatus.LockedOut:
                                ModelState.AddModelError("",
                                    "Too many login attempts, you have been temporarily locked out.");
                                return View();
                            case SignInStatus.RequiresVerification:
                                ModelState.AddModelError("", "Login with this account requires firther verification.");
                                return View();
                            default:
                                return View();

                        }
                }
                return View("RequireEmailVerification");
            }
            ModelState.AddModelError("", "Incorrect email or password.");
            return View();
        }

        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login", "Account");
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            IdentityResult result = new IdentityResult();

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, AccountType = AccountType.Customer};
                result = UserManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    _customerInfoService.CreateCustomerInfo(user.Id);
                    string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new {userId = user.Id, code = code},
                        protocol: Request.Url.Scheme);
                    _emailService.SendRequireEmailValidation(model.Email,
                        ConfigurationManager.AppSettings["ContactEmailAddress"], "", callbackUrl);
                    return View("RequireEmailVerification");
                }
            }
            ModelState.AddModelError("", "This email address has already been registered to another user.");
            return View();
        }

        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            var user = UserManager.FindById(userId);

            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);

            if (result.Succeeded)
            {
                return View();
            }
            return View("Error");
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                _emailService.SendForgotPasswordLink(user.Email, ConfigurationManager.AppSettings["ContactEmailAddress"], user.BusinessInfo.BusinessName, callbackUrl);
                return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            if (code != null)
            {
                var model = new ResetPasswordViewModel();
                model.Code = code;

                return View(model);
            }
            return View("Error");
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }

            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        public ActionResult _LoginPartial()
        {
            return View();
        }
    }
}