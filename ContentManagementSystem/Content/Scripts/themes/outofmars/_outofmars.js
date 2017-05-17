var outofmars = outofmars || {};


outofmars.mainContentSelector = document;
outofmars.initialise = function ( site )
{
    //site.addPlugin( 'navigation', outofmars.navigation );
    
    this.addPlugin( "Ribbon", apollyon.Ribbon );
};

var theme = outofmars;