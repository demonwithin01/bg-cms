function Site()
{
    var _this = this;

    this.contactForm = new Contact();
    this.notification = new Notification();
    this.animate = new Animations();

    var _plugins = {};

    function init()
    {
        $( "#social" ).jsSocials( {
            shares: ["facebook"]//, "twitter", "googleplus", "linkedin", "pinterest", "stumbleupon", "whatsapp"]
        } );

        attachEventHandlers();

        $( window ).resize();

        setTimeout( function ()
        {
            $( "#body" ).addClass( "on" );
        }, 600 );

        site.initialise( _this );

        raiseEvent( "onPageInitialise" );
    }

    function attachEventHandlers()
    {
        $( window ).on( "resize", handleResize );
        $( ".menu-link" ).on( "click", handleMenuLinkClick );
        $( site.mainContentSelector ).on( "scroll", handleScroll );
        $( ".page-content" ).on( "scroll", function () { console.log( "hello world" ); } );
        //$( document ).on( "scroll",  function (e)
        //{
        //    console.log( "scrolling" );
        //} );
    }

    function handleResize()
    {
        var paddingTop = parseInt( $( ".page-header" ).outerHeight() );
        var paddingBottom = parseInt( $( "footer" ).outerHeight() );

        if ( isNaN( paddingTop ) ) paddingTop = 0;
        if ( isNaN( paddingBottom ) ) paddingBottom = 0;

        $( "#body" ).css( {
            "padding-bottom": paddingBottom + "px",
            "padding-top": paddingTop + "px",
        } );

        var $pageContent = $( ".page-content" );

        $pageContent.css( 'min-height', '0px' ).get( 0 ).offsetHeight;

        var minHeight = ( parseInt( $( "#body" ).outerHeight() ) - paddingTop - paddingBottom );

        $pageContent.css( "min-height", minHeight + 'px' );

        raiseEvent( "onWindowResize", { width: window.innerWidth, height: window.innerHeight } );
    }

    function handleMenuLinkClick()
    {
        var $parent = $( this ).parent();
        $parent.toggleClass( "open" );

        if ( $parent.hasClass( "open" ) == false )
        {
            $parent.addClass( "changing" );

            setTimeout( function ()
            {
                $parent.removeClass( "changing" );
            }, 300 );
        }
    }

    function handleScroll(e)
    {
        var pos = { top: e.target.scrollTop, left: e.target.scrollLeft };

        if ( e.target.scrollTop != undefined )
        {
            pos = { top: e.target.scrollTop, left: e.target.scrollLeft };
        }
        else if ( e.target.scrollingElement != $( "body" ).get( 0 ) )
        {
            return;
        }
        else
        {
            pos = { top: e.target.scrollingElement.scrollTop, left: e.target.scrollingElement.scrollLeft };
        }

        $( "#social" ).css( "top", ( pos.top + 60 ) + "px" );
        
        raiseEvent( "onMainContentScroll", pos );
    }

    function raiseEvent( event, args )
    {
        /// <summary>Raises the specified event</summary>
        /// <param name="event">The name of the event to be raised</param>
        /// <param name="args">The arguments to be raised with the event</param>

        for ( var plugin in _plugins )
        {
            var func = _plugins[plugin][event];

            if ( func == undefined || typeof ( func ) !== "function" )
            {
                continue;
            }

            func.call( _this, args );
        }
    }

    this.addPlugin = function ( name, plugin )
    {
        if ( _plugins[name] != undefined )
        {
            console.error( "Error: Plugin \"" + name + "\" already exists" );

            return;
        }

        _plugins[name] = new plugin( _this );

        _plugins[name].initialise();
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