$(document).ready(function () {
    loadDataTable();
})


function loadDataTable() {

    dataTable = $('#tbldata').DataTable({
        "ajax": {
            url:
                '/controller/customer/getall'
        },
        "columns": [
            { data: 'name', "width": "15%" },
            { data: 'position', "width": "15%" },
            { data: 'salary', "width": "15%" },
            { data: 'office', "width": "15%" }

        ]
    });

}

