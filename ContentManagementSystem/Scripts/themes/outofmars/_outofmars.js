var outofmars = outofmars || {};

site.mainContentSelector = document;
site.initialise = function ( site )
{
    site.addPlugin( 'navigation', outofmars.navigation );
    site.addPlugin( "PageBackground", outofmars.PageBackground );
};