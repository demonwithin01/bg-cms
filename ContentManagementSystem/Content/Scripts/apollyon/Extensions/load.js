var apollyon;
(function (apollyon) {
    $.fn.loadHTML = function (ajaxOptions) {
        var _this = this;
        /**
         * Sets the html on the element(s).
         * @param data The data that was returned from the server.
         */
        function setHtml(data) {
            if (typeof (data) === "string") {
                _this.html(data);
            }
            else if (data.success) {
                _this.html(data.html);
            }
            else {
                console.error("The data could not be loaded/displayed.");
            }
        }
        if (ajaxOptions.complete) // If complete already defined, extend it to turn off the loading.
         {
            var complete = ajaxOptions.complete;
            ajaxOptions.complete = function () {
                complete.call(this, arguments);
                _this.loading("off");
            };
        }
        else // Otherwise create one so that the loading is turned off.
         {
            ajaxOptions.complete = function () {
                _this.loading("off");
            };
        }
        if (ajaxOptions.success) // If success is already defined, extend it to apply the html.
         {
            var success = ajaxOptions.success;
            ajaxOptions.success = function (data) {
                setHtml(data);
                success.call(this, arguments);
            };
        }
        else /// Otherwise create one so that the html can automatically be applied.
         {
            ajaxOptions.success = function (data) {
                setHtml(data);
            };
        }
        _this.loading();
        return $.ajax(ajaxOptions); // Return the ajax request object so that this method can be used like a normal $.ajax call.
    };
})(apollyon || (apollyon = {}));
//# sourceMappingURL=load.js.map