var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var Site;
(function (Site) {
    var Contact = (function (_super) {
        __extends(Contact, _super);
        function Contact() {
            _super.apply(this, arguments);
        }
        Contact.prototype.init = function () {
            console.log("initialised Contact");
        };
        return Contact;
    }(Site.PageSection));
    Site.Contact = Contact;
})(Site || (Site = {}));
//# sourceMappingURL=site.contact.js.map