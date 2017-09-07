var indexSelected = $("select").val();
$(".info-role").hide();
$("#info-" + indexSelected).show();

$('select').on('change', function (e) {
    $(".info-role").hide();
    $("#info-" + this.value).show();
})