(function ($) {
    $.validator.addMethod("jqgreater", function (value, element, params) {
        var thisValue, otherValue;
        if (this.optional(element)) {
            return true;
        }
        thisValue = parseInt(value);
        otherValue = parseInt($(params).val());
        return thisValue > otherValue;
    });
    function getModelPrefix(fieldName) {
        return fieldName.substr(0, fieldName.lastIndexOf(".") + 1);
    }
    function appendModelPrefix(value, prefix) {
        if (value.indexOf("*.") === 0) {
            value = value.replace("*.", prefix);
        }
        return value;
    }
    $.validator.unobtrusive.adapters.add("greater", ["other"], function (options) {
        var prefix = getModelPrefix(options.element.name),
            other = options.params.other,
            fullOtherName = appendModelPrefix(other, prefix),
            element = $(options.form).find(":input[name=" + fullOtherName + "]")[0];

        options.rules["jqgreater"] = element; //element becomes "params" in callback
        if (options.message) {
            options.messages["jqgreater"] = options.message;
        }
    });
}(jQuery));