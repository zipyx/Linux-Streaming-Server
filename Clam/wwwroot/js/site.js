// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// #########################################################################################################
// #########################################################################################################
// #########################################################################################################
// #########################################################################################################
// #########################################################################################################
// #########################################################################################################
// #########################################################################################################
// #########################################################################################################
// #########################################################################################################
// #########################################################################################################
// #########################################################################################################
// #########################################################################################################

async function AJAXSubmit(oFormElement) {
    "use strict";
    const formData = new FormData(oFormElement);
    try {

        const response = await fetch(oFormElement.action, {
            method: 'POST',
            headers: {
                'RequestVerificationToken': getAntiForgeryToken()
            },
            body: formData 
        });

        //reload();
        //let result = await response.json;
        //alert(result.message);

        //oFormElement.elements.namedItem("result").value =
        //    'Result: ' + response.status + ' ' + response.statusText;
    } catch (error) {
        console.error('Error:', error);
    }
}

function getCookie(name) {
    var value = "; " + document.cookie;
    var parts = value.split("; " + name + "=");
    if (parts.length == 2) return parts.pop().split(";").shift();
}


// #########################################################################################################
// #########################################################################################################
// #########################################################################################################


function getAntiForgeryToken() {
    var token = $('input[name="__RequestVerificationToken"]').val();
    return token;
};

function uploadStreamingFile() {
    var data = new FormData();
    $.each($('#FileInput')[0].files, function (i, file) {
        data.append('__RequestVerificationToken', $('[name=__RequestVerificationToken]').val());
        data.append('file-' + i, file);
    });

    $.ajax({
        url: '@Url.Action("UploadDatabase", "TVShow")',
        body: data,
        cache: false,
        contentType: false,
        processData: false,
        method: 'POST',
        headers: {
            'RequestVerificationToken': getAntiForgeryToken({ })
        },
        success: function (returned) {

        },
        error: function (returned) {

        }
    });

}

// #########################################################################################################
// #########################################################################################################
// #########################################################################################################
// ---> Uploading Buffered files in storage file system
var UploadFiles = function (e) {
    var files = e.target.files;
    var formData = new FormData();
    for (var i = 0; i < files.length; i++) {
        formData.append("files", files[i]);
    }
    $.ajax({
        url: '/storage/filestream',
        body: formData,
        method: 'POST',
        headers: {
            'RequestVerificationToken': getAntiForgeryToken({})
        }
    });
}