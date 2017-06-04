var apollyon;
(function (apollyon) {
    var TemplateEditor = (function () {
        function TemplateEditor(options) {
            this._templateSelector = options.templateSelector;
            this._currentCount = options.count;
            this._templateString = options.templateString || "template";
            this._fieldString = options.fieldString;
        }
        TemplateEditor.prototype.createItem = function () {
            var template = $(this._templateSelector).children().clone();
            var idRegex = new RegExp(this._templateString + "_", "g");
            var nameRegex = new RegExp(this._templateString + "\.", "g");
            template.find("input").each(function () {
                var element = $(this);
                var id = element.attr("id");
                var name = element.attr("name");
                element.attr({ id: id.replace(idRegex, this._fieldString + "_" + this._currentCount + "__"), name: name.replace(nameRegex, this._fieldString + "[" + this._currentCount + "].") });
            });
            template.attr("data-index", this._currentCount);
            return template;
        };
        TemplateEditor.prototype.updateIndicesFor = function (items) {
            var idRegex = new RegExp(this._fieldString + "_\d*_", "g");
            var nameRegex = new RegExp(this._fieldString + "\[\d*\]", "g");
            items.each(function (idx) {
                var item = $(this);
                item.find("input").each(function () {
                    var input = $(this);
                    var id = input.attr("id");
                    var name = input.attr("name");
                    id = id.replace(idRegex, this._fieldString + "_" + idx + "_");
                    name = name.replace(nameRegex, this._fieldString + "[" + idx + "]");
                    input.attr({ id: id, name: name });
                });
                item.attr("data-index", idx);
            });
        };
        return TemplateEditor;
    }());
    apollyon.TemplateEditor = TemplateEditor;
})(apollyon || (apollyon = {}));
