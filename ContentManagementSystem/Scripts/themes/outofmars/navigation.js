outofmars.navigation = function ( mySite )
{
    var base = site.plugin.call( this );
    var _site = mySite;

    this.onWindowResize = function ( dim )
    {
        if ( dim.width < 960 )
        {
            $( 'header' ).removeClass( 'always-open' );
        }
        else
        {
            $( 'header' ).addClass( 'always-open' ).removeClass( 'open' ).removeClass( 'changing' );
        }
    };
};

outofmars.navigation.prototype = Object.create( site.plugin.prototype );