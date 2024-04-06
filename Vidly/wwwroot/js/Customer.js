var dataTable;
$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {

    dataTable = $('#tblcustomerdata').DataTable({
        "ajax": {
            url:
                '/admin/customer/getall'
        },
        "columns": [
            { data: 'name', "width": "15%" },
            { data: 'membershipType.name', "width": "20%" },
            {
                data: 'id', "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                    <a href="/admin/customer/upsert?id=${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i> Edit</a>
                   <a onClick=Delete('/admin/customer/delete/${data}') class="btn btn-danger mx-2"><i class="bi bi-trash-fill"></i> Delete</a>
                    </div>`
                }, "width": "40%"
            }
        ]
    });

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

