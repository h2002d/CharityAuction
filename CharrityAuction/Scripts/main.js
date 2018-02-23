$(document).ready(function () {
    $('.lot-preview').click(function () {
        window.location.href = '/home/item/' + $(this).prop('id');
    });

    $('.close-login').click(function () {
        $("#bidLogin").hide();
    });
    $("#txtBid").keydown(function (e) {

        // Allow: backspace, delete, tab, escape, enter and .
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            // Allow: Ctrl/cmd+A
            (e.keyCode == 65 && (e.ctrlKey === true || e.metaKey === true)) ||
            // Allow: Ctrl/cmd+C
            (e.keyCode == 67 && (e.ctrlKey === true || e.metaKey === true)) ||
            // Allow: Ctrl/cmd+X
            (e.keyCode == 88 && (e.ctrlKey === true || e.metaKey === true)) ||
            // Allow: home, end, left, right
            (e.keyCode >= 35 && e.keyCode <= 39)) {
            // let it happen, don't do anything
            return;
        }
        // Ensure that it is a number and stop the keypress
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
            e.preventDefault();
        }
    });
    $("#txtBid").change(function () {
        var min = parseInt($(this).attr('min'));
        if ($(this).val() < min) {
            $(this).val(min);
        }
    });
});
function orderBy(id) {
    var orderId = $('#sort-select').find(":selected").val();
    $('#items').load('/Home/CategoryPartial?id=' + id + '&sortId=' + orderId);
}
