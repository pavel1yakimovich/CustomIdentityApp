debugger;
$.validator.addMethod("checkage",
    function (value, element, param) {
        debugger;
        var YOB = value;
        var year = param;

        return (year - YOB >= 16);
    });

jQuery.validator.unobtrusive.adapters.add
    ("checkage", ["param"], function (options) { // rulename must be equal to method in validator
        debugger;
        options.rules["checkage"] = options.params.param; //parameters for validation
        options.messages["checkage"] = options.message; //error message
    });