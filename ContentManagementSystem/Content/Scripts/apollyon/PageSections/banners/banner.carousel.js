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
    var banners;
    (function (banners) {
        var Carousel = (function (_super) {
            __extends(Carousel, _super);
            function Carousel(banner) {
                var _this = _super.call(this) || this;
                _this._banner = banner;
                _this._prevElement = _this.createNavElement("left").appendTo(_this._banner.element).addClass("hidden");
                _this._nextElement = _this.createNavElement("right").appendTo(_this._banner.element);
                _this._prevElement.on("click", $.proxy(_this.previousClicked, _this));
                _this._nextElement.on("click", $.proxy(_this.nextClicked, _this));
                return _this;
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
//# sourceMappingURL=banner.carousel.js.map