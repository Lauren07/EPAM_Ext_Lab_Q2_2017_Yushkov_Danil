$("#btnSubmitForm").attr('disabled', true);

$(".form-control").change(function() {
    $("#btnSubmitForm").removeAttr('disabled');
})