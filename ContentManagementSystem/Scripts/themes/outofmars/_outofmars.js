var outofmars = outofmars || {};


outofmars.mainContentSelector = document;
outofmars.initialise = function ( site )
{
    //site.addPlugin( 'navigation', outofmars.navigation );
    this.addPlugin( "PageBackground", outofmars.PageBackground );
    this.addPlugin( "Ribbon", bgrade.Ribbon );
};

var theme = outofmars;