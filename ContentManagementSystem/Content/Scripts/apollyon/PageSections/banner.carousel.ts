module apollyon
{
    export module banners
    {
        export class Carousel extends BannerBase
        {
            private _banner: Banner;

            constructor( banner: Banner )
            {
                super();

                this._banner = banner;
            }

            public unload(): void
            {

            }

            public dimensionsChanged(): void
            {

            }
        }
    }
}