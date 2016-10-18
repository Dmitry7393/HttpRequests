function requestPut() {
    $.ajax({
        url: '/Home/Put',
        dataType: "json",
        type: "PUT",
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify({ id: 4356 }),
        async: true,
        processData: false,
        cache: false,
        success: function (data) {

        },
        error: function (xhr) {
            alert('error');
        }
    });
}