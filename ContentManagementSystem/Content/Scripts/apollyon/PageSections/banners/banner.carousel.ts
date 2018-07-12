module apollyon
{
    export module banners
    {
        export class Carousel extends BannerBase
        {
            private _banner: Banner;

            private _nextElement: JQuery;
            private _prevElement: JQuery;

            constructor( banner: Banner )
            {
                super();

                this._banner = banner;

                this._banner.items.each( function ( index )
                {
                    $( this ).css( "left", 100 * index + "%" );
                } );

                this._prevElement = this.createNavElement( "left" ).appendTo( this._banner.element ).addClass( "hidden" );
                this._nextElement = this.createNavElement( "right" ).appendTo( this._banner.element );

                this._prevElement.on( "click", $.proxy( this.previousClicked, this ) );
                this._nextElement.on( "click", $.proxy( this.nextClicked, this ) );
            }

            /**
             * Removes the generated elements and resets the css positions.
             */
            public unload(): void
            {
                this._banner.items.each( function ( index )
                {
                    $( this ).css( "left", "0%" );
                } );

                this._prevElement.remove();
                this._nextElement.remove();
            }

            /**
             * Handles when the screen dimensions change. At the moment this does nothing.
             */
            public dimensionsChanged(): void
            {

            }

            /**
             * Creates the element that the user can use to go forwards or backwards with the carousel.
             */
            private createNavElement( direction: string ): JQuery
            {
                return $( "<div class=\"carousel-" + direction + "\"><i class=\"icon fa fa-chevron-" + direction + "\"></i></div>" );
            }

            /**
             * Tells the carousel to scroll to the next slide and reset the interval.
             */
            private nextClicked(): void
            {
                this.goToNext();
                this._banner.resetInterval();
            }

            /**
             * Tells the carousel to scroll back to the previous slide and reset the interval.
             */
            private previousClicked(): void
            {
                this.goToPrev();
                this._banner.resetInterval();
            }

            /**
             * Tells the carousel to scroll to the next slide.
             */
            private goToNext()
            {
                var $pole = this._banner.items.filter( ".pole-position" );
                var $next = $pole.next();

                if ( $next.length == 0 )
                {
                    return;
                }

                if ( $next.index() > 0 )
                {
                    this._prevElement.removeClass( "hidden" );
                }

                var position = 0;

                $next.prevAll().each( function ()
                {
                    position += $( this ).width();
                } );

                if ( $next.index() == this._banner.items.length - 1 )
                {
                    this._nextElement.addClass( "hidden" );
                }

                $pole.removeClass( "pole-position" );
                $next.addClass( "pole-position" );
                this._banner.inner.css( "left", -position );
            }

            /**
             * Tells the carousel to scroll back to the previous slide.
             */
            private goToPrev()
            {
                var $pole = this._banner.items.filter( ".pole-position" );
                var $prev = $pole.prev();

                if ( $pole.index() < this._banner.items.length )
                {
                    this._nextElement.removeClass( "hidden" );
                }

                if ( $prev.length == 0 )
                {
                    return;
                }

                var position = 0;

                $prev.prevAll().each( function ()
                {
                    position += $( this ).width();
                } );

                if ( $prev.index() == 0 )
                {
                    this._prevElement.addClass( "hidden" );
                }

                $pole.removeClass( "pole-position" );
                $prev.addClass( "pole-position" );
                this._banner.inner.css( "left", -position );
            }

            /**
             * Tells the carousel to scroll back to the start.
             */
            private goToStart()
            {
                var $pole = this._banner.items.filter( ".pole-position" );
                var $next = this._banner.items.first();

                if ( this._banner.items.length > 1 )
                {
                    this._nextElement.removeClass("hidden");
                }

                this._prevElement.addClass("hidden");

                $pole.removeClass( "pole-position" );
                $next.addClass( "pole-position" );
                this._banner.inner.css( "left", 0 );
            }

            public intervalExpired()
            {
                var $pole = this._banner.items.filter( ".pole-position" );
                var $next = $pole.next();

                if ( $next.length == 0 )
                {
                    this.goToStart();
                    return;
                }

                this.goToNext();
            }
        }
    }
}