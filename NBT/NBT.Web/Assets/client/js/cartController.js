$(document).ready(function () {
    $('#frmOrder').submit(function (e) {
        e.preventDefault();
        var form = $('#frmOrder');
        var token = $('input[name="__RequestVerificationToken"]', form).val();

        $.ajax({
            url: '/Cart/Order',
            type: 'POST',
            data: {
                __RequestVerificationToken: token,
                FromDate: moment($('#datetimepicker4').val(), "DD/MM/YYYY").format(),
                ToDate: moment($('#datetimepicker5').val(), "DD/MM/YYYY").format(),
                Alias: $('#Alias').val(),
                Name: $('#Name').val(),
                Code: $('#Code').val(),
                Image: $('#Image').val(),
                Price: $('#Price').val(),
                Id: $('#Id').val()
            },
            success: function (result) {
                window.location.href = '/Cart/Index';
            },
            error: function (data) {
                console.log(data);
            }
        });
    });

});