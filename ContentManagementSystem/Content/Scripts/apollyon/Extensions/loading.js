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
            element.addClass("apn-loading");
            this.methods = {
                off: function () {
                    this.removeClass("apn-loading");
                    this.data("apn-loading", null);
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
