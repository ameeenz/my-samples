using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Driving.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Ct/Jquery").Include("~/Content/Landing/js/jquery-3.3.1.min.js"));
            bundles.Add(new ScriptBundle("~/jquery-ui").Include("~/Content/Admin/plugins/jquery-ui/jquery-ui.min.js"));
            bundles.Add(new ScriptBundle("~/Ct/Bootstrap").Include("~/Content/Landing/js/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/Ct/validation").Include("~/Content/Landing/js/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/Ct/Landing/js").Include("~/Content/Landing/js/jquery.nice-select.min.js",
                "~/Content/Landing/js/jquery.magnific-popup.min.js", "~/Content/Landing/js/jquery-ui.min.js",
                "~/Content/Landing/js/jquery.slicknav.js", "~/Content/Landing/js/owl.carousel.min.js",
                "~/Content/Landing/js/main.js"));

            bundles.Add(new StyleBundle("~/Ct/Css").Include("~/Content/Landing/css/bootstrap.min.css",
                "~/Content/Landing/css/font-awesome.min.css", "~/Content/Landing/css/nice-select.css",
                "~/Content/Landing/css/magnific-popup.css", "~/Content/Landing/css/jquery-ui.min.css",
                "~/Content/Landing/css/owl.carousel.min.css", "~/Content/Landing/css/slicknav.min.css",
                "~/Content/Landing/css/style.css"));

            bundles.Add(new StyleBundle("~/Ct/Admin/Css").Include("~/Content/Admin/plugins/fontawesome-free/css/all.min.css",
                "~/Content/Admin/dist/ionicons.min",
                "~/Content/Admin/plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css", 
                "~/Content/Admin/plugins/icheck-bootstrap/icheck-bootstrap.min.css",
                "~/Content/Admin/plugins/jqvmap/jqvmap.min.css", 
                "~/Content/Admin/dist/css/adminlte.min.css",
                "~/Content/Admin/plugins/overlayScrollbars/css/OverlayScrollbars.min.css", 
                "~/Content/Admin/plugins/daterangepicker/daterangepicker.css",
                "~/Content/Admin/plugins/summernote/summernote-bs4.css",
                "~/Content/Admin/dist/googleFonts.css"));
            
            bundles.Add(new ScriptBundle("~/Ct/Admin/js").Include("~/Content/Admin/plugins/chart.js/Chart.min.js",
                "~/Content/Admin/plugins/sparklines/sparkline.js",
                "~/Content/Admin/plugins/jqvmap/jquery.vmap.min.js",
                "~/Content/Admin/plugins/jqvmap/maps/jquery.vmap.usa.js",
                "~/Content/Admin/plugins/jquery-knob/jquery.knob.min.js",
                "~/Content/Admin/plugins/moment/moment.min.js",
                "~/Content/Admin/plugins/daterangepicker/daterangepicker.js",
                "~/Content/Admin/plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js",
                "~/Content/Admin/plugins/summernote/summernote-bs4.min.js",
                "~/Content/Admin/plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js",
                "~/Content/Admin/dist/js/pages/dashboard.js",
                "~/Content/Admin/dist/js/adminlte.js",
                "~/Content/Admin/dist/js/demo.js"
                ));

            bundles.Add(new ScriptBundle("~/bootstrap").Include("~/Content/Admin/plugins/bootstrap/js/bootstrap.bundle.min.js"));
            bundles.Add(new ScriptBundle("~/JQuery").Include("~/Content/Admin/plugins/jquery/jquery.min.js"));
            
        }
    }
}