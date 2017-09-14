module apollyon
{
    class BlogPost
    {
        private _element: JQuery;
        private _blogs: Blogs;
        private _innerContent: JQuery;
        private _canvas: HTMLCanvasElement;
        private _context: CanvasRenderingContext2D;

        constructor( element: JQuery, blogs: Blogs )
        {
            this._element = element;
            this._blogs = blogs;

            this._innerContent = this._element.find( ".blog-inner-content" );

            this._canvas = document.createElement( "canvas" );
            this._innerContent.prepend( this._canvas );

            this._canvas.style.position = "absolute";
            this._canvas.style.left = "0px";
            this._canvas.style.top = "0px";
            this._canvas.style.zIndex = "0";
            this._canvas.style.pointerEvents = "none";

            this._context = this._canvas.getContext( "2d" );

            this.draw();
        }

        public draw(): void
        {
            var x = 0,
                y = 0,
                w = this._innerContent.outerWidth(),
                h = this._innerContent.outerHeight();

            this._canvas.width = w;
            this._canvas.height = h;

            this._context.clearRect( x, y, w, h );

            //this._context.fillStyle = "rgba( 0, 0, 0, 0.2 )";
            //this._context.fillRect( x, y, w, h );
        }
    }

    export class Blogs extends PageSection
    {
        private _blogPosts: Array<BlogPost>;

        public init(): void
        {
            this._blogPosts = new Array<BlogPost>();

            var that = this;

            $( ".blog-post" ).each( function ()
            {
                that._initialiseBlogPost( $( this ) );
            });
        }

        public name(): string
        {
            return "Blogs";
        }

        public onResize( dim ): void
        {
            for ( var i = 0; i < this._blogPosts.length; i++ )
            {
                this._blogPosts[i].draw();
            }
        }

        private _initialiseBlogPost( element: JQuery ): void
        {
            this._blogPosts.push( new BlogPost( element, this ) );
        }
    }
}