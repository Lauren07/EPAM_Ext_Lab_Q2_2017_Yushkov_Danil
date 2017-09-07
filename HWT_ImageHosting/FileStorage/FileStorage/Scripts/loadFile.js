
if ($("#IsPublic").prop("checked")) {
    $("#settingRoles").hide();
};

if ($("#Id").val()) {
    $("#fileBox").hide();
};


$("#IsPublic").change(function() {
    var speedAnim = 350;
    if (this.checked)
        $("#settingRoles").hide(speedAnim);
    else
        $("#settingRoles").show(speedAnim);
});

$("#Content").bind('change',
    function() {
        var errorMessage = "Размер файла не должен превышать 2мб";
        var errMessIsExisting = $("#valSizeFile").length > 0;
        var sizeIsValid = fileSizeIsValid(this.files);

        if (this.files.length < 1 && errMessIsExisting) {
            $("#valSizeFile").remove();
            return;
        }
        if (!sizeIsValid) {
            if (!errMessIsExisting)
                $("#Content").after("<span for='Content' class='text-danger' id='valSizeFile'>" +
                    errorMessage +
                    "<br/></span>");
            return;
        }
        if (sizeIsValid && errMessIsExisting)
            $("#valSizeFile").remove();
    });

function fileSizeIsValid(files) {
    var maxSizeFile = 2 * 1024 * 1024;
    if (files.length < 1)
        return true;
    return files[0].size <= maxSizeFile;
}

function accessSettingsIsValid() {
    return ($(".roleFlag:checked").length !== 0 || $("#IsPublic").prop("checked"));
}

$("input[type=checkbox]").change(function() {
    var errorMessage = "Некорректные настройки доступа.";
    
    if (accessSettingsIsValid()) {
        $("#valAccessSettings").remove();
    } else {
        $("#settingRoles").after("<span class='text-danger' id='valAccessSettings'>" +
            errorMessage + "<br/></span>");
    }
})

$('#loadForm').submit(function () {
    return $('#loadForm').valid() && fileSizeIsValid($("#Content")[0].files) && accessSettingsIsValid();
})