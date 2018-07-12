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
        var Carousel = /** @class */ (function (_super) {
            __extends(Carousel, _super);
            function Carousel(banner) {
                var _this = _super.call(this) || this;
                _this._banner = banner;
                _this._banner.items.each(function (index) {
                    $(this).css("left", 100 * index + "%");
                });
                _this._prevElement = _this.createNavElement("left").appendTo(_this._banner.element).addClass("hidden");
                _this._nextElement = _this.createNavElement("right").appendTo(_this._banner.element);
                _this._prevElement.on("click", $.proxy(_this.previousClicked, _this));
                _this._nextElement.on("click", $.proxy(_this.nextClicked, _this));
                return _this;
            }
            /**
             * Removes the generated elements and resets the css positions.
             */
            Carousel.prototype.unload = function () {
                this._banner.items.each(function (index) {
                    $(this).css("left", "0%");
                });
                this._prevElement.remove();
                this._nextElement.remove();
            };
            /**
             * Handles when the screen dimensions change. At the moment this does nothing.
             */
            Carousel.prototype.dimensionsChanged = function () {
            };
            /**
             * Creates the element that the user can use to go forwards or backwards with the carousel.
             */
            Carousel.prototype.createNavElement = function (direction) {
                return $("<div class=\"carousel-" + direction + "\"><i class=\"icon fa fa-chevron-" + direction + "\"></i></div>");
            };
            /**
             * Tells the carousel to scroll to the next slide and reset the interval.
             */
            Carousel.prototype.nextClicked = function () {
                this.goToNext();
                this._banner.resetInterval();
            };
            /**
             * Tells the carousel to scroll back to the previous slide and reset the interval.
             */
            Carousel.prototype.previousClicked = function () {
                this.goToPrev();
                this._banner.resetInterval();
            };
            /**
             * Tells the carousel to scroll to the next slide.
             */
            Carousel.prototype.goToNext = function () {
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
            /**
             * Tells the carousel to scroll back to the previous slide.
             */
            Carousel.prototype.goToPrev = function () {
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
            /**
             * Tells the carousel to scroll back to the start.
             */
            Carousel.prototype.goToStart = function () {
                var $pole = this._banner.items.filter(".pole-position");
                var $next = this._banner.items.first();
                if (this._banner.items.length > 1) {
                    this._nextElement.removeClass("hidden");
                }
                this._prevElement.addClass("hidden");
                $pole.removeClass("pole-position");
                $next.addClass("pole-position");
                this._banner.inner.css("left", 0);
            };
            Carousel.prototype.intervalExpired = function () {
                var $pole = this._banner.items.filter(".pole-position");
                var $next = $pole.next();
                if ($next.length == 0) {
                    this.goToStart();
                    return;
                }
                this.goToNext();
            };
            return Carousel;
        }(apollyon.BannerBase));
        banners.Carousel = Carousel;
    })(banners = apollyon.banners || (apollyon.banners = {}));
})(apollyon || (apollyon = {}));
//# sourceMappingURL=banner.carousel.js.map