using System.Web;
using System.Web.Optimization;

namespace NBT.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Assets/bootstrap/dist/css/bootstrap.min.css",
                "~/Assets/jquery.mmenu/jquery.mmenu.css",
                "~/Assets/font-awesome/css/font-awesome.min.css",
                "~/Assets/Swiper-4.0.6/dist/css/swiper.min.css",
                "~/Assets/bootstrap-datetimepicker/css/bootstrap-datetimepicker.min.css",
                "~/Assets/accordion-menu/css/style.css",
                "~/Assets/libs/selects2/select2.min.css",
                "~/Assets/client/css/style.css"
                ));

            bundles.Add(new ScriptBundle("~/Scripts/footers").Include(
                "~/Assets/Swiper-4.0.6/dist/js/swiper.min.js",
                //"~/Assets/jquery/dist/jquery.min.js",
                "~/Assets/jquery.mmenu/jquery.mmenu.js",
                "~/Assets/libs/selects2/select2.min.js",
                "~/Assets/bootstrap/dist/js/bootstrap.min.js",
                "~/Assets/libs/moment/moment.js",
                "~/Assets/libs/moment/moment-timezone.min.js",
                "~/Assets/libs/moment/moment-timezone-with-data.min.js",
                "~/Assets/jquery/jquery.validate.min.js",
                "~/Assets/bootstrap-datetimepicker/js/bootstrap-datetimepicker.min.js",
                "~/Assets/client/js/main.js"));
#if DEBUG
            BundleTable.EnableOptimizations = false;
#else
            BundleTable.EnableOptimizations = true;
#endif
        }
    }
}
