rachelsheree.navigation = function ( mySite )
{
    var base = site.plugin.call( this );
    var _site = mySite;

    var _headerHeight = undefined;

    this.onPageInitialise = function ()
    {
        var scroll = $( 'body' ).get( 0 );

        var pos = { top: scroll.scrollTop, left: scroll.scrollLeft };
        var dim = { width: window.innerWidth, height: window.innerHeight };

        if ( dim.width < 960 )
        {
            _headerHeight = 40;
        }
        else
        {
            _headerHeight = 180;
        }

        $( 'header' ).next( '.page-content' ).css( { 'padding-top': _headerHeight } );

        configureHeader( pos, dim );
    }

    this.onWindowResize = function ( dim )
    {
        var scroll = $( 'body' ).get( 0 );

        configureHeader( { top: scroll.scrollTop, left: scroll.scrollLeft }, dim );

        if ( dim.width < 960 )
        {
            _headerHeight = 40;
        }
        else
        {
            _headerHeight = 180;
        }

        $( 'header' ).next( '.page-content' ).css( { 'padding-top': _headerHeight } );

        //$( 'header' ).height();
        //if ( dim.width < 960 )
        //{
        //    $( 'header' ).removeClass( 'always-open' );
        //}
        //else
        //{
        //    $( 'header' ).addClass( 'always-open' ).removeClass( 'open' ).removeClass( 'changing' );
        //}
    };

    this.onMainContentScroll = function ( pos )
    {
        configureHeader( pos, { width: window.innerWidth, height: window.innerHeight } );
    };

    this.initialise = function ()
    {
        var scroll = $( 'body' ).get( 0 );

        configureHeader( { top: scroll.scrollTop, left: scroll.scrollLeft }, { width: window.innerWidth, height: window.innerHeight } );
    }

    function configureHeader( pos, dim )
    {
        var $header = $( 'header' );

        if ( _headerHeight == undefined )
        {
            _headerHeight = $header.height();
        }

        if ( pos.top > _headerHeight || dim.width < 960 )
        {
            $header.addClass( 'mini' );
        }
        else
        {
            $header.removeClass( 'mini' );
        }

        $header.css( { top: pos.top } );
    }
};

rachelsheree.navigation.prototype = Object.create( site.plugin.prototype );