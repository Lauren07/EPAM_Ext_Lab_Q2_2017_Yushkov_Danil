var unitPrice;
var discount;
var quantity;

$('#btnAddProduct').click(function () {
    $('#formProduct').submit();
});

function productAdded(data) {
    changeTotalPrice(data);
    $("#resultAjax").removeAttr("id");

    $("#inputRow").before("<tr id='resultAjax'></tr>");
}

function productAdding() {
    unitPrice = parseFloat($("#UnitPrice").val());
    discount = parseFloat($("#Discount").val());
    quantity = parseInt($("#Quantity").val());
}

function changeTotalPrice(data) {
    var priceProduct = (unitPrice - ((unitPrice / 100) * discount)) * quantity;
    var curPrice = parseFloat($("#totalPrice").text().replace(",", ".")) + priceProduct;
    $("#totalPrice").text(curPrice.toFixed(2).replace(".",","));
}