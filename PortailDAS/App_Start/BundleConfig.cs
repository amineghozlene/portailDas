using System.Web;
using System.Web.Optimization;

namespace PortailDAS
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/fichierjavascript").Include(
                        "~/Ressource/js/library/jquery/jquery-1.10.2.min.js",
                        "~/Ressource/js/library/helper/jquery.easing.min.js",
                        "~/Ressource/js/library/helper/jquery.touchSwipe.min.js",
                        "~/Ressource/js/library/helper/jquery.mousewheel.min.js",
                        "~/Ressource/js/library/helper/imagesloaded.pkgd.min.js",

                        //Options--,
                        "~/Ressource/js/jquery.cookie.js",
                        "~/Ressource/js/theme-options.js",

                        //Retina js--,
                        "~/Ressource/js/library/retina/retina.js",

                        //FancyBox--,
                        "~/Ressource/js/library/fancybox/jquery.fancybox.pack8cbb.js",

                        //Bootstrap js--,
                        "~/Ressource/js/library/bootstrap/bootstrap.min.js",

                        //Validate--,
                        "~/Ressource/js/library/validate/jquery.validate.min.js",

                        //FlickrFeed--,
                        "~/Ressource/js/library/jFlickrFeed/jflickrfeed.min.js",
                        //carouFredSel--,
                        "~/Ressource/js/library/carouFredSel/jquery.carouFredSel-6.2.1-packed.js",

                        //SLIDER REVOLUTION 4.x SCRIPTS--,
                        "~/Ressource/js/library/slider-revolution/js/jquery.themepunch.plugins.min.js",
                        "~/Ressource/js/library/slider-revolution/js/jquery.themepunch.revolution.min.js",
                         //scripts modernizr -->
                         "~/Ressource/js/library/modernizr/modernizr.js",
                         "~/Ressource/js/library/modernizr/modernizr-2.6.2.js",
                         "~/Ressource/js/library/isotope/jquery.isotope.js",
                         //scripts for current page -->
                         "~/Ressource/js/page/home.js",

                         //Main theme javaScript file--,
                         "~/Ressource/js/theme.js"

              ));

            bundles.Add(new ScriptBundle("~/bundles/pagejavascript").Include(
                "~/Ressource/js/page/inscription.js",
                "~/Ressource/js/page/profile.js",
                "~/Ressource/js/page/ElearningDAS.js"
                ));

            bundles.Add(new StyleBundle("~/bundles/fichiercss").Include(

                   "~/Ressource/css/bootstrap/bootstrap.css" ,

                    //AWESOME and ICOMOON fonts--,
                    "~/Ressource/css/fonts/awesome/css/font-awesome.css",
                    "~/Ressource/css/fonts/icomoon/style.css",
                    //Theme CSS--,
                    "~/Ressource/js/library/slider-revolution/css/settings.css",
                    "~/Ressource/css/theme.css",
                    "~/Ressource/css/notificationTheme.css",
                    "~/Ressource/css/theme-elements.css",
                    "~/Ressource/css/color/blue.css",
                    //Theme Options--,
                    "~/Ressource/css/theme-options.css"
    ));
        }
    }
}
