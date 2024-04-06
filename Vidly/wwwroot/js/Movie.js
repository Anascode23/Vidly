$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {

    dataTable = $('#tblmoviedata').DataTable({
        "ajax": {
            url:
                '/admin/movie/getall'
        },
        "columns": [
            { data: 'name', "width": "15%" },
            { data: 'genre.name', "width": "20%" }

        ]
    });

}