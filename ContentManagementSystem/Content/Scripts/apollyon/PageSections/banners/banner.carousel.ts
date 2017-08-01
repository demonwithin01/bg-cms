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

                this._prevElement = this.createNavElement( "left" ).appendTo( this._banner.element );
                this._nextElement = this.createNavElement( "right" ).appendTo( this._banner.element );

                this._prevElement.on( "click", $.proxy( this.previousClicked, this ) );
                this._nextElement.on( "click", $.proxy( this.nextClicked, this ) );
            }

            public unload(): void
            {
                this._prevElement.remove();
                this._nextElement.remove();
            }

            public dimensionsChanged(): void
            {

            }

            private createNavElement( direction: string ): JQuery
            {
                return $( "<div class=\"carousel-" + direction + "\"><i class=\"icon fa fa-" + direction + "\"></i></div>" );
            }

            private nextClicked(): void
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
                });

                if ( $next.index() == this._banner.items.length - 1 )
                {
                    this._nextElement.addClass( "hidden" );
                }

                $pole.removeClass( "pole-position" );
                $next.addClass( "pole-position" );
                this._banner.inner.css( "left", -position );
            }

            private previousClicked(): void
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
                });

                if ( $prev.index() == 0 )
                {
                    this._prevElement.addClass( "hidden" );
                }

                $pole.removeClass( "pole-position" );
                $prev.addClass( "pole-position" );
                this._banner.inner.css( "left", -position );
            }
        }
    }
}