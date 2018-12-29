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
    var BannerBase = (function () {
        function BannerBase() {
        }
        return BannerBase;
    }());
    apollyon.BannerBase = BannerBase;
    var Banner = (function (_super) {
        __extends(Banner, _super);
        function Banner(element, options) {
            var _this = _super.call(this) || this;
            _this._banner = null;
            console.log(options);
            _this._element = element;
            _this._inner = element.find(".carousel-inner");
            _this._items = element.find(".carousel-item");
            _this.width = options.width;
            _this.height = options.height;
            _this._timer = options.timer || 0;
            _this._items.first().addClass("pole-position");
            _this.bannerType = options.bannerType;
            _this._element.data("ap-banner", _this);
            return _this;
        }
        Banner.prototype.init = function () {
        };
        Banner.prototype.unload = function () {
            clearInterval(this._interval);
            this._banner.unload();
        };
        /**
         * Clears the current interval and restarts it if there is more than 1 item in the carousel.
         */
        Banner.prototype.resetInterval = function () {
            clearInterval(this._interval);
            if (this.items.length > 1 && this._timer > 0) {
                this._interval = setInterval($.proxy(this._banner.intervalExpired, this._banner), this._timer * 1000);
            }
        };
        Banner.prototype.name = function () {
            return "Banner";
        };
        Object.defineProperty(Banner.prototype, "height", {
            get: function () {
                return this._height;
            },
            set: function (value) {
                this._height = value;
                this._element.height(value);
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(Banner.prototype, "width", {
            get: function () {
                return this._width;
            },
            set: function (value) {
                this._width = value;
                this._element.width(value);
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(Banner.prototype, "element", {
            get: function () {
                return this._element;
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(Banner.prototype, "inner", {
            get: function () {
                return this._inner;
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(Banner.prototype, "items", {
            get: function () {
                return this._items;
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(Banner.prototype, "bannerType", {
            get: function () {
                return this._bannerType;
            },
            set: function (value) {
                if (this._bannerType == value) {
                    return;
                }
                if (this._banner != null) {
                    this._banner.unload();
                }
                this._bannerType = value;
                switch (this._bannerType) {
                    case apollyon.BannerType.Carousel:
                        this._banner = new apollyon.banners.Carousel(this);
                        break;
                    case apollyon.BannerType.FadeOver:
                        this._banner = new apollyon.banners.FadeOut(this);
                        break;
                }
                this.resetInterval();
            },
            enumerable: true,
            configurable: true
        });
        return Banner;
    }(apollyon.PageSection));
    apollyon.Banner = Banner;
})(apollyon || (apollyon = {}));
//# sourceMappingURL=banner.js.map