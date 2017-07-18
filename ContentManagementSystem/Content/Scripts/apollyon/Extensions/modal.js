var apollyon;
(function (apollyon) {
    $.fn.bgmodal = function (options) {
        function Modal(element) {
            function empty() {
            }
            var defaults = {
                theme: "",
                removeOnClose: false,
                url: "",
                urlMethod: "GET",
                urlData: {},
                beforeShow: empty,
                afterShow: empty,
                beforeClose: empty,
                afterClose: empty,
            };
            var _this = this;
            var _options = $.extend({}, defaults, options);
            $("body").append("<div class=\"bg-modal-backdrop\"></div>").append(element);
            element.addClass("bg-modal").addClass(_options.theme);
            this.methods = {
                close: function () {
                    _options.beforeClose.call(this);
                    $(this).hide().prev().hide();
                    _options.afterClose.call(this);
                    if (_options.removeOnClose) {
                        $(this).prev().remove();
                        $(this).remove();
                    }
                },
                open: function () {
                    var $this = $(this);
                    function open() {
                        _options.beforeShow.call(this);
                        $this.show().css({
                            width: $this.children().outerWidth(),
                            height: $this.children().outerHeight()
                        }).prev().show();
                        _options.afterShow.call(this);
                    }
                    if (_options.url && _options.url.length > 0) {
                        var ajaxData = _options.urlData;
                        if (typeof (ajaxData) === "function") {
                            ajaxData = ajaxData.call(this);
                        }
                        $.ajax({
                            url: _options.url,
                            type: _options.urlType,
                            data: ajaxData,
                            success: function (data) {
                                $this.append(data);
                                open.call($this.get(0));
                            }
                        });
                    }
                    else {
                        open.call(this);
                    }
                }
            };
            if (options.autoOpen !== false) {
                _this.methods.open();
            }
        }
        if (typeof (options) === "string") {
            var modal = this.data("apn-modal");
            if (!modal) {
                return;
            }
            if (typeof (modal.methods[options]) === "function") {
                modal.methods[options].call(this);
            }
        }
        else {
            var modal = new Modal(this);
            this.data("apn-modal", modal);
        }
        return this;
    };
})(apollyon || (apollyon = {}));
