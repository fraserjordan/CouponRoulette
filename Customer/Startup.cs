using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute("CustomerStartupConfig", typeof(Customer.Startup))]
namespace Customer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
