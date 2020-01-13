$(document).ready(function () {
    $("#currentYear").text(new Date().getFullYear());
});

$(document).ajaxError(function (event, request, settings) {
    //if (x.status == 403) {
    //    alert("Sorry, your session has expired. Please login again to continue");
    //    window.location.href = "/Account/Login";
    //}

    if (request.responseText === "" || request.responseText === null)
        return toastr.error("Server error");

    return toastr.error(request.responseText);
});