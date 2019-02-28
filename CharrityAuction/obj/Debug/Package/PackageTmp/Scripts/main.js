$(document).ready(function () {
    //var scroll_pos = 0;
    //        $(window).scroll(function () {
    //            scroll_pos = $(this).scrollTop();
    try {


        var distance = $('.vertical-menu').offset();
        var topDistance = distance.top;

    } catch (err) {

        // обработка ошибки

    }
 
    //            if ((topDistance + 100) < scroll_pos) {
    //                $(".vertical-menu").addClass("fixed-category");
    //            }
    //            else {
    //                $(".vertical-menu").removeClass("fixed-category");
    //            }
                //        });
                $('#vertical-menu').attr('data-offset-top', topDistance);

    $('#searchArea').bind("enterKey", function (e) {
        window.location = "/home/Search?query=" + $(this).val().replace(/</g, "&lt;").replace(/>/g, "&gt;");;
    });
    $('#searchArea').keyup(function (e) {
        if (e.keyCode == 13) {
            $(this).trigger("enterKey");
        }
    });
    $('#facebookicon').on('mouseover', function () {
        $(this).attr('src', '/images/facebookIcon.png');
    });
    $('#facebookicon').on('mouseout', function () {
        $(this).attr('src', '/images/facebookIconInactive.png');
    });
    $('#vkIcon').on('mouseover', function () {
        $(this).attr('src', '/images/vkIcon.png');
    });
    $('#vkIcon').on('mouseout', function () {
        $(this).attr('src', '/images/vkIconInactive.png');
    });
    $('#instagramIcon').on('mouseover', function () {
        $(this).attr('src', '/images/instagramIcon.png');
    });
    $('#instagramIcon').on('mouseout', function () {
        $(this).attr('src', '/images/instagramIconInactive.png');
    });
    // Get the modal
  
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
    
   
   

   
    //$("#txtBid").keydown(function (e) {

    //    // Allow: backspace, delete, tab, escape, enter and .
    //    if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
    //        // Allow: Ctrl/cmd+A
    //        (e.keyCode == 65 && (e.ctrlKey === true || e.metaKey === true)) ||
    //        // Allow: Ctrl/cmd+C
    //        (e.keyCode == 67 && (e.ctrlKey === true || e.metaKey === true)) ||
    //        // Allow: Ctrl/cmd+X
    //        (e.keyCode == 88 && (e.ctrlKey === true || e.metaKey === true)) ||
    //        // Allow: home, end, left, right
    //        (e.keyCode >= 35 && e.keyCode <= 39)) {
    //        // let it happen, don't do anything
    //        return;
    //    }
    //    // Ensure that it is a number and stop the keypress
    //    if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
    //        e.preventDefault();
    //    }
    //    var min = parseInt($(this).attr('min'));
    //    if ($(this).val() < min) {
    //        $(this).val(min);
    //    }
    //});
   
});
$(document).on('click', '#searchButton', function () {
    $('#searchArea').trigger("enterKey");
});
$(document).on('click', '.lot-preview', function () {
        window.location.href = '/home/item/' + $(this).prop('id');
});

$(document).on("mouseover", '.arrow-right', function (event) {
    scrolling = true;
    scrollContent("right");
});
$(document).on("mouseout", '.arrow-right', function (event) {
    scrolling = false;
});

$(document).on("mouseover", '.arrow-left', function (event) {
    scrolling = true;
    scrollContent("left");
});
$(document).on("mouseout", '.arrow-left', function (event) {
    scrolling = false;
});

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
$(document).on('click', '.lot-partners-div', function () {
    window.location.href = '/home/partneritems/' + $(this).prop('id');
});
$(document).on('click', '.close-login',function () {
    $("#bidLogin").hide();
    $("#cover").css("display", "none");

});
$(document).on('change','#terms-checkbox',function () {
    if ($(this).is(':checked')) {
        $(".registration-btn").prop("type", "submit");
        $(".registration-btn").removeClass("disabled");
    }
    else {
        $(".registration-btn").prop("type", "button");
        $(".registration-btn").addClass("disabled");

    }
});
$(document).on('click', '.myImg', function () {
    var modal = document.getElementById('myModal');
    $('#imageIndex').val($(this).attr('id'));
    // Get the image and insert it inside the modal - use its "alt" text as a caption
    var modalImg = document.getElementById("img01");
    var captionText = document.getElementById("caption");
    modal.style.display = "block";
    modalImg.src = this.src;
    captionText.innerHTML = this.alt;
});
$(document).on('click', '.close', function () {
    var modal = document.getElementById('myModal');
        modal.style.display = "none";
});

//window.onscroll = function () { myFunction() };

//var header = document.getElementById("vertical-menu");
//var sticky = header.offsetTop;
//var scroll_pos = $(this).scrollTop();

//var topDistance = header.offset().top;

//function myFunction() {
  
//    if (sticky < scroll_pos) {
//        header.classList.add("sticky");
//    } else {
//        header.classList.remove("sticky");
//    }
//}
function orderBy(id) {
    var orderId = $('#sort-select').find(":selected").val();
    $('#items').load('/Home/CategoryPartial?id=' + id + '&sortId=' + orderId);
}
function orderIndexBy() {
    var orderId = $('#sort-select').find(":selected").val();
    $('#items').load('/Home/IndexPartial?sortId=' + orderId);
}

function makePayment(id) {
    var type = $('input[name=paymentType]:checked').val()

    window.location.href = '/Payment/MakePayment?id='+id+'&type='+type;
}
function OnSuccess(response) {
    if (response == 11) {
        $('.nickname-validator').text('Nickname already exists');
    } else {
        location.reload();
    }
}
function OnFailure(response) {
    alert("Error occured.");
}
// Get the <span> element that closes the modal
