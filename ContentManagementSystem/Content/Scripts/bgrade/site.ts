// // <reference path="./jquery.extensions.js" />

module bgrade
{
    export class Site
    {
        private _plugins: any = {};
        private _pageSections: Array<PageSection>;
        
        private _isInitialised: boolean = false;
        
        constructor()
        {
            this._isInitialised = false;
            this._pageSections = new Array<PageSection>();
            
            $( "#social" ).jsSocials( {
                shares: ["facebook"]//, "twitter", "googleplus", "linkedin", "pinterest", "stumbleupon", "whatsapp"]
            });

            this.attachEventHandlers();

            $( window ).resize();

            setTimeout( function ()
            {
                $( "#body" ).addClass( "on" );
            }, 600 );

            if ( theme )
            {
                theme.initialise.call( this );
            }

            this.raiseEvent( "onPageInitialise" );

            for ( var i = 0; i < this._pageSections.length; i++ )
            {
                this._pageSections[i].init();
            }

            this._isInitialised = true;
        }

        public initialise()
        {

        }

        public addPlugin( name: string, plugin: any ): void
        {
            if ( this._plugins[name] != undefined )
            {
                console.error( "Error: Plugin \"" + name + "\" already exists" );

                return;
            }

            this._plugins[name] = new plugin( this );
            this._plugins[name].initialise();
        }

        public removePlugin( name: string ): void
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

        public initialisePageSection( section: PageSection ): void
        {
            this._pageSections.push( section );

            if ( this._isInitialised )
            {
                section.init();
            }
        }

        public pageSection( sectionName: string ): PageSection
        {
            for ( var i = 0; i < this._pageSections.length; i++ )
            {
                if ( this._pageSections[i].name() == sectionName )
                {
                    return this._pageSections[i];
                }
            }

            return null;
        }

        /**
         * Shows a notification on the screen.
         * @param {notificationType} nType The notification type.
         * @message {string} message The message to display.
         * @time {bool?|number?} time If true, the message is displayed until user interaction. If a number, the notification will be displayed for a set period of time.
         */
        public showNotification( nType, message, time )
        {
            var type: string;

            switch ( nType )
            {
                case notificationType.success:
                    type = "success";
                    break;
                case notificationType.error:
                    type = "error";
                    break;
                default: // warning
                    type = "warning";
                    break;
            }

            var $notification = $( "<div class=\"notification notification-" + type + "\"><div><p>" + message + "</p><span class=\"fa fa-remove\" onclick=\"_site.removeNotification( this );\"></span></div></div>" );

            var removing = $( ".notification:not(.show)" );

            if ( removing.length > 0 )
            {
                var height = removing.outerHeight() + 15;

                $notification.addClass( "shift-up" ).css( "transform", "translateY(-" + height + "px)" );
            }
            
            if ( time !== true )
            {
                if ( typeof ( time ) !== "number" )
                {
                    time = 5000;
                }

                $notification.data( "notification-timeout", setTimeout( function ()
                {
                    _site.removeNotification( $notification );
                }, time + 300 ) );

                $notification.children().prepend( "<span class=\"time\" style=\"transition: width " + time + "ms linear 0.3s;\"></span>" );
            }

            $( "#notifications" ).appendThen( $notification, function ()
            {
                $notification.addClass( "show" );
                $notification.find( ".time" ).css( "width", "100%" );
            });

        }

        /**
         * Removes the notification from the page.
         * @param {jQuery} element The notification element or one of its descendents.
         */
        public removeNotification( element )
        {
            var $notification = $( element ).closest( ".notification" ).removeClass( "show" );

            $notification.removeData( "notification-timeout" );

            var height = $notification.outerHeight() + 15;

            $notification.nextAll().each( function ()
            {
                $( this ).addClass( "shift-up" ).css( "transform", "translateY(-" + height + "px)" );
            });

            setTimeout( function ()
            {
                $notification.nextAll().each( function ()
                {
                    $( this ).removeClass( "shift-up" ).css( "transform", "" );
                });

                $notification.remove();
            }, 300 );
        }
        
        private attachEventHandlers()
        {
            $( window ).on( "resize", $.proxy( this.handleResize, this ) );
            $( ".menu-link" ).on( "click", $.proxy( this.handleMenuLinkClick, this ) );
            if ( theme )
            {
                $( theme.mainContentSelector ).on( "scroll", $.proxy( this.handleScroll, this ) );
            }
        }

        private handleResize()
        {
            var dimensions = { width: window.innerWidth, height: window.innerHeight };
            this.raiseEvent( "onWindowResize", dimensions );

            for ( var i = 0; i < this._pageSections.length; i++ )
            {
                try
                {
                    this._pageSections[i].onResize( dimensions );
                }
                catch ( e )
                {
                    console.error( e );
                }
            }
        }

        private handleMenuLinkClick()
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

        private handleScroll( e )
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

            this.raiseEvent( "onMainContentScroll", pos );
        }

        private raiseEvent( event, args? )
        {
            /// <summary>Raises the specified event</summary>
            /// <param name="event">The name of the event to be raised</param>
            /// <param name="args">The arguments to be raised with the event</param>

            for ( var plugin in this._plugins )
            {
                var func = this._plugins[plugin][event];

                if ( func == undefined || typeof ( func ) !== "function" )
                {
                    continue;
                }
                try
                {
                    func.call( this._plugins[plugin], args, this );
                }
                catch ( e )
                {
                    console.error( e );
                }
            }
        }
    }
}

var theme;