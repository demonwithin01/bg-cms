var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var apollyon;
(function (apollyon) {
    var BlogPost = (function () {
        function BlogPost(element, blogs) {
            this._element = element;
            this._blogs = blogs;
            this._innerContent = this._element.find(".blog-inner-content");
            //this._canvas = document.createElement( "canvas" );
            //this._innerContent.prepend( this._canvas );
            //this._canvas.style.position = "absolute";
            //this._canvas.style.left = "0px";
            //this._canvas.style.top = "0px";
            //this._canvas.style.zIndex = "0";
            //this._canvas.style.pointerEvents = "none";
            //this._context = this._canvas.getContext( "2d" );
            //this.draw();
        }
        BlogPost.prototype.draw = function () {
            var x = 0, y = 0, w = this._innerContent.outerWidth(), h = this._innerContent.outerHeight();
            this._canvas.width = w;
            this._canvas.height = h;
            this._context.clearRect(x, y, w, h);
            //this._context.fillStyle = "rgba( 0, 0, 0, 0.2 )";
            //this._context.fillRect( x, y, w, h );
        };
        return BlogPost;
    }());
    var Blogs = (function (_super) {
        __extends(Blogs, _super);
        function Blogs() {
            return _super !== null && _super.apply(this, arguments) || this;
        }
        Blogs.prototype.init = function () {
            this._blogPosts = new Array();
            var that = this;
            $(".blog-post").each(function () {
                that._initialiseBlogPost($(this));
            });
        };
        Blogs.prototype.name = function () {
            return "Blogs";
        };
        Blogs.prototype.onResize = function (dim) {
            for (var i = 0; i < this._blogPosts.length; i++) {
                this._blogPosts[i].draw();
            }
        };
        Blogs.prototype._initialiseBlogPost = function (element) {
            this._blogPosts.push(new BlogPost(element, this));
        };
        return Blogs;
    }(apollyon.PageSection));
    apollyon.Blogs = Blogs;
})(apollyon || (apollyon = {}));
//# sourceMappingURL=blogs.js.map