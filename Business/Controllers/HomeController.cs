using System.Configuration;
using System.Web.Mvc;
using Business.Factories;
using Services.Interfaces;
using Services.Models;
using Services.Services;

namespace Business.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly IUserService _userService;

        public HomeController()
        {
            _emailService = new EmailService();
            _userService = new UserService();
        }

        public ActionResult Index()
        {
            var homeViewFactory = new HomeViewFactory();

            var user = _userService.GetUserByEmail(User.Identity.Name);

            var model = homeViewFactory.CreateIndexViewModel(user.Id);

            return View(model);
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SendEmail(string emailName, string emailFrom, string emailBody)
        {
            _emailService.SendContactEmail(ConfigurationManager.AppSettings["ContactEmailAddress"], emailFrom, emailName, emailBody);

            return new JsonResult
            {
                ContentType = "application/json",
                Data = new ServiceResponse
                {
                    Success = true
                }
            };
        }
    }
}