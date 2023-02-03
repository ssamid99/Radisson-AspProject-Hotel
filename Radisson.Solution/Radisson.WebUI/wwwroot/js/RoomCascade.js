$(document).ready(function () {
    GetRoomType();
    $('#Room').attr('disabled', true);
    $('#RoomType').change(function () {
        $('#Room').attr('disabled', false);
        var id = $(this).val();
        $('#Room').empty();
        $('#Room').append('<Option>---Sechin---</Option>');
        $.ajax({
            url: '/Reservations/Room?id=' + id,
            success: function (result) {
                $.each(result, function (i, data) {
                    $('#Room').append('<Option value = ' + data.id + '>' + data.number + '</Option>');
                });
            }
        });
    })
});

function GetRoomType() {
    $.ajax({
        url: '/ReservationsController/RoomType',
        success: function (result) {
            $.each(result, function (i, data) {
                $('#RoomType').append('<Option value = ' + data.id + '>' + data.name + '</Option>');
            });
        }
    });
}

