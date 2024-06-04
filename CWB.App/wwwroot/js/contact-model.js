function LoadDivisions(companyId) {
    api.get("/contacts/divisions/" + companyId).then((data) => {
        var tablebody = $("#tbl-division tbody");
        $(tablebody).html("");//empty tbody
        for (i = 0; i < data.length; i++) {
            $(tablebody).append(AppUtil.ProcessTemplateData("division-template", data[i]));
            if (ContactsConstants.DivisionId == data[i].divisionId) {
                ContactsFormUtil.PopulateForm(data[i]);
            }
        };
    }).catch((error) => {

    });
};
function LoadCompanies() {
    api.get("/contacts/companies").then((data) => {
        var tablebody = $("#tbl-contacts tbody");
        if (tablebody.length) { //if there is a tablebody in the parent populate it
            $(tablebody).html("");//empty tbody
            for (i = 0; i < data.length; i++) {
                $(tablebody).append(AppUtil.ProcessTemplateData("company-template", data[i]));
            }
        }
        if (typeof OnCompDialogHidden === 'function') {
            OnCompDialogHidden();
        }
        //filter once loaded
        ContactsUtil.FilterContacts();
    }).catch((error) => {

    });
};
var ContactsConstants = {
    DivisionId: 0
};
var ContactsFormUtil = {
    UpdateFormIDs: (data) => {
        //////debugger;
        $("#DivisionId").val(data.divisionId);
        $("#CompanyId").val(data.companyId);
    },
    PopulateForm: (data) => {
        //////debugger;
        $("#DivisionId").val(data.divisionId);
        $("#CompanyId").val(data.companyId);
        $("#CompanyType").val(data.companyType);
        $("#CompanyName").val(data.companyName);
        $("#DivisionName").val(data.divisionName);
        $("#DivisionId").val(data.divisionId);
        $("#Location").val(data.location);
        $("#Notes").val(data.notes);
    },
    PopulateFormFromRelatedTarget: (relatedTarget) => {
        //////debugger;
        $("#DivisionId").val(relatedTarget.data("divisionid"));
        $("#CompanyId").val(relatedTarget.data("id"));
        $("#CompanyType").val(relatedTarget.data("companytype"));
        $("#CompanyName").val(relatedTarget.data("companyname"));
        $("#DivisionName").val(relatedTarget.data("divisionname"));
        $("#Location").val(relatedTarget.data("location"));
        $("#Notes").val(relatedTarget.data("notes"));
    },
    UpdateDivisonTable: (companyId, divisionId) => {
        //////debugger;
        ContactsConstants.DivisionId = divisionId;
        LoadDivisions(companyId);
        /*api.get("/contacts/divisions/" + companyId).then((data) => {
            var tablebody = $("#tbl-division tbody");
            $(tablebody).html("");//empty tbody
            for (i = 0; i < data.length; i++) {
                $(tablebody).append(AppUtil.ProcessTemplateData("division-template", data[i]));
                if (ContactsConstants.DivisionId == data[i].divisionId) {
                    ContactsFormUtil.PopulateForm(data[i]);
                }
            };
        }).catch((error) => {

        });*/
    },
    ClearConstants: () => {
        ContactsConstants.DivisionId = 0;
    },
    ClearForm: () => {
        $("#DivisionId").val("0");
        $("#CompanyId").val("0");
        $("#CompanyType").val("");
        $("#CompanyName").val("");
        $("#DivisionName").val("");
        $("#DivisionId").val("0");
        $("#Location").val("");
        $("#Notes").val("");
    },
    ClearDivision: () => {
        $("#DivisionId").val("0");
        $("#DivisionName").val("");
        $("#Location").val("");
        $("#Notes").val("");
    },
    HasFunction: (obj, methodName) => {
        return ((typeof obj[methodName]) == "function");
    }
};


function DeleteCompany(companyID) {
    let confirmval = confirm("Are your sure you want to delete this company?", "Yes", "No");
    if (confirmval) {
        api.get("/contacts/deletecompany?companyID=" + companyID).then((data) => {
            LoadCompanies();
        }).catch((error) => {

        });
    }
};

function DeleteDivision(divisionId, companyId) {
    let confirmval = confirm("Are your sure you want to delete this division?", "Yes", "No");
    if (confirmval) {
        api.get("/contacts/deletedivision?divisionID=" + divisionId).then((data) => {
            LoadDivisions(companyId);
        }).catch((error) => {

        });
    }
};
function SetDivisionEditValues(divisionId,divisionName,location, notes,companyId,companyType,name) {
    var data = {};
    data['divisionId'] = divisionId;
    data['divisionName'] = divisionName;
    data['location'] = location;
    data['notes'] = notes;
    data['companyId'] = companyId;
    data['companyName'] = name;
    data['companyType'] = companyType;
    ContactsFormUtil.PopulateForm(data);
};

$(function () {
    $("#btnAddDivision").hide();
    $('#dialog-company').on('show.bs.modal', function (event) {
        ContactsFormUtil.ClearForm();
        ContactsFormUtil.ClearConstants();
        var relatedTarget = $(event.relatedTarget);
        var companyId = relatedTarget.data("id");
        var divisionId = relatedTarget.data("divisionid");
        if (companyId == "0") {
            var tablebody = $("#tbl-division tbody");
            $(tablebody).html("");//empty tbody
            $("#btnAddDivision").hide();
            return;
        }
        else {
           ContactsFormUtil.PopulateFormFromRelatedTarget(relatedTarget);
        }
        $("#btnAddDivision").show();
        ContactsFormUtil.UpdateDivisonTable(companyId, divisionId);

    });
    $('#dialog-company').on('hide.bs.modal', function (event) {
        ContactsFormUtil.ClearForm();
        ContactsFormUtil.ClearConstants();
    //    alert("On hide..");
       // $("#frmCompany").resetValidation();
        LoadCompanies();
    });

    /*$("#btnContactClose").click(function () {
        $("#dialog-company").dialog("close");
    });*/

    $("#btnContactSubmit").on('click',function () {
     //   //debugger;
        if ($("#frmCompany").valid()) {
            var formData = AppUtil.GetFormData("frmCompany");
            api.post("/contacts/company", formData).then((data) => {
                ContactsFormUtil.UpdateFormIDs(data);
                ContactsFormUtil.UpdateDivisonTable(data.companyId, data.divisionId);
                $("#btnAddDivision").show();
                ContactsFormUtil.ClearForm();
                ContactsFormUtil.ClearConstants();
                if (typeof OnCompanyCreated === 'function') {
                    OnCompanyCreated(data);
                }
                else {
                    LoadCompanies();
                    LoadDivisions(data.companyId);
                }
            }).catch((error) => {
                AppUtil.HandleError("frmCompany", error);
            });
        }
    });
    
    $("#btnAddDivision").on('click',function () {
        //////debugger;
        ContactsFormUtil.ClearDivision();
        ContactsFormUtil.ClearConstants();
    });
});