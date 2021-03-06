﻿using System.IO;
using System.Web;
using System.Web.Optimization;

namespace ContentManagementSystem
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles( BundleCollection bundles )
        {
            bundles.Add( new ScriptBundle( "~/bundles/external" ).Include(
                "~/Content/Scripts/Frameworks/modernizr-*",
                "~/Content/Scripts/Frameworks/jquery-{version}.js", 
                "~/Content/Scripts/Frameworks/jquery.unobtrusive*",
                "~/Content/Scripts/Frameworks/jquery.validate*",
                "~/Content/Scripts/Plugins/jssocials.min.js" ) );
            
            bundles.Add( new ScriptBundle( "~/bundles/siteadmin" ).Include(
                        "~/Content/Scripts/Plugins/ckeditor/ckeditor.js",
                        //"~/Content/Scripts/Plugins/ckeditor/styles.js",
                        //"~/Content/Scripts/Plugins/ckeditor/config.js"
                        "~/Content/Scripts/Plugins/spectrum.js",
                        "~/Content/Scripts/Plugins/dropzone.js"
                    )
                    .IncludeDirectory( "~/Content/Scripts/Apollyon/Admin/", "*.js" ) );

            bundles.Add( new ScriptBundle( "~/bundles/site" )
                            .Include(
                                "~/Content/Scripts/Extensions/jquery.js",
                                AScript( "Extensions/carousel" ),
                                AScript( "Extensions/modal" ),
                                AScript( "Extensions/loading" ),
                                AScript( "Extensions/load" ),
                                AScript( "site.types" ),
                                AScript( "Bases/_page-section" ),
                                AScript( "Bases/plugin" ),
                                AScript( "site" ),
                                AScript( "Workers/ImageBrowser" ),
                                AScript( "Workers/Ribbon" ),
                                AScript( "Workers/TemplateEditor" ),
                                AScript( "Workers/UploadSelector" ) )
                            .IncludeDirectory( "~/Content/Scripts/Apollyon/PageSections/", "*.js", false )
                            .IncludeDirectory( "~/Content/Scripts/Apollyon/PageSections/banners", "*.js" ) );

            bundles.Add( new ScriptBundle( "~/bundles/image-upload-page" ).Include(
                                            "~/Content/Scripts/Frameworks/modernizr-*",
                                            "~/Content/Scripts/Frameworks/jquery-{version}.js",
                                            "~/Content/Scripts/Frameworks/jquery-migrate-1.2.1.min.js",
                                            "~/Content/Scripts/Frameworks/jquery-ui-{version}.js",
                                            "~/Content/Scripts/Frameworks/jquery.unobtrusive*",
                                            "~/Content/Scripts/Frameworks/jquery.validate*",
                                            "~/Content/Scripts/Frameworks/jquery.form.js",
                                            AScript( "Workers/ImageBrowser" )
                                        ) );

            bundles.Add( new StyleBundle( "~/Content/css" ).Include(
                CssFile( "_reset" ),
                CssFile( "Plugins/jssocials" ),
                CssFile( "Plugins/jssocials-theme-flat" ) ) );
            
            bundles.Add( new StyleBundle( "~/Content/admincss" ).Include(
                CssFile( "_reset" ),
                "~/Content/Styles/Plugins/spectrum.css",
                CssFile( "admin" ) ) );
            
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
            
            var themeDirectories = Directory.GetDirectories( HttpContext.Current.Server.MapPath( "~/content/scripts/themes/" ) );

            foreach ( var themeDirectory in themeDirectories )
            {
                var directoryName = themeDirectory.Substring( Path.GetDirectoryName( themeDirectory ).Length + 1 );

                bundles.Add( new ScriptBundle( "~/scripts/theme/" + directoryName )
                    .Include( "~/Content/Scripts/themes/" + directoryName + "/_" + directoryName + ".js" )
                    .IncludeDirectory( "~/Content/Scripts/themes/" + directoryName, "*.js" ) );
            }
        }

        /// <summary>
        /// Generates the path to the CSS file based off the current DEBUG mode.
        /// </summary>
        /// <param name="fileName">The file name and sub-path for the css file.</param>
        /// <returns>The virtual location of the css file.</returns>
        private static string CssFile( string fileName )
        {
#if DEBUG
            string fileExtension = ".css";
#else
            string fileExtension = ".min.css";
#endif

            return "~/Content/Styles/" + fileName + fileExtension;
        }

        /// <summary>
        /// Generates the path to the Javascript file within the Apollyon scripts folder.
        /// </summary>
        /// <param name="filename">The file name ane sub-path for the javascript file.</param>
        /// <returns>The virtual location of the javascript file.</returns>
        private static string AScript( string filename )
        {
            return "~/Content/Scripts/Apollyon/" + filename + ".js";
        }
    }
}