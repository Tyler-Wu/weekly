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
             "~/Content/css/bootstrap-responsive.css",
              "~/Content/css/jquery-ui-1.8.21.custom.css",
             "~/Content/css/.css",
             "~/Content/css/charisma-app.css",
             "~/Content/css/fullcalendar.css",
             "~/Content/css/fullcalendar.print.css",
             "~/Content/css/chosen.css",
             "~/Content/css/uniform.default.css",
             "~/Content/css/colorbox.css",
             "~/Content/css/jquery.cleditor.css",
             "~/Content/css/jquery.noty.css",
             "~/Content/css/noty_theme_default.css",
             "~/Content/css/elfinder.min.css",
             "~/Content/css/elfinder.theme.css",
             "~/Content/css/jquery.iphone.toggle.css",
             "~/Content/css/opa-icons.css",
             "~/Content/css/uploadify.css"));

            bundles.Add(new StyleBundle("~/Content/charismajs").Include(
                "~/Scripts/charismajs/jquery-1.7.2.min.js",
                  "~/Scripts/charismajs/jquery-ui-1.8.21.custom.min.js",
                  "~/Scripts/charismajs/bootstrap-transition.js",
                  "~/Scripts/charismajs/bootstrap-alert.js",
                  "~/Scripts/charismajs/bootstrap-modal.js",
                  "~/Scripts/charismajs/bootstrap-dropdown.js",
                  "~/Scripts/charismajs/bootstrap-scrollspy.js",
                  "~/Scripts/charismajs/bootstrap-tab.js",
                  "~/Scripts/charismajs/bootstrap-tooltip.js",
                  "~/Scripts/charismajs/bootstrap-popover.js",
                  "~/Scripts/charismajs//bootstrap-button.js",
                  "~/Scripts/charismajs/bootstrap-collapse.js",
                  "~/Scripts/charismajs/bootstrap-carousel.js",
                  "~/Scripts/charismajs/bootstrap-typeahead.js",
                  "~/Scripts/charismajs/bootstrap-tour.js",
                  "~/Scripts/charismajs/jquery.cookie.js",
                  "~/Scripts/charismajs/fullcalendar.min.js",
                  "~/Scripts/charismajs/jquery.dataTables.min.js",
                  "~/Scripts/charismajs/js/excanvas.js",
                  "~/Scripts/charismajs/jquery.flot.min.js",
                  "~/Scripts/charismajs/jquery.flot.pie.min.js",
                  "~/Scripts/charismajs/jquery.flot.stack.js",
                  "~/Scripts/charismajs/jquery.flot.resize.min.js",
                  "~/Scripts/charismajs/query.chosen.min.js",
                  "~/Scripts/charismajs/jquery.uniform.min.js",
                  "~/Scripts/charismajs/jquery.colorbox.min.js",
                  "~/Scripts/charismajs/jquery.cleditor.min.js",
                  "~/Scripts/charismajs/jquery.noty.js",
                  "~/Scripts/charismajs/jquery.elfinder.min.js",
                  "~/Scripts/charismajs/jquery.raty.min.js",
                  "~/Scripts/charismajs/jquery.iphone.toggle.js",
                  "~/Scripts/charismajs/jquery.autogrow-textarea.js",
                  "~/Scripts/charismajs/jquery.uploadify-3.1.min.js",
                  "~/Scripts/charismajs/jquery.uploadify-3.1.min.js",
                  "~/Scripts/charismajs/js/charisma.js"
                ));
        }
    }
}
