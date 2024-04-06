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
            { data: 'membershipType.name', "width": "20%" }

        ]
    });

}

