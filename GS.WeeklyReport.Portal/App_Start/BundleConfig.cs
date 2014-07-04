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
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
             "~/Content/BUI/bs3/bui.css"

             ));

            bundles.Add(new ScriptBundle("~/Scripts/BUI").Include(
                                      "~/Scripts/jquery-1.8.2.js",
                                      "~/Scripts/bui.js"
                ));
        }
    }
}
