var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var _site = _site || {};
var apollyon;
(function (apollyon) {
    var Contact = (function (_super) {
        __extends(Contact, _super);
        function Contact() {
            _super.apply(this, arguments);
        }
        Contact.prototype.init = function () {
            console.log("initialised Contact");
        };
        Contact.prototype.name = function () {
            return "ContactMe";
        };
        Contact.prototype.formResult = function (data) {
            if (data.success) {
                _site.showNotification(apollyon.notificationType.success, data.message);
            }
            else {
            }
        };
        return Contact;
    }(apollyon.PageSection));
    apollyon.Contact = Contact;
})(apollyon || (apollyon = {}));