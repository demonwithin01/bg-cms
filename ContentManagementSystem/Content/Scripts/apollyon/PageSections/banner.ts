module apollyon
{
    export abstract class BannerBase
    {
        public abstract unload(): void;
        public abstract dimensionsChanged(): void;
        public abstract intervalExpired(): void;
    }

    export class Banner extends PageSection
    {
        private _height: number;
        private _width: number;
        private _timer: number;
        private _element: JQuery;
        private _bannerType: BannerType;
        private _banner: BannerBase = null;
        private _inner: JQuery;
        private _items: JQuery;
        private _interval: number;

        constructor( element: JQuery, options: any )
        {
            super();

            console.log( options );

            this._element = element;
            this._inner = element.find( ".carousel-inner" );
            this._items = element.find( ".carousel-item" );
            this.width = options.width;
            this.height = options.height;
            this._timer = options.timer || 0;

            this._items.first().addClass( "pole-position" );

            this.bannerType = options.bannerType;

            this._element.data( "ap-banner", this );
        }

        public init(): void
        {
            
        }

        public unload(): void
        {
            clearInterval( this._interval );
            this._banner.unload();
        }

        /**
         * Clears the current interval and restarts it if there is more than 1 item in the carousel.
         */
        public resetInterval()
        {
            clearInterval( this._interval );

            if ( this.items.length > 1 && this._timer > 0 )
            {
                this._interval = setInterval( $.proxy( this._banner.intervalExpired, this._banner ), this._timer * 1000 );
            }
        }

        public name(): string
        {
            return "Banner";
        }

        get height(): number
        {
            return this._height;
        }
        set height( value: number )
        {
            this._height = value;

            this._element.height( value );
        }

        get width(): number
        {
            return this._width;
        }
        set width( value: number )
        {
            this._width = value;

            this._element.width( value );
        }

        get element(): JQuery
        {
            return this._element;
        }

        get inner(): JQuery
        {
            return this._inner;
        }

        get items(): JQuery
        {
            return this._items;
        }

        get bannerType(): BannerType
        {
            return this._bannerType;
        }
        set bannerType( value: BannerType )
        {
            if ( this._bannerType == value )
            {
                return;
            }

            if ( this._banner != null )
            {
                this._banner.unload();
            }

            this._bannerType = value;
            
            switch ( this._bannerType )
            {
                case BannerType.Carousel:
                    this._banner = new banners.Carousel( this );
                    break;
                case BannerType.FadeOver:
                    this._banner = new banners.FadeOut( this );
                    break;
            }

            this.resetInterval();
        }
    }
}