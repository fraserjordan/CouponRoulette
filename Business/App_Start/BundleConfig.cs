using System.Web.Optimization;

namespace Business
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new Bundle("~/bundles/angularmaterial").Include(
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
                    "~/Scripts/app/directives/file-picker.js",
                    "~/Scripts/app/directives/ng-file-upload/FileAPI.min.js",
                    "~/Scripts/app/directives/ng-file-upload/ng-file-upload-all.min.js",
                    "~/Scripts/app/directives/ng-file-upload/ng-file-upload-shim.min.js",
                    "~/Scripts/app/directives/ng-file-upload/ng-file-upload.min.js",
                    "~/Scripts/app/controllers/registerController.js",
                    "~/Scripts/app/controllers/navbarController.js",
                    "~/Scripts/app/controllers/businessHomeController.js",
                    "~/Scripts/app/controllers/customerHomeController.js",
                    "~/Scripts/app/controllers/addressVerificationController.js",
                    "~/Scripts/app/controllers/contactController.js",
                    "~/Scripts/app/controllers/accountController.js",
                     "~/Scripts/app/controllers/loginController.js",
                     "~/Scripts/app/controllers/forgotPasswordController.js",
                     "~/Scripts/app/controllers/resetPasswordController.js",
                     "~/Scripts/app/controllers/searchController.js",
                    "~/Scripts/app/controllers/createCouponController.js",
                    "~/Scripts/app/controllers/manageAccountController.js",
                    "~/Scripts/app/controllers/searchController.js",
                     "~/Scripts/app/factories/state.js",
                     "~/Scripts/app/GlobalFunctions.js",
                     "~/Scripts/ladda/spin.js",
                     "~/Scripts/ladda/ladda.js",
                     "~/Scripts/ladda/angular-ladda.js"
                ));

            bundles.Add(new Bundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new Bundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new Bundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new Bundle("~/Content/css").Include(
                      "~/Content/site.css",
                      "~/Content/fonts.css",
                      "~/Content/LoadingBar.css",
                      "~/Content/angular-material-1.0.7.css"));
        }
    }
}
