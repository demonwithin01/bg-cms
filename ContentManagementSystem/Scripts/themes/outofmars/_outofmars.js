var outofmars = outofmars || {};

site.mainContentSelector = 'body > .page-content';
site.initialise = function ( site )
{
    site.addPlugin( 'navigation', outofmars.navigation );
};