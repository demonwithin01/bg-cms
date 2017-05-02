using System.IO;
using System.Web;
using System.Web.Optimization;

namespace ContentManagementSystem
{
    //TODO: Refactor to join bundles together.
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

            bundles.Add( new ScriptBundle( "~/bundles/site" )
                            .Include(
                                "~/Scripts/Extensions/jquery.js",
                                "~/Scripts/Plugins/jssocials.min.js",
                                "~/Scripts/bgrade/bg.modal.js",
                                "~/Scripts/bgrade/site.image-browser.js",
                                "~/Scripts/bgrade/site.types.js",
                                "~/Scripts/bgrade/site.js",
                                "~/Scripts/bgrade/site.plugin.js",
                                "~/Scripts/bgrade/bgrade.ribbon.js",
                                "~/Scripts/bgrade/_page-section.js" )
                            .IncludeDirectory( "~/Scripts/PageSections/", "*.js" ) );
            
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
                                            "~/Scripts/bgrade/site.image-browser.js"
                                        ) );

            bundles.Add( new StyleBundle( "~/Content/css" ).Include(
                CssFile( "_reset" ),
                CssFile( "Plugins/jssocials" ),
                CssFile( "Plugins/jssocials-theme-flat" ) ) );

//#if !DEBUG
//            bundles.Add( new StyleBundle( "~/Content/css" ).Include( 
//                "~/Content/Styles/_reset.min.css",
//                "~/Content/Styles/Plugins/jssocials.css",
//                "~/Content/Styles/Plugins/jssocials-theme-flat.css" ) );
//                //"~/Content/Styles/site.min.css"
//#else
//            bundles.Add( new StyleBundle( "~/Content/css" ).Include(
//                "~/Content/Styles/_reset.min.css",
//                "~/Content/Styles/Plugins/jssocials.css",
//                "~/Content/Styles/Plugins/jssocials-theme-flat.css" ) );
//            //"~/Content/Styles/site.css" 
//#endif

            bundles.Add( new StyleBundle( "~/Content/admincss" ).Include(
                CssFile( "_reset" ),
                "~/Content/Styles/Plugins/spectrum.css",
                CssFile( "admin" ) ) );

//#if !DEBUG
//            bundles.Add( new StyleBundle( "~/Content/admincss" ).Include( 
//                "~/Content/Styles/_reset.min.css",
//                "~/Content/Styles/Plugins/spectrum.css",
//                "~/Content/Styles/admin.min.css" ) );
//#else
//            bundles.Add( new StyleBundle( "~/Content/admincss" ).Include(
//                "~/Content/Styles/_reset.min.css",
//                "~/Content/Styles/Plugins/spectrum.css",
//                "~/Content/Styles/admin.css" ) );
//#endif

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



            var themeDirectories = Directory.GetDirectories( HttpContext.Current.Server.MapPath( "~/scripts/themes/" ) );

            foreach ( var themeDirectory in themeDirectories )
            {
                var directoryName = themeDirectory.Substring( Path.GetDirectoryName( themeDirectory ).Length + 1 );

                bundles.Add( new ScriptBundle( "~/scripts/theme/" + directoryName )
                    .Include( "~/scripts/themes/" + directoryName + "/_" + directoryName + ".js" )
                    .IncludeDirectory( "~/scripts/themes/" + directoryName, "*.js" ) );
            }
        }

        /// <summary>
        /// Generates the path to the CSS file based off the current DEBUG mode.
        /// </summary>
        /// <param name="fileName">The file name and sub path for the css file.</param>
        /// <returns>The virtual location of the css file.</returns>
        private static string CssFile( string fileName )
        {
#if DEBUG
            string end = ".css";
#else
            string end = ".min.css";
#endif

            return "~/Content/Styles/" + fileName + end;
        }
    }
}