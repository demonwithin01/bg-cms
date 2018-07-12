module apollyon
{
    export module banners
    {
        export class FadeOut extends BannerBase
        {
            private _banner: Banner;
            private _optionsContainer: JQuery;

            constructor( banner: Banner )
            {
                super();

                this._banner = banner;

                this._optionsContainer = $( "<div class=\"banner-option-container\"></div>" ).appendTo( this._banner.element );

                var that = this;

                for ( var i = 0; i < this._banner.items.length; i++ )
                {
                    this._banner.items.eq( i ).css( {
                        "z-index": ( i == 0 ? 2 : 1 ),
                        opacity: ( i == 0 ? 1 : 0 )
                    } );
                    
                    this.createNavElement( i ).appendTo( this._optionsContainer ).on( "click", function ()
                    {
                        that.itemSelected( $( this ) );
                    } ).toggleClass( "current", i == 0 );
                }
            }

            public unload(): void
            {

            }

            public dimensionsChanged(): void
            {

            }

            public intervalExpired(): void
            {

            }

            private itemSelected( element: JQuery ): void
            {
                var index = element.index();
                var $pole = this._banner.items.filter( ".pole-position" );
                var $next = this._banner.items.eq( index );

                if ( index == $pole.index() )
                {
                    return;
                }

                $next.addClass( "transit" ).get( 0 ).offsetWidth;
                
                $next.css( {
                    "z-index": 3,
                    opacity: 1
                } ).on( "transitionend", function ()
                {
                    $pole.removeClass( "pole-position" ).css( { "z-index": 1, opacity: 0 } );
                    $next.removeClass( "transit" ).off( "transitionend" ).addClass( "pole-position" ).css( "z-index", 2 );
                } );

                this._optionsContainer.children().eq( $pole.index() ).removeClass( "current" );
                element.addClass( "current" );
            }

            private createNavElement( index: Number ): JQuery
            {
                return $( "<div class=\"banner-option\" data-index=\"" + index + "\"></div>" );
            }
        }
    }
}