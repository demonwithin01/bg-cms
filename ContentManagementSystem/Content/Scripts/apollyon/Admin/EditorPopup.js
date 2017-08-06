var apollyon;
(function (apollyon) {
    var EditorPopup = (function () {
        function EditorPopup(elementId) {
            CKEDITOR.replace(elementId);
            this._ckEditor = CKEDITOR.instances[elementId];
            $("#cancelColumnContent").on("click", $.proxy(this.cancelModalChanges, this));
            $("#acceptColumnContent").on("click", $.proxy(this.acceptModalChanges, this));
            $("#columnPopup").bgmodal({
                autoOpen: false
            });
        }
        /**
         * Opens the CK Editor modal.
         * @param html The existing html to add to the editor.
         * @param callback Raised when the changes are accepted.
         */
        EditorPopup.prototype.openModal = function (html, callback) {
            this._ckEditor.setData(html);
            this._callback = callback;
            $("#columnPopup").bgmodal("open");
        };
        /**
         * Event handler for when the modal changes are accepted.
         */
        EditorPopup.prototype.acceptModalChanges = function () {
            this._callback.call(this, this._ckEditor.getData());
            this.cancelModalChanges();
        };
        /**
         * Event handler for when the modal changes are declined.
         */
        EditorPopup.prototype.cancelModalChanges = function () {
            this._callback = null;
            $("#columnPopup").bgmodal("close");
        };
        return EditorPopup;
    }());
    apollyon.EditorPopup = EditorPopup;
})(apollyon || (apollyon = {}));
