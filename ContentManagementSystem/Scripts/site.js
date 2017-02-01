var Site = ( function ()
{
    function Site()
    {
        var _this = this;
        var _isInitialised = false;

        this.animate = new Animations();

        this._plugins = {};

        /**
         * @type {Array<PageSection>} An array of all the page sections on the current page.
         */
        this._pageSections = [];

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

            if ( site.initialise ) // For Admin
            {
                site.initialise( _this );
            }

            raiseEvent( "onPageInitialise" );

            for ( var i = 0; i < _this._pageSections.length; i++ )
            {
                _this._pageSections[i].init();
            }

            this._isInitialised = true;
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
            raiseEvent( "onWindowResize", { width: window.innerWidth, height: window.innerHeight } );

            var navHeight = 0;
            var headerHeight = parseInt( $( ".page-header" ).outerHeight() );
            var paddingBottom = parseInt( $( "footer" ).outerHeight() );

            if ( $( "header" ).hasClass( "always-open" ) )
            {
                navHeight = 64;
            }

            if ( isNaN( navHeight ) ) navHeight = 0;
            if ( isNaN( paddingBottom ) ) paddingBottom = 0;

            $( "#body" ).css( {
                "padding-bottom": paddingBottom + "px",
                "padding-top": headerHeight + "px",
            } );

            $( ".page-content" ).css( 'min-height', '0px' ).get( 0 ).offsetHeight;

            var bodyHeight = parseInt( $( "#body" ).outerHeight() );

            var minHeight = bodyHeight - navHeight - paddingBottom;

            $( "body > .page-content" ).css( "min-height", minHeight + "px" );

            if ( isNaN( headerHeight ) ) headerHeight = 0;

            $( "#body .page-content" ).css( "min-height", ( bodyHeight - headerHeight ) + "px" );

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

        function handleScroll( e )
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

            for ( var plugin in _this._plugins )
            {
                var func = _this._plugins[plugin][event];

                if ( func == undefined || typeof ( func ) !== "function" )
                {
                    continue;
                }

                func.call( _this, args );
            }
        }

        init.call( this );
    }


    Site.prototype.addPlugin = function ( name, plugin )
    {
        if ( this._plugins[name] != undefined )
        {
            console.error( "Error: Plugin \"" + name + "\" already exists" );

            return;
        }

        this._plugins[name] = new plugin( this );

        this._plugins[name].initialise();
    }

    Site.prototype.removePlugin = function ( name )
    {
        var plugins = {};

        for ( var n in this._plugins )
        {
            if ( n != name )
            {
                plugins[n] = this._plugins[n];
            }
        }

        this._plugins = plugins;
    }

    /**
     * Initialises the page section, or adds it to the list of sections to be initialised if the page has not yet been initialised.
     * @param {PageSection} section The section to be initialised.
     */
    Site.prototype.initialisePageSection = function ( section )
    {
        this._pageSections.push( section );

        if ( this._isInitialised )
        {
            section.init();
        }
    }

    return Site;
} )();