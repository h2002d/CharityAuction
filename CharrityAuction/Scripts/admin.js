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

$(document).ready(function () {
    $(".fileUpload").click(function () {
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

    $("#DeadLine").datetimepicker();
    $("#OccureDate").datetimepicker();
});