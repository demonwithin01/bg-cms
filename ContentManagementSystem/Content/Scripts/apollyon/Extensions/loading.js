var apollyon;
(function (apollyon) {
    $.fn.loading = function (options) {
        function Loading(element) {
            function empty() {
            }
            var defaults = {
                afterLoad: empty
            };
            var _this = this;
            var _options = $.extend({}, defaults, options);
            var _currentPosition = element.css("position");
            var _appliedCss = false;
            if (_currentPosition !== "relative" && _currentPosition !== "absolute") {
                if (_currentPosition === undefined)
                    _currentPosition = null;
                element.css("position", "relative");
                _appliedCss = true;
            }
            element.addClass("apn-loading");
            this.methods = {
                off: function () {
                    this.removeClass("apn-loading");
                    this.data("apn-loading", null);
                    if (_appliedCss) {
                        this.css("position", _currentPosition);
                    }
                    _options.afterLoad.call(this);
                }
            };
        }
        // For each JQuery element
        this.each(function () {
            if (typeof (options) === "string") {
                var loading = this.data("apn-loading");
                if (!loading) {
                    console.error("Loading object not found");
                    return;
                }
                if (typeof (loading.methods[options]) === "function") {
                    loading.methods[options].call(this);
                }
            }
            else {
                var loading = new Loading(this);
                this.data("apn-loading", loading);
            }
        });
        return this;
    };
})(apollyon || (apollyon = {}));
