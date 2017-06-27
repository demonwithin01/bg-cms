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
            }
            Carousel.prototype.unload = function () {
            };
            Carousel.prototype.dimensionsChanged = function () {
            };
            return Carousel;
        }(apollyon.BannerBase));
        banners.Carousel = Carousel;
    })(banners = apollyon.banners || (apollyon.banners = {}));
})(apollyon || (apollyon = {}));
