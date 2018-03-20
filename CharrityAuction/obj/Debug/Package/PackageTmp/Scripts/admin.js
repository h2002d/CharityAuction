function removeCategory(id) {
    $.ajax({
        type: "POST",
        url: "/Admin/DeleteCategory/"+id,
        success: function () {
            alert("Category Deleted.");
            location.reload();
        },
        error: function (data) {
            alert("Error! topic not added.");
        }
    });
}

function saveTopLot(index,lotId) {
    $.ajax({
        type: "POST",
        url: "/Admin/SaveTopLot/",
        data: { index: index, lotId: lotId },
        success: function (data) {
            alert(data);
        },
        error: function (data) {
            alert("Error! topic not added.");
        }
    });
}

function deleteCharity(id){
    $.ajax({
        type: "POST",
        url: "/Admin/DeleteCharity/" + id,
        success: function (data) {
            alert(data);
            location.reload();
        },
        error: function (data) {
            console.log(data);
        }
    });
}
function deletePartner(id) {
    $.ajax({
        type: "POST",
        url: "/Admin/DeletePartner/" + id,
        success: function (data) {
            alert(data);
            location.reload();
        },
        error: function (data) {
            console.log(data);
        }
    });
}
function removeNews(id) {
    $.ajax({
        type: "POST",
        url: "/Admin/DeleteNews/" + id,
        success: function (data) {
            alert(data);
            location.reload();
        },
        error: function (data) {
            console.log(data);
        }
    });
}

function deleteLot(id) {
    $.ajax({
        type: "POST",
        url: "/Admin/DeleteLot/" + id,
        success: function (data) {
            alert(data);
            location.reload();
        },
        error: function (data) {
            console.log(data);
        }
    });

}

function categoryChanged() {
    var categoryId = $('#Category').find(":selected").val();
    window.location.href = '/admin/lots/' + categoryId;
}
function partnerChanged() {
    var categoryId = $('#partner-select').find(":selected").val();
    $('#partners').load('/admin/partnersPartial?category=' + categoryId);
}
function statusChange(id) {
    var status = $('#status-select').find(":selected").val();
    $.ajax({
        type: "POST",
        url: "/Payment/ChangeStatus/",
        data: {
            paymentId: id,
            status:status
        },
        success: function (data) {
            alert(data);
            location.reload();
        },
        error: function (data) {
            console.log(data);
        }
    });
}
var GlobalIndex = 0;
$(document).on('click', '.fileUploadAdditional', function () {
    var parent = $(this).parent();
    var data = new FormData();
    var files = $(this).parent().find(".uploadEditorImage").get(0).files;
    if (files.length > 0) {
        data.append("HttpPostedFileBase", files[0]);
        $(this).parent().find('.image').val('/images/lots/' + files[0].name)
    }
    //.val('/images/' + files[0].name);
    $.ajax({
        url: "/Admin/GalleryUpload/"+$(this).prop('id'),
        type: "POST",
        processData: false,
        contentType: false,
        data: data,
        success: function (response) {
            //code after success
            $("#AnswerContainer").append(response);

        },
        error: function (er) {

            alert(er.responseText);
        }

    });
});


$(document).on('click', '.fileNewsUploadAdditional', function () {
    var parent = $(this).parent();
    var data = new FormData();
    var files = $(this).parent().find(".uploadEditorImage").get(0).files;
    if (files.length > 0) {
        data.append("HttpPostedFileBase", files[0]);
        $(this).parent().find('.image').val('/images/news/' + files[0].name)
    }
    //.val('/images/' + files[0].name);
    $.ajax({
        url: "/Admin/NewsImageUpload/" + $(this).prop('id'),
        type: "POST",
        processData: false,
        contentType: false,
        data: data,
        success: function (response) {
            //code after success
            $("#AnswerContainer").append(response);

        },
        error: function (er) {

            alert(er.responseText);
        }

    });
});

$(document).on('click', '.fileUpload', function () {
    var parent = $(this).parent();
    var data = new FormData();
    var files = $(this).parent().find(".uploadEditorImage").get(0).files;
    if (files.length > 0) {
        data.append("HttpPostedFileBase", files[0]);
        $(this).parent().find('.image').val('/images/lots/' + files[0].name)
    }
    //.val('/images/' + files[0].name);
    $.ajax({
        url: "/Admin/FileUpload/",
        type: "POST",
        processData: false,
        contentType: false,
        data: data,
        success: function (response) {
            //code after success
            alert(response)
        },
        error: function (er) {

            alert(er.responseText);
        }

    });
});


$(document).on('click', '.filePartnersUpload', function () {
    var parent = $(this).parent();
    var data = new FormData();
    var files = $(this).parent().find(".uploadEditorImage").get(0).files;
    if (files.length > 0) {
        data.append("HttpPostedFileBase", files[0]);
        $(this).parent().find('.image').val('/images/partners/' + files[0].name)
    }
    //.val('/images/' + files[0].name);
    $.ajax({
        url: "/Admin/FilePartnersUpload/",
        type: "POST",
        processData: false,
        contentType: false,
        data: data,
        success: function (response) {
            //code after success
            alert(response)
        },
        error: function (er) {

            alert(er.responseText);
        }

    });
});

$(document).ready(function () {
    GlobalIndex = $('#AnswerCount').val();
    $("#DeadLine").datetimepicker();
    $("#OccureDate").datetimepicker();
});

function removeNewsImage(id) {
    $.ajax({
        url: "/Admin/DeleteNewsImage/" + id,
        type: "POST",
        processData: false,
        contentType: false,
        success: function (response) {
            //code after success
            alert(response)
            $('#answerDiv' + id).remove();
        },
        error: function (er) {

            alert(er.responseText);
        }

    });
}

function removeLotImage(id) {
    $.ajax({
        url: "/Admin/DeleteLotImage/" + id,
        type: "POST",
        processData: false,
        contentType: false,
        success: function (response) {
            //code after success
            alert(response)
            $('#answerDiv' + id).remove();
        },
        error: function (er) {

            alert(er.responseText);
        }

    });
}

function addAnswers(index) {

    $.ajax({
        cache: false,
        type: "GET",
        url: "/Admin/ImagePartial/" + index,
        
        success: function (data) {
            // data will be the html from the partial view
            $("#AnswerContainer").append(data);
     
        },
        error: function (xhr, ajaxOptions, thrownError) {
            // Handle the error somehow
        }
    }); // end ajax call
}


function setWinner(index) {
    $.ajax({
        type: "POST",
        url: "/Manage/SetBidwinner/",
        data: { id: index },
        success: function (data) {
            alert(data);
            location.reload();
        },
        error: function (data) {
            alert("Error! topic not added.");
        }
    });
}
