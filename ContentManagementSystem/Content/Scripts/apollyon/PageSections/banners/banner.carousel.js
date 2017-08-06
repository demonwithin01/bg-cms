var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var apollyon;
(function (apollyon) {
    var banners;
    (function (banners) {
        var Carousel = (function (_super) {
            __extends(Carousel, _super);
            function Carousel(banner) {
                _super.call(this);
                this._banner = banner;
                this._prevElement = this.createNavElement("left").appendTo(this._banner.element).addClass("hidden");
                this._nextElement = this.createNavElement("right").appendTo(this._banner.element);
                this._prevElement.on("click", $.proxy(this.previousClicked, this));
                this._nextElement.on("click", $.proxy(this.nextClicked, this));
            }
            Carousel.prototype.unload = function () {
                this._prevElement.remove();
                this._nextElement.remove();
            };
            Carousel.prototype.dimensionsChanged = function () {
            };
            Carousel.prototype.createNavElement = function (direction) {
                return $("<div class=\"carousel-" + direction + "\"><i class=\"icon fa fa-chevron-" + direction + "\"></i></div>");
            };
            Carousel.prototype.nextClicked = function () {
                var $pole = this._banner.items.filter(".pole-position");
                var $next = $pole.next();
                if ($next.length == 0) {
                    return;
                }
                if ($next.index() > 0) {
                    this._prevElement.removeClass("hidden");
                }
                var position = 0;
                $next.prevAll().each(function () {
                    position += $(this).width();
                });
                if ($next.index() == this._banner.items.length - 1) {
                    this._nextElement.addClass("hidden");
                }
                $pole.removeClass("pole-position");
                $next.addClass("pole-position");
                this._banner.inner.css("left", -position);
            };
            Carousel.prototype.previousClicked = function () {
                var $pole = this._banner.items.filter(".pole-position");
                var $prev = $pole.prev();
                if ($pole.index() < this._banner.items.length) {
                    this._nextElement.removeClass("hidden");
                }
                if ($prev.length == 0) {
                    return;
                }
                var position = 0;
                $prev.prevAll().each(function () {
                    position += $(this).width();
                });
                if ($prev.index() == 0) {
                    this._prevElement.addClass("hidden");
                }
                $pole.removeClass("pole-position");
                $prev.addClass("pole-position");
                this._banner.inner.css("left", -position);
            };
            return Carousel;
        }(apollyon.BannerBase));
        banners.Carousel = Carousel;
    })(banners = apollyon.banners || (apollyon.banners = {}));
})(apollyon || (apollyon = {}));
