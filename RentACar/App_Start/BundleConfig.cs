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
                                                           "~/Content/css/datepicker.css"));

           bundles.Add(new ScriptBundle("~/Content/js").Include
                             ("~/Content/js/jquery.min.js",
                             "~/Content/js/bootstrap.bundle.min.js", 
                             "~/Content/js/jquery.easing.min.js",
                             //"~/Content/js/Chart.min.js",
                             "~/Content/js/jquery.dataTables.js",
                             "~/Content/js/sb-admin.js", 
                             "~/Content/js/sb-admin-datatables.min.js",
                             //"~/Content/js/sb-admin-charts.min.js",
                             "~/Content/js/dataTables.bootstrap4.js",
                             "~/Content/js/datepicker.js",
                              "~/Content/js/custom.js"));
            bundles.Add(new ScriptBundle("~/Conten/Jqueryui").Include("~/Scripts/jquery.unobtrusive-ajax.min.js"));
           
        }


    }
}