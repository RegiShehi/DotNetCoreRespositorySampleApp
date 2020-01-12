﻿var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/admin/category/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "50%" },
            { "data": "displayOrder", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Admin/category/Upsert/${data}" class='btn btn-success text-white' style='cursor:pointer; width: 100px'>
                                    <i class='far fa-edit'></i> Edit
                                </a>
                                &nbsp;
                                <a onclick=deleteCategory("/Admin/Category/Delete/${data}") class='btn btn-danger text-white' style='cursor:pointer; width: 100px'>
                                    <i class='far fa-trash-alt'></i> Delete
                                </a>
                            </div>`;
                }, "width": "30%"
            },
        ],
        "language": {
            "emptyTable": "No records found."
        },
        "width": "100%"
    });
}

function deleteCategory(url) {
    swal({
        title: "Are you sure you want to delete?",
        text: "You will not be able to restore the content!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                },
                error: function (xhr) {
                    toastr.error(xhr.responseText);
                }
            });
        }
    });
}