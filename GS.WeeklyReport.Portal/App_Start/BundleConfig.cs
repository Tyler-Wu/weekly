using System.Web;
using System.Web.Optimization;

namespace GS.WeeklyReport.Portal
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //BundleTable.EnableOptimizations = true;


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/jquery-1.7.2.js",
                      "~/Scripts/moment.js",
                      "~/Scripts/fullcalendar.js",
                      "~/Scripts/jquery-ui-1.8.21.custom.min.js",
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/WeeklyReport.js",
                      "~/Scripts/bui.js",
                      "~/Scripts/fancyBox-1.3.1.js"
            ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/BUI/bs3/dpl.css",
                    "~/Content/BUI/bs3/bui.css",
                    "~/Content/fullcalendar.css",
                    "~/Content/fullcalendar.print.css",
                    "~/Content/css/font-awesome.css",
                    "~/Content/css/bootstrap-cerulean.css",
                    "~/Content/fancyBox-1.3.1.css",
                    "~/Content/calendar-dialog.css"
             ));
        }
    }
}
