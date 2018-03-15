$(document).ready(function () {

    // Get the modal
    var modal = document.getElementById('myModal');

    // Get the image and insert it inside the modal - use its "alt" text as a caption
    var modalImg = document.getElementById("img01");
    var captionText = document.getElementById("caption");
    $('.myImg').click(function () {
        modal.style.display = "block";
        modalImg.src = this.src;
        captionText.innerHTML = this.alt;
    });
    $('.offer-pg').each(function () {
        var liItems = $(this);
        var Sum = 0;
        if (liItems.children('.portfolio-item').length >= 1) {
            $(this).children('.portfolio-item').each(function (i, e) {
                Sum += $(e).outerWidth(true);
            });
            $(this).width(Sum + 1);
        }
    });
    // Get the <span> element that closes the modal
    var span = document.getElementsByClassName("close")[0];

    // When the user clicks on <span> (x), close the modal
    span.onclick = function () {
        modal.style.display = "none";
    }
    var items = $(".portfolio-item");
    var scrollContainer = $(".offer-pg-cont");
    function scrollContent(direction) {
        var amount = (direction === "left" ? "-=5px" : "+=5px");
        scrollContainer.animate({
            scrollLeft: amount
        }, 1, function () {
            if (scrolling) {
                scrollContent(direction);
            }
        });
    }
    $('.arrow-right').bind("mouseover", function (event) {
        scrolling = true;
        scrollContent("right");
    }).bind("mouseout", function (event) {
        scrolling = false;
    });
    $('.arrow-left').bind("mouseover", function (event) {
        scrolling = true;
        scrollContent("left");
    }).bind("mouseout", function (event) {
        scrolling = false;
    });
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
function orderIndexBy() {
    var orderId = $('#sort-select').find(":selected").val();
    $('#items').load('/Home/IndexPartial?sortId=' + orderId);
}
