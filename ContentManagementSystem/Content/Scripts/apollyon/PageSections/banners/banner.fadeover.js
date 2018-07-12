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
        var FadeOut = /** @class */ (function (_super) {
            __extends(FadeOut, _super);
            function FadeOut(banner) {
                var _this = _super.call(this) || this;
                _this._banner = banner;
                _this._optionsContainer = $("<div class=\"banner-option-container\"></div>").appendTo(_this._banner.element);
                var that = _this;
                for (var i = 0; i < _this._banner.items.length; i++) {
                    _this._banner.items.eq(i).css({
                        "z-index": (i == 0 ? 2 : 1),
                        opacity: (i == 0 ? 1 : 0)
                    });
                    _this.createNavElement(i).appendTo(_this._optionsContainer).on("click", function () {
                        that.itemSelected($(this));
                    }).toggleClass("current", i == 0);
                }
                return _this;
            }
            FadeOut.prototype.unload = function () {
            };
            FadeOut.prototype.dimensionsChanged = function () {
            };
            FadeOut.prototype.intervalExpired = function () {
            };
            FadeOut.prototype.itemSelected = function (element) {
                var index = element.index();
                var $pole = this._banner.items.filter(".pole-position");
                var $next = this._banner.items.eq(index);
                if (index == $pole.index()) {
                    return;
                }
                $next.addClass("transit").get(0).offsetWidth;
                $next.css({
                    "z-index": 3,
                    opacity: 1
                }).on("transitionend", function () {
                    $pole.removeClass("pole-position").css({ "z-index": 1, opacity: 0 });
                    $next.removeClass("transit").off("transitionend").addClass("pole-position").css("z-index", 2);
                });
                this._optionsContainer.children().eq($pole.index()).removeClass("current");
                element.addClass("current");
            };
            FadeOut.prototype.createNavElement = function (index) {
                return $("<div class=\"banner-option\" data-index=\"" + index + "\"></div>");
            };
            return FadeOut;
        }(apollyon.BannerBase));
        banners.FadeOut = FadeOut;
    })(banners = apollyon.banners || (apollyon.banners = {}));
})(apollyon || (apollyon = {}));
//# sourceMappingURL=banner.fadeover.js.map