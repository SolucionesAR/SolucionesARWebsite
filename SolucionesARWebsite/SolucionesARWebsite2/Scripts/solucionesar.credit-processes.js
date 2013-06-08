$(document).ready(function () {
    //handle the create new process flow in the credit process edition page
    $("#create-new-flow").click(function (e) {
        e.preventDefault();
        var editableRow = $("#editable-row");
        editableRow.show();
    });
    $("#save-new-flow").click(function (e) {
        e.preventDefault();
        var finantialCompany = $("#FinantialCompany_CompanyId").val();
        var creditStatus = $("#CreditStatus_CreditStatusId").val();
        var href = $(this).attr('href');

        var processFlowViewModel = {
            CreditProcessXCompanyId: 0,
            CreditProcessId: zipcode,
            CompanyId: finantialCompany,
        }
        $.post(href, processFlowViewModel, function (data) {
            alert(data);
        });

        editableRow.hide();
    });
    $("#cancel-new-flow").click(function (e) {
        e.preventDefault();
        var editableRow = $("#editable-row");
        editableRow.hide();
    });
});