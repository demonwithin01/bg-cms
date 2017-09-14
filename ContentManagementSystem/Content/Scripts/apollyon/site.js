// // <reference path="./jquery.extensions.js" />
var apollyon;
(function (apollyon) {
    var Site = (function () {
        function Site() {
            this._plugins = {};
            this._isInitialised = false;
            this._isInitialised = false;
            this._pageSections = new Array();
            this._imageBrowser = new apollyon.ImageBrowser();
            $("#social").jsSocials({
                shares: ["facebook"] //, "twitter", "googleplus", "linkedin", "pinterest", "stumbleupon", "whatsapp"]
            });
            this.attachEventHandlers();
            $(window).resize();
            setTimeout(function () {
                $("#body").addClass("on");
            }, 600);
            if (theme) {
                theme.initialise.call(this);
            }
            this.raiseEvent("onPageInitialise");
            for (var i = 0; i < this._pageSections.length; i++) {
                this._pageSections[i].init();
            }
            this._isInitialised = true;
        }
        Object.defineProperty(Site.prototype, "imageBrowser", {
            get: function () {
                return this._imageBrowser;
            },
            enumerable: true,
            configurable: true
        });
        Site.prototype.initialise = function () {
        };
        Site.prototype.addPlugin = function (name, plugin) {
            if (this._plugins[name] != undefined) {
                console.error("Error: Plugin \"" + name + "\" already exists");
                return;
            }
            this._plugins[name] = new plugin(this);
            this._plugins[name].initialise();
        };
        Site.prototype.removePlugin = function (name) {
            var plugins = {};
            for (var n in this._plugins) {
                if (n != name) {
                    plugins[n] = this._plugins[n];
                }
            }
            this._plugins = plugins;
        };
        Site.prototype.initialisePageSection = function (section) {
            this._pageSections.push(section);
            if (this._isInitialised) {
                section.init();
            }
        };
        Site.prototype.pageSection = function (sectionName) {
            for (var i = 0; i < this._pageSections.length; i++) {
                if (this._pageSections[i].name() == sectionName) {
                    return this._pageSections[i];
                }
            }
            return null;
        };
        /**
         * Shows a notification on the screen.
         * @param {notificationType} nType The notification type.
         * @message {string} message The message to display.
         * @time {bool?|number?} time If true, the message is displayed until user interaction. If a number, the notification will be displayed for a set period of time.
         */
        Site.prototype.showNotification = function (nType, message, time) {
            var type;
            switch (nType) {
                case apollyon.notificationType.success:
                    type = "success";
                    break;
                case apollyon.notificationType.error:
                    type = "error";
                    break;
                default:
                    type = "warning";
                    break;
            }
            var $notification = $("<div class=\"notification notification-" + type + "\"><div><p>" + message + "</p><span class=\"fa fa-remove\" onclick=\"_site.removeNotification( this );\"></span></div></div>");
            var removing = $(".notification:not(.show)");
            if (removing.length > 0) {
                var height = removing.outerHeight() + 15;
                $notification.addClass("shift-up").css("transform", "translateY(-" + height + "px)");
            }
            if (time !== true) {
                if (typeof (time) !== "number") {
                    time = 5000;
                }
                $notification.data("notification-timeout", setTimeout(function () {
                    _site.removeNotification($notification);
                }, time + 300));
                $notification.children().prepend("<span class=\"time\" style=\"transition: width " + time + "ms linear 0.3s;\"></span>");
            }
            $("#notifications").appendThen($notification, function () {
                $notification.addClass("show");
                $notification.find(".time").css("width", "100%");
            });
        };
        /**
         * Removes the notification from the page.
         * @param {jQuery} element The notification element or one of its descendents.
         */
        Site.prototype.removeNotification = function (element) {
            var $notification = $(element).closest(".notification").removeClass("show");
            $notification.removeData("notification-timeout");
            var height = $notification.outerHeight() + 15;
            $notification.nextAll().each(function () {
                $(this).addClass("shift-up").css("transform", "translateY(-" + height + "px)");
            });
            setTimeout(function () {
                $notification.nextAll().each(function () {
                    $(this).removeClass("shift-up").css("transform", "");
                });
                $notification.remove();
            }, 300);
        };
        Site.prototype.attachEventHandlers = function () {
            $(window).on("resize", $.proxy(this.handleResize, this));
            $(".menu-link").on("click", $.proxy(this.handleMenuLinkClick, this));
            if (theme) {
                $(theme.mainContentSelector).on("scroll", $.proxy(this.handleScroll, this));
            }
        };
        Site.prototype.handleResize = function () {
            var dimensions = { width: window.innerWidth, height: window.innerHeight };
            this.raiseEvent("onWindowResize", dimensions);
            for (var i = 0; i < this._pageSections.length; i++) {
                try {
                    this._pageSections[i].onResize(dimensions);
                }
                catch (e) {
                    console.error(e);
                }
            }
        };
        Site.prototype.handleMenuLinkClick = function () {
            var $parent = $(this).parent();
            $parent.toggleClass("open");
            if ($parent.hasClass("open") == false) {
                $parent.addClass("changing");
                setTimeout(function () {
                    $parent.removeClass("changing");
                }, 300);
            }
        };
        Site.prototype.handleScroll = function (e) {
            var pos = { top: e.target.scrollTop, left: e.target.scrollLeft };
            if (e.target.scrollTop != undefined) {
                pos = { top: e.target.scrollTop, left: e.target.scrollLeft };
            }
            else if (e.target.scrollingElement != $("body").get(0)) {
                return;
            }
            else {
                pos = { top: e.target.scrollingElement.scrollTop, left: e.target.scrollingElement.scrollLeft };
            }
            $("#social").css("top", (pos.top + 60) + "px");
            this.raiseEvent("onMainContentScroll", pos);
        };
        Site.prototype.raiseEvent = function (event, args) {
            /// <summary>Raises the specified event</summary>
            /// <param name="event">The name of the event to be raised</param>
            /// <param name="args">The arguments to be raised with the event</param>
            for (var plugin in this._plugins) {
                var func = this._plugins[plugin][event];
                if (func == undefined || typeof (func) !== "function") {
                    continue;
                }
                try {
                    func.call(this._plugins[plugin], args, this);
                }
                catch (e) {
                    console.error(e);
                }
            }
        };
        return Site;
    }());
    apollyon.Site = Site;
})(apollyon || (apollyon = {}));
var theme;
//# sourceMappingURL=site.js.map