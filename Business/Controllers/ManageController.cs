using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using Business.Attributes;
using Business.Factories;
using Business.Models;
using Services;
using Services.Interfaces;
using Services.Models;
using Services.Services;

namespace Business.Controllers
{
    [Authorize]
    [AddressVerified]
    public class ManageController : BaseController
    {
        private readonly IBusinessService _businessService;
        private readonly IUserService _userService;
        private readonly IAzureStorageService _azureStorageService;

        public ManageController()
        {
            _businessService = new BusinessService();
            _userService = new UserService();
            _azureStorageService = new AzureStorageService();
        }

        public ActionResult Index()
        {
            var manageFactory = new ManageViewFactory();
            var businessInfo = _businessService.GetBusinessInfoByEmail(User.Identity.Name);
            var model = manageFactory.CreateIndexViewModel(businessInfo);
            return View(model);
        }

        [HttpPost]
        public JsonResult UpdateBusinessInfo(BusinessInfoViewModel model)
        {
            var businessInfoServiceModel = Mapper.Map<BusinessInfoServiceModel>(model);
            var result = _businessService.UpdateBusinessInfo(User.Identity.Name, businessInfoServiceModel);
            return new JsonResult()
            {
                ContentType = "application/json",
                Data = result
            };
        }

        [HttpPost]
        public async Task<JsonResult> ChangePassword(ChangePasswordViewModel model)
        {
            var response = await ChangePasswordAsync(model);

            return new JsonResult()
            {
                ContentType = "application/json",
                Data = response
            };
        }

        [HttpPost]
        public ActionResult SaveMenu(string menuUrl)
        {
            var businessInfoId = _businessService.GetBusinessInfoByEmail(User.Identity.Name).Id;
            if (string.IsNullOrEmpty(menuUrl))
            {
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];

                    if (file != null && file.ContentLength > 0)
                    {
                        menuUrl = _azureStorageService.UploadToBlobStorage(file, businessInfoId);
                    }
                }
            }
            _businessService.UpdateMenuUrl(businessInfoId, menuUrl);
            return RedirectToAction("Index");
        }
    }
}