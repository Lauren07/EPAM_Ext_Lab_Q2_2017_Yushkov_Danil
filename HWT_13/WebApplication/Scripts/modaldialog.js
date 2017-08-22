$(function () {
    $.ajaxSetup({ cache: false });
    $(".nameItem").click(function(e) {
        e.preventDefault();
        $.get(this.href,
            function(data) {
                $('#dialogContent').html(data);
                $('#modDialog').modal('show');
            });
    });
});

$(function () {
    $.ajaxSetup({ cache: false });
    $(".editBtn").click(function (e) {
        e.preventDefault();
        $.get(this.href,
            function (data) {
                $('#dialogContent').html(data);
                $('#modDialog').modal('show');
            });
    });
});

$(function () {
    $.ajaxSetup({ cache: false });
    $("#btnAddOrder").click(function (e) {
        e.preventDefault();
        $.get(this.href,
            function (data) {
                $('#dialogContent').html(data);
                $('#modDialog').modal('show');
            });
    });
});

