var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
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
            _super.call(this);
            this._banner = null;
            this._element = element;
            this._inner = element.find(".carousel-inner");
            this._items = element.find(".carousel-item");
            this._width = options.width;
            this._height = options.height;
            this._items.first().addClass("pole-position");
            this._items.each(function (index) {
                $(this).css("left", 100 * index + "%");
            });
            this.bannerType = options.bannerType;
        }
        Banner.prototype.init = function () {
            console.log("initialised Banner");
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
                }
            },
            enumerable: true,
            configurable: true
        });
        return Banner;
    }(apollyon.PageSection));
    apollyon.Banner = Banner;
})(apollyon || (apollyon = {}));
//# sourceMappingURL=banner.js.map