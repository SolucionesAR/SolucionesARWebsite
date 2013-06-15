$(document).ready(function () {
    var editableRow = $("#editable-credit-flow-row");
    var maxQtyCreditFlows = 9; //7 is the max + hidden row + header
    
    //handle the create new process flow in the credit process edition page
    $("#create-credit-flow").click(function (e) {
        e.preventDefault();
        $("#is-new").val("true");
        
       //There is a max quantity of process flows
        if ($('table tr').length < maxQtyCreditFlows) {
            $("#credit-process-x-company-id-label").text("-");
            $("#credit-process-x-company-id").val("0");
        
            //if the editor is displayed...
            if($("#is-editor-displayed").val() == 'true') {
                //...show the previous values
                showPreviousValues();
            }
            $("#company-credit-flow").val(1);
            $("#status-credit-flow").val(1);
            showDowndowns(editableRow, "");
            $(".editable-company-cell").show();
            $(".editable-status-cell").show();
            $(".editable-actions-cell").show();

            editableRow.show();
        } else {
            $.confirm({
			    'title'		: 'Confirmacion',
			    'message'	: 'La cantidad maxima de flujos de credito por cada proceso de credito es de 7. <br/> No se pueden agregar mas flujos a este proceso.',
			    'buttons'	: {
				    'Aceptar'	: {
					    'class'	: 'blue',
					    'action': 
                            function(){}
				    }
			    }
		    });
        }
    });

    //handle the edit process flow in the credit process edition page
    $(".edit-credit-flow").click(function (e) {
        e.preventDefault();
        $("#is-new").val("false");
        var creditProcessXCompanyId = $(this).parent().parent().find('label.credit-flow-id').text();
        var finantialCompanyId = $(this).parent().parent().find('input[name$="CompanyId"]').val();
        var creditStatusId = $(this).parent().parent().find('input[name$="CreditStatusId"]').val();
        
        $("#company-credit-flow").val(finantialCompanyId);
        $("#status-credit-flow").val(creditStatusId);
        
        //if the user has displayed the create new credit flow row 
        if($('#editable-credit-flow-row').css("display") != "none") {
            editableRow.hide();
        }

        //if the editor is displayed...
        if($("#is-editor-displayed").val() == 'true') {
            //...show the previous values
            showPreviousValues();
        }
        showDowndowns($(this).parent().parent(), creditProcessXCompanyId);
    });
    
    //handle the delete process flow in the credit process edition page
    $(".delete-credit-flow").click(function (e) {
        e.preventDefault();
        var href = $(this).attr('href');
        var creditProcessXCompanyId = $(this).parent().parent().find('label.credit-flow-id').text();
        var currentRow = $(this).parent().parent();

		$.confirm({
			'title'		: 'Confirmacion',
			'message'	: 'Esta cerca de eliminar este elemento. Este no se podra recuperar en plazo cercano! <br />Desea continuar?',
			'buttons'	: {
				'Si'	: {
					'class'	: 'blue',
					'action': 
                        function(){
                            var deleteViewModel = {
                                CreditProcessId: $("#CreditProcessId").val(),
                                CreditProcessXCompanyId: creditProcessXCompanyId,
                                IsDeleted: true,
                            };
                            $.post(href, deleteViewModel, function (data) {
                                currentRow.hide();
                            });
                        }
				},
				'No'	: {
					'class'	: 'gray',
					'action': function(){}	// Nothing to do in this case. You can as well omit the action property.
				}
			}
		});
		
	});
    
    //handle the save process flow in the credit process edition mode
    $("#save-credit-flow").click(function (e) {
        e.preventDefault();
        var isNew = $("#is-new").val();
        var creditProcessId = $("#CreditProcessId").val();        
        var creditProcessXCompanyId = $(this).parent().parent().find('label.credit-flow-id').text();
        var finantialCompanyId = $("#company-credit-flow option:selected").val();
        var finantialCompanyLabel = $("#company-credit-flow option:selected").text();
        var creditStatusId = $("#status-credit-flow option:selected").val();
        var creditStatusLabel = $("#status-credit-flow option:selected").text();
        var href = $(this).attr('href');
        if(creditProcessXCompanyId == "") {
            creditProcessXCompanyId = 0;
        }

        var processFlowViewModel = {
            CreditProcessId: creditProcessId,
            creditProcessXCompanyId: creditProcessXCompanyId,
            CompanyId: finantialCompanyId,
            CreditStatusId: creditStatusId,
            IsNew: isNew,
        };

        $.post(href, processFlowViewModel, function (data) {
            //if the user has displayed the create new credit flow row 
            if($('#editable-credit-flow-row').css("display") != "none") {
                //....hide all the row
                editableRow.hide();
                var newRowEntry = createNewRow(finantialCompanyLabel, creditStatusLabel);
                $("table").append(newRowEntry);
            } else {
                //....hide the dropdowns
                hideDowndowns(creditProcessXCompanyId, finantialCompanyLabel, creditStatusLabel);
            }

            //if the record was updated/inserted
            if(data.success == "true") {
                //set new values and labels
                $('label#company-label-' + creditProcessXCompanyId).text(finantialCompanyLabel);
                $('label#status-label-' + creditProcessXCompanyId).text(creditStatusLabel);
                $("#company-credit-flow").val(finantialCompanyId);
                $("#status-credit-flow").val(creditStatusId);
            }
            //show the new labels in the cells and their hidden values
            $('label#company-label-' + creditProcessXCompanyId).show();
            $('label#status-label-' + creditProcessXCompanyId).show();
        });
    });
    
    //handle the cancel process flow in the credit process edition mode
    $("#cancel-credit-flow").click(function (e) {
        e.preventDefault();
        var creditProcessXCompanyId = $(this).parent().parent().find('label.credit-flow-id').text();
        
        //if the user has displayed the create new credit flow row 
        if($('#editable-credit-flow-row').css("display") != "none") {
            //....hide all the row
            editableRow.hide();
        } else {
            //....hide the dropdowns
            hideDowndowns(creditProcessXCompanyId);
        }

        $("#is-editor-displayed").val("true");
    });
});

function showPreviousValues() {
    //...show the previous values
    var previousCreditProcessXCompanyId = $('#company-credit-flow').parent().parent().find('label.credit-flow-id').text();
    $('label#company-label-' + previousCreditProcessXCompanyId).show();                        
    $('label#status-label-' + previousCreditProcessXCompanyId).show();            
    $('#edit-credit-flow-' + previousCreditProcessXCompanyId).show();
    $('#delete-credit-flow-' + previousCreditProcessXCompanyId).show();
}

function showDowndowns(rowElement, creditProcessXCompanyId) {
    //...hide labels and show the downdowns
    $('label#company-label-' + creditProcessXCompanyId).hide();
    rowElement.find('.editable-company-cell').append($("#company-credit-flow"));
           
    $('label#status-label-' + creditProcessXCompanyId).hide();
    rowElement.find('.editable-status-cell').append($("#status-credit-flow"));
            
    $('#edit-credit-flow-' + creditProcessXCompanyId).hide();
    $('#delete-credit-flow-' + creditProcessXCompanyId).hide();
    rowElement.find('.editable-actions-cell').prepend($("#save-credit-flow"));
    rowElement.find('.editable-actions-cell').append($("#cancel-credit-flow"));

    $("#is-editor-displayed").val("true");
}

function hideDowndowns(creditProcessXCompanyId, finantialCompanyLabel, creditStatusLabel) {
    //...show previous values and hide the downdowns
    $('label#company-label-' + creditProcessXCompanyId).show();
    $("#editable-credit-flow-row").find('.editable-company-cell').append($("#company-credit-flow")).hide();
           
    $('label#status-label-' + creditProcessXCompanyId).show();
    $("#editable-credit-flow-row").find('.editable-status-cell').append($("#status-credit-flow")).hide();
            
    $('#edit-credit-flow-' + creditProcessXCompanyId).show();
    $('#delete-credit-flow-' + creditProcessXCompanyId).show();
    $("#editable-credit-flow-row").find('.editable-actions-cell').prepend($("#save-credit-flow")).hide();
    $("#editable-credit-flow-row").find('.editable-actions-cell').append($("#cancel-credit-flow")).hide();
}

function createNewRow (finantialCompanyLabel, creditStatusLabel) {
    var newRowEntry = 
        "<tr>" +
            "<td>" +
                "<label class='credit-flow-id'>-</label>" +
            "</td>" +
            "<td class='editable-company-cell'>" +
                "<label style='display: inline;'>" + finantialCompanyLabel + "</label>" +
            "</td>" +
            "<td class='editable-status-cell'>" +
                "<label style='display: inline;'>" + creditStatusLabel + "</label>" +
            "</td>" +
            "<td>" +
                "<label class='credit-flow-details'>-</label>" +
            "</td>" +
            "<td class='editable-actions-cell'>" +
                "<label class='credit-flow-actions'>-</label>" +
            "</td>" +
        "</tr>";
    return newRowEntry;
}