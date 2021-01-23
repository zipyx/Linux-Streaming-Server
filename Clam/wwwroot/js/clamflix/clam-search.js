$(document).ready(function () {
    $("#NotDefinedYet").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $.ajax({
            url: '/clamflix',
            type: 'GET',
            data: value,
            success: function (response) {
                console.log(response)
            },
            error: function (response) {
                console.log("error");
                console.log(response);
            }
        })
        //$.get(url, value);
        $('#page-content').load(url);
        //$("#filmName h3").filter(function () {
        //    $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        //});
    });
});