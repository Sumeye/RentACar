using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace AracKiralamaProje.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = false;
  
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/css/bootstrap.min.css",
                                                           "~/Content/css/dataTables.bootstrap4.css",
                                                           "~/Content/vendor/font-awesome/css/font-awesome.min.css",
                                                           "~/Content/css/sb-admin.css",
                                                           "~/Content/css/bootstrap-datetimepicker.css",
                                                           "~/Content/css/daterangepicker.css"));

           bundles.Add(new ScriptBundle("~/Content/js").Include
                             ("~/Content/js/jquery.min.js",
                             "~/Content/js/bootstrap.bundle.min.js",
                             "~/Content/js/jquery.easing.min.js",
                             "~/Content/js/Chart.min.js",
                             "~/Content/js/jquery.dataTables.js",
                             "~/Content/js/sb-admin.js", 
                             "~/Content/js/sb-admin-datatables.min.js",
                             "~/Content/js/sb-admin-charts.min.js",
                             "~/Content/js/dataTables.bootstrap4.js",
                             "~/Content/js/bootstrap-datetimepicker.min.js",
                              "~/Content/js/daterangepicker.js",
                                 "~/Content/js/moment.min.js"));
        }

        internal static void RegisterBundles(object bundles)
        {
            throw new NotImplementedException();
        }
    }
}