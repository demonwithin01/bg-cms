var apollyon;
(function (apollyon) {
    $.fn.bgmodal = function (options) {
        function Modal(element) {
            function empty() {
            }
            var defaults = {
                theme: '',
                beforeShow: empty,
                afterShow: empty,
                beforeClose: empty,
                afterClose: empty
            };
            var _this = this;
            var _options = $.extend({}, defaults, options);
            $('body').append('<div class="bg-modal-backdrop"></div>').append(element);
            element.addClass('bg-modal').addClass(_options.theme);
            this.methods = {
                close: function () {
                    _options.beforeClose.call(this);
                    $(this).hide().prev().hide();
                    _options.afterClose.call(this);
                },
                open: function () {
                    var $this = $(this);
                    _options.beforeShow.call(this);
                    $this.show().css({
                        width: $this.children().outerWidth(),
                        height: $this.children().outerHeight()
                    }).prev().show();
                    _options.afterShow.call(this);
                }
            };
            if (options.autoOpen !== false) {
                _this.methods.open();
            }
        }
        if (typeof (options) === 'string') {
            var modal = this.data('bg-modal');
            if (!modal) {
                return;
            }
            if (typeof (modal.methods[options]) === 'function') {
                modal.methods[options].call(this);
            }
        }
        else {
            this.data('bg-modal', new Modal(this));
        }
        return this;
    };
})(apollyon || (apollyon = {}));
//# sourceMappingURL=bg.modal.js.map