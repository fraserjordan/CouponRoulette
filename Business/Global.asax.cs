using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using AutoMapper.Configuration;
using Business.Models;
using Data.Entities;
using Services.Models;

namespace Business
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            CreateMapperConfig();
        }

        public void CreateMapperConfig()
        {
            var config = new MapperConfigurationExpression();

            //Create all maps
            config.CreateMap<BusinessInfo, BusinessInfoViewModel>();
            config.CreateMap<SavedCoupon, SavedCouponViewModel>();

            Mapper.Initialize(config);
        }
    }
}
