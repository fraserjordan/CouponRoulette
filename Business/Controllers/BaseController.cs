using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Business.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Services;
using Services.Models;

namespace Business.Controllers
{
    public class BaseController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public BaseController()
        {
            
        }
        public BaseController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
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

        public async Task<ServiceResponse> ChangePasswordAsync(ChangePasswordViewModel model)
        {
            var response = new ServiceResponse();

            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            response.Success = result.Succeeded;
            response.Messages.Add(response.Success ? ReturnMessages.ChangePasswordSuccess : ReturnMessages.ChangePasswordError);
            //            if (result.Succeeded)
            //            {
            //                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            //                if (user != null)
            //                {
            //                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            //                }
            //                responseData.Success = true;
            //            }
            //            else
            //            { 
            //                AddErrors(result);
            //                responseData.Success = false;
            //                responseData.Messages.Add("The old password you entered does not match your current password");
            //            }
            return response;
        }
    }
}