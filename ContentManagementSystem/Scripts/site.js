function Site()
{
    var _this = this;

    this.contactForm = new Contact();
    this.notification = new Notification();
    this.animate = new Animations();

    var _plugins = {};

    function init()
    {
        $( '#social' ).jsSocials( {
            shares: ['facebook', 'twitter', 'googleplus', 'linkedin', 'pinterest', 'stumbleupon', 'whatsapp']
        } );

        attachEventHandlers();

        $( window ).resize();

        setTimeout( function ()
        {
            $( '#body' ).addClass( 'on' );
        }, 600 );

        site.initialise( _this );
    }

    function attachEventHandlers()
    {
        $( window ).on( 'resize', handleResize );
        $( '.menu-link' ).on( 'click', handleMenuLinkClick );
        $( site.mainContentSelector ).on( 'scroll', handleScroll );
    }

    function handleResize()
    {
        $( '#body' ).css( {
            'padding-bottom': $( 'footer' ).outerHeight(),
            'padding-top': $( '.page-header' ).outerHeight(),
        } );

        raiseEvent( 'onWindowResize', { width: window.innerWidth, height: window.innerHeight } );
    }

    function handleMenuLinkClick()
    {
        var $parent = $( this ).parent();
        $parent.toggleClass( 'open' );

        if ( $parent.hasClass( 'open' ) == false )
        {
            $parent.addClass( 'changing' );

            setTimeout( function ()
            {
                $parent.removeClass( 'changing' );
            }, 300 );
        }
    }

    function handleScroll(e)
    {
        $( '#social' ).css( 'top', ( e.target.scrollTop + 60 ) + 'px' );

        raiseEvent( 'onMainContentScroll', { top: e.target.scrollTop, left: e.target.scrollLeft } );
    }

    function raiseEvent( event, args )
    {
        /// <summary>Raises the specified event</summary>
        /// <param name="event">The name of the event to be raised</param>
        /// <param name="args">The arguments to be raised with the event</param>

        for ( var plugin in _plugins )
        {
            _plugins[plugin][event].call( _this, args );
        }
    }

    this.addPlugin = function ( name, plugin )
    {
        if ( _plugins[name] != undefined )
        {
            console.error( 'Error: Plugin "' + name + '" already exists' );

            return;
        }

        _plugins[name] = new plugin( _this );
    }

    this.removePlugin = function ( name )
    {
        var plugins = {};

        for ( var n in _plugins )
        {
            if ( n != name )
            {
                plugins[n] = _plugins[n];
            }
        }

        _plugins = plugins;
    }

    init();
}