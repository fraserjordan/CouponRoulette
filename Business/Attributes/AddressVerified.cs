using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Data.Enums;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Business.Attributes
{
    public class AddressVerified : FilterAttribute, IAuthorizationFilter
    {
        protected virtual bool AuthorizeCore(HttpContextBase httpContext)
        {

            if (httpContext == null)
                throw new ArgumentNullException("httpContext");
            IPrincipal principalUser = httpContext.User;
            if (principalUser != null)
            {
                var _userManager = httpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var user = _userManager.FindByEmail(principalUser.Identity.Name);

                return user.BusinessInfo.AddressVerificationStatus == AddressVerificationStatus.Verified;
            }
            return false;
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!AuthorizeCore(filterContext.HttpContext))
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "action", "NotAddressVerified" },
                        { "controller", "Home" }
                    });
            }
        }
    }
}