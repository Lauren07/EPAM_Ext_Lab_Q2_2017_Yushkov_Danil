$(function () {
    $.ajaxSetup({ cache: false });
    $(".modal-btn").click(function (e) {
        e.preventDefault();
        $.get(this.href,
            function (data) {
                $('#dialogContent').html(data);
                $('#modDialog').modal('show');
            });
    });
});

function HandlerFailLogin(data) {
    if (data.result === 'Success')
        window.location = data.url;
    else
        $("#errorLogIn").show();
}