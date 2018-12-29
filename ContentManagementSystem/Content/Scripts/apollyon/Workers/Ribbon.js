var apollyon;
(function (apollyon) {
    var Ribbon = (function () {
        function Ribbon() {
        }
        Ribbon.prototype.onWindowResize = function () {
            $(".ribbon-item > .b-grid").each(function () {
                var minHeight = 0;
                var $children = $(this).children();
                if ($children.length < 2) {
                    return;
                }
                $children.each(function () {
                    var el = $(this).children().get(0);
                    el.style.minHeight = "0";
                    var height = el.offsetHeight;
                    if (height > minHeight) {
                        minHeight = height;
                    }
                });
                var height = minHeight + "px";
                $children.each(function () {
                    var el = $(this).children().get(0);
                    el.style.minHeight = height;
                });
            });
        };
        Ribbon.prototype.onMainContentScroll = function () {
            console.log("scroll Background");
        };
        Ribbon.prototype.initialise = function () {
            this.onWindowResize();
        };
        return Ribbon;
    }());
    apollyon.Ribbon = Ribbon;
})(apollyon || (apollyon = {}));
//# sourceMappingURL=Ribbon.js.map