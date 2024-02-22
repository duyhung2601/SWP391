$(document).ready(function () {
    loadDataSlider();
});
var dataTable;

function loadDataSlider() {
    dataTable = $('#tblSlider').DataTable({
        ajax: { url: '/admin/slider/getall' },
        "columns": [
            {
                data: 'imageUrl', "width": "20%", "render": function (data) {
                    return `<img src="${data}" class="card-img-top rounded"/>`
                },
            },
            { data: 'name', "width": "35%" },
            { data: 'description', "width": "35%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                   <a href="/admin/slider/upsert?id=${data}" class="btn btn-primary mx-2">Update</a>
                   <button type="button" class="btn btn-danger mx-2" onclick="Delete('/admin/slider/delete/${data}')">Delete</button>
                   </div>`
                },
                "width": "10%"
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

