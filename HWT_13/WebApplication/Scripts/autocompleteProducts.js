var options = {
    url: function(phrase) {
    return "/Home/GetProducts";
    },

    getValue: function(element) {
        return element.ProductName;
    },

    ajaxSettings: {
        dataType: "json",
        method: "POST",
        data: {
            dataType: "json"
        }
    },

    list: {
        match: {
            enabled: true
        },
        onSelectItemEvent: function () {
            var selectedItemData = $("input[name='ProductName']").getSelectedItemData();

            $("input[name='UnitPrice']").val(selectedItemData.UnitPrice).trigger("change");
            $("#ProductID").val(selectedItemData.ProductID).trigger("change");
        }
    }

}

$("input[name='ProductName']").easyAutocomplete(options);