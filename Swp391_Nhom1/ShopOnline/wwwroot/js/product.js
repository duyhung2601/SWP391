﻿
    $(document).ready(function () {
        loadDataTable();
    });
    var dataTable;

    function loadDataTable() {
        dataTable = $('#tblData').DataTable({
            ajax: { url: '/admin/product/getall' },
            "columns": [
                { data: 'name', "width": "25%" },
                { data: 'sku', "width": "15%" },
                { data: 'listPrice', "width": "10%" },
                { data: 'company', "width": "20%" },
                { data: 'category.name', "width": "15%" },
                {
                    data: 'id',
                    "render": function (data) {
                        return `<div class="w-75 btn-group" role="group">
                   <a href="/admin/product/upsert?id=${data}" class="btn btn-primary mx-2">Update</a>
                   <button type="button" class="btn btn-danger mx-2" onclick="Delete('/admin/product/delete/${data}')">Delete</button>
                   </div>`
                    },
                    "width": "25%"
                }
            ]
        }
        );
    }
    function Delete(url) {
        Swal.fire({
            title: "Are you sure?",
            text: "You won't be able to revert this!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Yes, delete it!"
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: url,
                    type: 'DELETE',
                    success: function (data) {
                        dataTable.ajax.reload();
                        toastr.success(data.message)
                    }
                })

            }
        });
    }

