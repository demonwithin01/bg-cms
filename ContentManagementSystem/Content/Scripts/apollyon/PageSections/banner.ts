module apollyon
{
    export abstract class BannerBase
    {
        public abstract unload(): void;
        public abstract dimensionsChanged(): void;
    }

    export class Banner extends PageSection
    {
        private _height: number;
        private _width: number;
        private _element: JQuery;
        private _bannerType: BannerType;
        private _banner: BannerBase = null;
        private _inner: JQuery;
        private _items: JQuery;

        constructor( element: JQuery, options: any )
        {
            super();

            this._element = element;
            this._inner = element.find( ".carousel-inner" );
            this._items = element.find( ".carousel-item" );
            this._width = options.width;
            this._height = options.height;

            this.bannerType = options.bannerType;
        }

        public init(): void
        {
            console.log( "initialised Banner" );
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

        }

        get width(): number
        {
            return this._width;
        }
        set width( value: number )
        {
            this._width = value;

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
            }
        }
    }

    export class BannerAdmin extends Banner
    {

    }
}