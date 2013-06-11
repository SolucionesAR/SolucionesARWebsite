$(document).ready(function () {
    var editableRow = $("#editable-credit-flow-row");
    //handle the create new process flow in the credit process edition page
    $("#create-credit-flow").click(function (e) {
        e.preventDefault();
        $("#credit-process-x-company-id-label").text("-");
        $("#credit-process-x-company-id").val("0");
        $("#is-new").val("true");        
        editableRow.show();
    });

    $("#edit-credit-flow").click(function (e) {
        e.preventDefault();
        var creditProcessXCompanyId = $(this).parent().parent().children('td')[0];
        var finantialCompany = $(this).parent().parent().children('td')[1];
        var creditStatus = $(this).parent().parent().children('td')[2];

        $("#credit-process-x-company-id-label").text(creditProcessXCompanyId);
        $("#credit-process-x-company-id").val(creditProcessXCompanyId);
        $("#is-new").val("false");
        $(this).parent().parent().hide();
        editableRow.show();
        alert(creditProcessXCompanyId);alert(finantialCompany);alert(creditStatus);
    });

    $("#delete-credit-flow").click(function (e) {
        e.preventDefault();
        editableRow.show();
    });

    $("#save-credit-flow").click(function (e) {
        e.preventDefault();
        var creditProcessId = $("#CreditProcessId").val();
        var creditProcessXCompanyId = $("#credit-process-x-company-id").val();
        var finantialCompany = $("#FinantialCompany_CompanyId").val();
        var creditStatus = $("#CreditStatus_CreditStatusId").val();
        var isNew = $("#is-new").val();
        var href = $(this).attr('href');

        var processFlowViewModel = {
            CreditProcessId: creditProcessId,
            CreditProcessXCompanyId: 0,
            CompanyId: finantialCompany,
            CreditStatusId: creditStatus,
            IsNew: isNew,
        };
        $.post(href, processFlowViewModel, function (data) {
            alert(data.success);
        });

        editableRow.hide();
    });
    $("#cancel-credit-flow").click(function (e) {
        e.preventDefault();
        editableRow.hide();
    });
});