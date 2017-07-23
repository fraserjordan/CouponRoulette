using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Customer.Factories;

namespace Customer.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly HomeViewFactory _factory;

        public HomeController()
        {
            _factory = new HomeViewFactory();
        }

        public ActionResult Index()
        {
            var model = _factory.CreateIndexViewModel();
            return View(model);
        }
    }
}