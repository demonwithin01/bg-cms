var apollyon;
(function (apollyon) {
    var ImageBrowser = (function () {
        function ImageBrowser() {
        }
        /**
         * Opens a new browser window for selecting images from.
         * @param {ImageBrowserCallback} callback The method to call when the images have been selected and submitted.
         */
        ImageBrowser.prototype.openBrowser = function (callback) {
            this._callback = callback;
            this._openWindow = window.open(window.location.origin + "/admin/imagebrowser/select", "image-browser", "height=640,width=1120");
            this._openWindow.focus();
        };
        /**
         * Sends the urls of the selected images back to the callback method.
         * @param {Array<string>} urls The urls of the selected images.
         */
        ImageBrowser.prototype.sendImages = function (urls) {
            this._callback(urls, urls.length);
            this._openWindow.close();
            this._openWindow = undefined;
            this._callback = undefined;
        };
        return ImageBrowser;
    }());
    apollyon.ImageBrowser = ImageBrowser;
})(apollyon || (apollyon = {}));
//# sourceMappingURL=ImageBrowser.js.map