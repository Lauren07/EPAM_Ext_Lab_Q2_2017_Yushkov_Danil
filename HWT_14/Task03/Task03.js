function buttonSelectorHandler(element, boxFrom, boxTo) {
    var countChangedElements = 0;
    $("#" + boxFrom + " option" + (element.value === '>' || element.value === '<' ? ":selected" : "")).each(function() {
        $("#" + boxTo).append(new Option(this.text, this.value));
        this.remove();
        countChangedElements++;
    });
    if (countChangedElements===0)
        alert("Нет доступных элементов для перемещения!");
}