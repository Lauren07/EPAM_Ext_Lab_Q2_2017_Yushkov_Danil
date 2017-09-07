
$("#clipboard").click(function () {
    $("#link").select();
    document.execCommand('copy');
});