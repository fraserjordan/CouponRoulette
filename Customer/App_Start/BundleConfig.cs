using System.Web.Optimization;

namespace Customer
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/angularmaterial").Include(
                    "~/Scripts/jquery-2.2.0.js",
                    "~/Scripts/bootstrap-3.3.6.js",
                    "~/Scripts/angular-1.4.8.js",
                    "~/Scripts/angular-animate-1.4.8.js",
                    "~/Scripts/angular-aria-1.4.8.js",
                    "~/Scripts/angular-route-1.4.8.js",
                    "~/Scripts/angular-messages-1.4.8.js",
                    "~/Scripts/angular-material-1.0.7.min.js",
                    "~/Scripts/svg-assets-cache.js",
                    "~/Scripts/app/modules/_module.js",
                    "~/Scripts/app/modules/angular-filter.js",
                    "~/Scripts/app/app.js",
                    "~/Scripts/app/services/alertService.js",
                    "~/Scripts/app/services/common.js",
                    "~/Scripts/app/directives/ng-match.js",
                    "~/Scripts/app/controllers/registerController.js",
                    "~/Scripts/app/controllers/navbarController.js",
                    "~/Scripts/app/controllers/homeController.js",
                    "~/Scripts/app/controllers/accountController.js",
                     "~/Scripts/app/controllers/loginController.js",
                     "~/Scripts/app/controllers/searchController.js",
                     "~/Scripts/app/factories/state.js",
                     "~/Scripts/app/GlobalFunctions.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/angular-material-1.0.7.css",
                      "~/Content/site.css",
                      "~/Content/fonts.css",
                      "~/Content/LoadingBar.css"));
        }
    }
}
