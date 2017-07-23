using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using AutoMapper.Configuration;
using Customer.Models;
using Data.Entities;

namespace Customer
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
            config.CreateMap<BusinessInfo, BusinessViewModel>();
            config.CreateMap<BusinessViewModel, BusinessInfo>();

            Mapper.Initialize(config);
        }
    }
}
