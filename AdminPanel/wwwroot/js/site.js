// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    $("#order-filters select").on('change', function () {
        $("#order-filters").submit();
    });

   
    $('#start_date, #end_date').datetimepicker({
        format: 'd.m.Y H:i',
        lang: 'ru'
    });

    $('#category').select2({
        multiple: true
    });
});
