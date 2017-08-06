var apollyon;
(function (apollyon) {
    var RibbonAdmin = (function () {
        function RibbonAdmin(options) {
            this._ribbonCount = options.ribbonCount;
            var that = this;
            $("#ribbon-items > .ribbon-item").each(function () {
                that.attachEventsTo($(this));
            });
        }
        /**
         * Creates a clone of the ribbon and appends it to the page.
         */
        RibbonAdmin.prototype.createRibbon = function () {
            var $clone = $("#ribbon-item-template").children().clone();
            var ribbonCount = this._ribbonCount;
            $clone.attr("data-index", this._ribbonCount);
            $clone.find("input, select, textarea").each(function () {
                var $this = $(this);
                var name = $this.attr("name");
                var id = $this.attr("id");
                if (name) {
                    $this.attr("name", name.replace(/\[+[a-z]+\]/g, "[" + ribbonCount + "]"));
                }
                if (id) {
                    $this.attr("id", id.replace(/_+[a-z]+_/g, "_" + ribbonCount + "_"));
                }
                $this.removeAttr("disabled");
            });
            $clone.find("label").each(function () {
                var $this = $(this);
                $this.attr("for", $this.attr("for").replace(/_+[a-z]+_/g, "_" + ribbonCount + "_"));
            });
            this.attachEventsTo($clone);
            this._ribbonCount += 1;
            $("#ribbon-items").append($clone);
        };
        /**
         * Removes a ribbon from the page and updates the names/ids of all input elements.
         * @param ribbon The ribbon element to be removed.
         */
        RibbonAdmin.prototype.removeRibbon = function (ribbon) {
            var nextRibbons = ribbon.nextAll(".ribbon-item");
            var currentIndex = ribbon.index();
            nextRibbons.each(function () {
                var $ribbon = $(this);
                $ribbon.find("input, select, textarea").each(function () {
                    var $this = $(this);
                    var name = $this.attr("name");
                    var id = $this.attr("id");
                    if (name) {
                        $this.attr("name", name.replace(/Items\[\d+\]/g, "Items[" + currentIndex + "]"));
                    }
                    if (id) {
                        $this.attr("id", id.replace(/Items_\d+_/g, "Items_" + currentIndex + "_"));
                    }
                    $this.removeAttr("disabled");
                });
                $ribbon.find("label").each(function () {
                    var $this = $(this);
                    $this.attr("for", $this.attr("for").replace(/Items_\d+_/g, "Items_" + currentIndex + "_"));
                });
                currentIndex += 1;
            });
            this._ribbonCount -= 1;
            ribbon.remove();
        };
        /**
         * Attaches the events required to the ribbon row instance.
         * @param ribbon The ribbon row to attach the events to.
         */
        RibbonAdmin.prototype.attachEventsTo = function (ribbon) {
            var that = this;
            ribbon.find("select.content-type").selectmenu({
                change: function () {
                }
            });
            ribbon.find("select.column-layout").selectmenu({
                change: function () {
                    that.configureForColumns(ribbon, $(this).val());
                }
            });
            ribbon.find("select.padding-option").selectmenu({
                change: function () {
                    ribbon.toggleClass("no-padding", $(this).val() == "true");
                }
            });
            ribbon.find("select.link-option").selectmenu();
            ribbon.find("select").each(function () {
                $(this).next().css("width", "auto");
            });
            ribbon.find(".ribbon-item-height").on("click", function () {
                ribbon.find(".ribbon-item-tools > input").val("auto");
                ribbon.css({ height: "auto" });
                $(this).children("span").text("auto");
            });
            ribbon.find("[type=\"color\"]").spectrum({
                color: "transparent",
                showInput: true,
                allowEmpty: true,
                showPalette: true,
                showInitial: true,
                showAlpha: true,
                palette: [
                    ["black", "white", "blue", "red"],
                    ["green", "orange"]
                ],
                move: function (color) {
                    ribbon.css("background-color", that.convertColor(color));
                },
                hide: function (color) {
                    var value = that.convertColor(color);
                    ribbon.css("background-color", value);
                    ribbon.find("[type=\"color\"]").prev("input").val(value);
                }
            });
            ribbon.resizable({
                handles: "s",
                stop: function () {
                    var height = parseInt(ribbon.css("height").replace("px", ""));
                    ribbon.find(".ribbon-item-tools > input").val(height);
                    ribbon.find(".ribbon-item-height > span").text(height + "px");
                }
            });
            ribbon.children().on("mouseout", function (e) {
                e.stopPropagation();
            });
            ribbon.on("mouseout", function (e) {
                var $related = $(e.relatedTarget);
                if (!$related.is(ribbon) && $related.closest(".ribbon-item").is(ribbon)) {
                    return;
                }
                ribbon.find("select").selectmenu("close");
            });
        };
        /**
         * Redistributes the columns based off the selection for the number of columns.
         * @param $ribbon The ribbon to redistribute the columns for.
         * @param value The number of columns to change to.
         */
        RibbonAdmin.prototype.configureForColumns = function ($ribbon, value) {
            var html = new Array();
            var columnWidths = new Array();
            var $grid = $ribbon.children(".b-grid");
            $grid.children(".editable").each(function () {
                html.push($(this).find(".ribbon-editable-content").html());
            });
            $grid.empty();
            switch (value) {
                case "1":
                    columnWidths.push("1-1");
                    break;
                case "2":
                    columnWidths.push("1-2");
                    columnWidths.push("1-2");
                    break;
                case "3":
                    columnWidths.push("1-3");
                    columnWidths.push("1-3");
                    columnWidths.push("1-3");
                    break;
            }
            var index = $ribbon.attr("data-index");
            for (var i = 0; i < columnWidths.length; i++) {
                var $div = $("<div class=\"editable b-width-" + columnWidths[i] + "\"></div>");
                var $contentWrapper = $("<div class\"open-editable-content\"></div>");
                var $content = $("<div class\"ribbon-editable-content\"></div>");
                var $input = $("#ribbon-column-input-template").clone();
                $contentWrapper.append($content);
                if (i < html.length) {
                    // Fix
                    $content.html(html[i]);
                }
                $div.append($contentWrapper).append($input.children());
                $grid.append($div);
                $div.find("select.content-type").selectmenu({
                    change: function () {
                    }
                });
            }
        };
        /**
         * Convers the color object to a CSS equivalent.
         * @param color The color object as provided by spectrum.
         */
        RibbonAdmin.prototype.convertColor = function (color) {
            if (color) {
                var value = color.toRgb();
                return "rgba(" + value.r + "," + value.g + "," + value.b + "," + value.a + ")";
            }
            return "rgba(0, 0, 0, 0)";
        };
        return RibbonAdmin;
    }());
    apollyon.RibbonAdmin = RibbonAdmin;
})(apollyon || (apollyon = {}));
