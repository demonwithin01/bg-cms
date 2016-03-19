using System.Web;
using System.Web.Optimization;

namespace ContentManagementSystem
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles( BundleCollection bundles )
        {
            bundles.Add( new ScriptBundle( "~/bundles/jquery" ).Include(
                        "~/Scripts/Frameworks/jquery-{version}.js" ) );

            bundles.Add( new ScriptBundle( "~/bundles/jqueryui" ).Include(
                        "~/Scripts/Frameworks/jquery-ui-{version}.js" ) );

            bundles.Add( new ScriptBundle( "~/bundles/jqueryval" ).Include(
                        "~/Scripts/Frameworks/jquery.unobtrusive*",
                        "~/Scripts/Frameworks/jquery.validate*" ) );

            bundles.Add( new ScriptBundle( "~/bundles/siteadmin" ).Include(
                        "~/Scripts/Plugins/ckeditor/ckeditor.js",
                        //"~/Scripts/Plugins/ckeditor/styles.js",
                        //"~/Scripts/Plugins/ckeditor/config.js"
                        "~/Scripts/Plugins/spectrum.js"
                        ) );

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add( new ScriptBundle( "~/bundles/modernizr" ).Include(
                        "~/Scripts/Frameworks/modernizr-*" ) );

            bundles.Add( new ScriptBundle( "~/bundles/site" ).Include(
                        "~/Scripts/site.contact.js",        
                        "~/Scripts/site.notification.js",
                        "~/Scripts/site.animations.js",
                        "~/Scripts/site.image-browser.js",
                        "~/Scripts/site.js" ) );

            //bundles.Add( new ScriptBundle( "~/bundles/siteadmin" ).Include(
            //            "~/Scripts/Plugins/dropzone.js" ) );

            bundles.Add( new ScriptBundle( "~/bundles/filedrop" ).Include(
                        "~/Scripts/Plugins/dropzone.js" ) );

            bundles.Add( new ScriptBundle( "~/bundles/image-upload-page" ).Include(
                                            "~/Scripts/Frameworks/modernizr-*",
                                            "~/Scripts/Frameworks/jquery-{version}.js",
                                            "~/Scripts/Frameworks/jquery-migrate-1.2.1.min.js",
                                            "~/Scripts/Frameworks/jquery-ui-{version}.js",
                                            "~/Scripts/Frameworks/jquery.unobtrusive*",
                                            "~/Scripts/Frameworks/jquery.validate*",
                                            "~/Scripts/Frameworks/jquery.form.js",
                                            "~/Scripts/site.image-browser.js"
                                        ) );

#if !DEBUG
            bundles.Add( new StyleBundle( "~/Content/css" ).Include( 
                "~/Content/Styles/_reset.min.css",
                "~/Content/Styles/site.min.css" ) );
#else
            bundles.Add( new StyleBundle( "~/Content/css" ).Include( 
                "~/Content/Styles/_reset.min.css",
                "~/Content/Styles/site.css" ) );
#endif

#if !DEBUG
            bundles.Add( new StyleBundle( "~/Content/admincss" ).Include( 
                "~/Content/Styles/_reset.min.css",
                "~/Content/Styles/Plugins/spectrum.css",
                "~/Content/Styles/admin.min.css" ) );
#else
            bundles.Add( new StyleBundle( "~/Content/admincss" ).Include(
                "~/Content/Styles/_reset.min.css",
                "~/Content/Styles/Plugins/spectrum.css",
                "~/Content/Styles/admin.css" ) );
#endif

            bundles.Add( new StyleBundle( "~/Content/image-browser-css" ).Include(
                "~/Content/Styles/image-browser.css" ) );

            bundles.Add( new StyleBundle( "~/Content/themes/base/css" ).Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css" ) );
        }
    }
}