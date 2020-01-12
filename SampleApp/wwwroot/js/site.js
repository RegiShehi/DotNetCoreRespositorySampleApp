$(function () {
    //setup ajax error handling
    $.ajaxSetup({
        error: function (error) {
            //if (x.status == 403) {
            //    alert("Sorry, your session has expired. Please login again to continue");
            //    window.location.href = "/Account/Login";
            //}

            if (error.responseText === "" || error.responseText === null)
                return toastr.error("Server error");

            return toastr.error(error.responseText);
        }
    });
});