function requestDelete() {
    $.ajax({
        url: '/Home/Delete',
        dataType: "json",
        type: "DELETE",
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify({ id: 20 }),
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