$(document).ready(function () {

    if ($('#Amount').val() != '0') {
        $("#ComisionPercentage").val($('#Comision').val() / $('#Amount').val() * 100);
    } else {
        $("#ComisionPercentage").val(0);
    }


    $("#Amount").change(function () {
        //calculate or update the points
        $("#Points").val(Math.round($('#Amount').val() / 7000));
        //calculate or update the comision amount
        $("#Comision").val($('#Amount').val() * $('#ComisionPercentage').val() / 100);
    });


    $("#ComisionPercentage").change(function () {
        $("#Comision").val($('#Amount').val() * $('#ComisionPercentage').val() / 100);
    });


    $("#Amount").keydown(function (event) {
        // Allow: backspace, delete, tab, escape, and enter
        if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 || event.keyCode == 13 ||
        // Allow: Ctrl+A
            (event.keyCode == 65 && event.ctrlKey === true) ||
        // Allow: home, end, left, right
            (event.keyCode >= 35 && event.keyCode <= 39) ||
        // Allow: period 
            (event.keyCode == 190)) {
            // let it happen, don't do anything
            return;
        } else {
            // Ensure that it is a number and stop the keypress
            if (event.shiftKey || (event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105)) {
                event.preventDefault();
            }
        }
    });
});