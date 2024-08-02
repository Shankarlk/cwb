let RoutingDetails = {};//contains page model


let dataPartsRoutings = {};
let partType = "ManufacturedPart";
let spartType = "ManufacturedPart";
let withRouting = true;
let selectedManuPartId = "";
let selectedBomId = "";
let qtyAvailable = 0;
let hasRouting = true;
let stepModel = {};
let routingModel = {};
let routingSteps = {};
let operations = {};
let locations = {};
let stepMachines = {};
let maclist = {};
//let editSubCon = false;





//SubCon functions-start
//SubCons / SubConWSS / DeleteSubConDetails / DeleteSubConWS / AddSubCon//AddSubConWS

////SubConWSSubConDetailsId//SubConWSRoutingStepId//SubConWSDetailsId
//WorkStepDesc//MachineType//FloorToFloorTime//SetupTime//NoOfPartsPerLoading
function AssignWorkStepVals(workStepDesc, machineType, floorToFloorTime,
    setupTime, noOfPartsPerLoading, routingStepId , subConDetailsId, subConWSDetailsId) {
    $("#WorkStepDesc").val(workStepDesc);
    $("#SubConWSSubConDetailsId").val(subConDetailsId);
    $("#SubConWSRoutingStepId").val(routingStepId);
    $("#SubConWSDetailsId").val(subConWSDetailsId);
    $("#FloorToFloorTime").val(floorToFloorTime);
    $("#SetupTime").val(setupTime);
    $("#NoOfPartsPerLoading").val(noOfPartsPerLoading);
    $("#MachineType").val(machineType).trigger('change');
}

function DeleteWS(subConWSDetailsId)
{
    //alert(subConWSDetailsId);
    let confirmval = confirm("Are your sure you want to delete this work step?", "Yes", "No");
    if (confirmval) {
        api.get("/routings/deletews?subConWSId=" + subConWSDetailsId).then((data) => {
            //console.log(data);
            LoadSubConWSS();
        }).catch((error) => {
            AppUtil.HandleError("FormDelRoutingName", error);
        });
    }

}

function AddMacOptions() {
    api.get("/machine/getmachines").then((data) => {
        maclist = data;
        var macplants = $("#MAC_Plants");
        macplants.empty();
        var div_data = "<option value=''>--Select--</option>";
        macplants.append(div_data);
        var macshops = $("#MAC_Shops");
        macshops.empty();
        macshops.append(div_data);
        //debugger;
        if (maclist.length > 0) {
            const uniquePlants = new Set();
            const uniqueShops = new Set();

            for (let i = 0; i < maclist.length; i++) {
                const plant = maclist[i].plant;
                const shop = maclist[i].shop;

                if (!uniquePlants.has(plant)) {
                    uniquePlants.add(plant);
                    macplants.append("<option id='" + plant + "'>" + plant + "</option>");
                }

                if (!uniqueShops.has(shop)) {
                    uniqueShops.add(shop);
                    macshops.append("<option id='" + shop + "'>" + shop + "</option>");
                }
            }
        }

        loadMachineTypes("MAC_Type");
    }).catch((error) => {
        //console.log(error);
    });
}
/*function SetOpType(optype) {
    alert(optype);
    //add-edit
    if (optype == "add") {
        editSubCon = false;
    }
    else
        editSubCon = true;
}*/
function ShowAddSubConJob(event) {
    ClearWSTable();
    if ($("#StepId").val() == "0") {
        alert("Save routing step before adding subcon.");
        document.getElementById("Add-SubCon-Close").click();
        //document.getElementById("Add-Machine-Close").click();
    }
    $("#subconname").text("");
    document.getElementById("FormSubCon").reset();
    document.getElementById("FormSubConWS").reset();
    loadMachineTypes("MachineType");
    let stepId = RoutingDetails["stepId"];
    var tablebody = $("#TitleTableSubCon tbody");
    tablebody.html("");
    $(tablebody).append(AppUtil.ProcessTemplateData("TitleRow", RoutingDetails));
    ////WorkDone    //TransportTime//CostPerPart//PreferredSubCon//SubConSupplierId//SubConDetailsId//SubConRoutingStepId
    var rTgt = $(event.relatedTarget);
    var addEdit = rTgt.data("addedit");
    var selectedSupplierId = -1;
    if (addEdit == "Add") {
        $('#SubConRoutingStepId').val(stepId);
        loadSuppliersToTable("SubConNamesTable", "SubConNameRow",0);
    }
    else {
        $("#subconname").text(rTgt.data("company"));
        $("#WorkDone").val(rTgt.data("workdone"));
        $("#TransportTime").val(rTgt.data("transporttime"));
        $("#CostPerPart").val(rTgt.data("costperpart"));
        $("#PreferredSubCon").val(rTgt.data("preferredsubcon"));
        $("#SubConSupplierId").val(rTgt.data("subconsupplierid"));
        selectedSupplierId = rTgt.data("subconsupplierid");
        $("#SubConDetailsId").val(rTgt.data("subcondetailsid"));
        $("#SubConRoutingStepId").val(rTgt.data("subconroutingstepid"));
        RoutingDetails["subConDetailsId"] = rTgt.data("subcondetailsid");

        $("#SubConWSSubConDetailsId").val(rTgt.data("subcondetailsid"));
        $("#SubConWSRoutingStepId").val(rTgt.data("subconroutingstepid"));

        loadSuppliersToTable("SubConNamesTable", "SubConNameRow", selectedSupplierId);
        let subcons = document.getElementsByName("RadioSubConName");
        //console.log(subcons.length);
        for (let i = 0; i < subcons.length; i++) {
            //console.log(subcons[i].value);
            if (selectedSupplierId == subcons[i].value) {
                subcons[i].checked = true;
            }
        }
        LoadSubConWSS();
     //   console.log("stepsubcon_" + selectedSupplierId);
     //   document.getElementById("stepsubcon_" + selectedSupplierId).checked = true;
        //stepsubcon_selectedSupplierId
    }
    
}
function LoadSubCons() {
    //debugger;
    var tablebody = $("#SubConsTable tbody");
    $(tablebody).html("");//empty tbody
    let stepId = RoutingDetails["stepId"];
    //console.log("=====stepId" + stepId);
    api.get("/routings/subcons?stepId=" + stepId).then((data) => {

        for (i = 0; i < data.length; i++) {
            if (data[i].deleted == 1)
                continue;
            $(tablebody).append(AppUtil.ProcessTemplateData("RouteSubConsTemplate", data[i]));
        }
        //console.log(data);
        //console.log(tablebody.html());
        //RouteSuppliersTable
        //RouteSupplierTemplate
    }).catch((error) => {
    });
};

function ClearWSTable()
{
    var tablebody = $("#WSTable tbody");
    $(tablebody).html("");//empty tbody
}

function LoadSubConWSS() {
    var tablebody = $("#WSTable tbody");
    $(tablebody).html("");//empty tbody
    
    let subConDetailsId = RoutingDetails["subConDetailsId"];
    let stepId = RoutingDetails["stepId"];
  //  alert(subConDetailsId + "/" + stepId);
    //masters/subconwss
    api.get("/routings/subconwss?stepId=" + stepId +"&subConDetailsId="+subConDetailsId).then((data) => {
        //console.log(data);
        for (i = 0; i < data.length; i++) {
            $(tablebody).append(AppUtil.ProcessTemplateDataNew("WSRow", data[i], i));
        }
        //console.log($(tablebody).html());
    }).catch((error) => {
        //console.log(error);
    });

};

function DeleteSubCon(stepId,subConDetailsId) {
    //routings/deletesubcondetails
    var routingId = $("#DelRoutingId").val();
    alert(routingId);
    api.get("/routings/deletesubcondetails?routingId=" + routingId).then((data) => {
        //console.log(data);
        routdeleted = true;
        document.getElementById("BtnDelRoutingClose").click();
    }).catch((error) => {
        AppUtil.HandleError("FormDelRoutingName", error);
    });
}

function DeleteSubConWS(stepId, subConWSDetailsId) {
    //nasters/deletesubconws
}

function AddSubCon() {
    //masters/addsubcon
    //console.log("....AddSubCon....");
    var formData = AppUtil.GetFormData("FormSubCon");
  //  console.log(formData);
    api.post("/routings/addsubcon", formData).then((data) => {
        //console.log("****AddSubCon****");
        //console.log(data);
        //console.log("****End-AddSubCon****");
        RoutingDetails["subConDetailsId"] = data.subConDetailsId;
        $("#SubConWSSubConDetailsId").val(data.subConDetailsId);
        $("#SubConWSRoutingStepId").val(RoutingDetails["stepId"]);
        //document.getElementById("Btn").click();
    }).catch((error) => {
        AppUtil.HandleError("FormSubCon", error);
    });
    
};

function AddSubConWS() {
    //masters/addsubconws
    var formData = AppUtil.GetFormData("FormSubConWS");
    //console.log(formData);
    api.post("/routings/addsubconws", formData).then((data) => {
        //console.log(data);
        let wsid = $("#SubConWSSubConDetailsId").val();
        let stepid = $("#SubConWSRoutingStepId").val();
        LoadSubConWSS();
        document.getElementById("FormSubConWS").reset();
        $("#SubConWSSubConDetailsId").val(wsid);
        $("#SubConWSRoutingStepId").val(stepid);
        //document.getElementById("Btn").click();
    }).catch((error) => {
        AppUtil.HandleError("FormSubConWS", error);
    });
};

function EditSubCon() {
    //masters/addsubcon
    //editSubCon = true;
    //ShowAddSubConJob();
};

function EditSubConWS() {
    //masters/addsubconws
    AddSubConWS();
};

function SetPreferredSubCon(subConDetailsId) {
    //alert("Preferred machine" + ":" + routingStepId + "/" + routingStepMachineId);
    api.get("/routings/preferredsubcon?subConDetailsId=" + subConDetailsId).then((data) => {
        LoadSubCons();
    }).catch((error) => {
    });
}



//SubCon functions-end


function LoadLocations() {
    var selElem = $('#StepLocation');//should be a select2 dropdown
    if (!selElem.length)
        return;
    selElem.empty();
    var div_data = "<option value=''></option>";
    selElem.append(div_data);
    if (locations.length > 0) {
        let data = locations;
        for (i = 0; i < data.length; i++) {
            div_data = "<option value='" +
                data[i].id + "'>" +
                data[i].name +
                "</option>";
            //console.log(div_data);
            selElem.append(div_data);
        }
        return;
    }
    
    api.get("/routings/locations").then((data) => {
        locations = data;
        for (i = 0; i < data.length; i++) {
            div_data = "<option value='" +
                data[i].id + "'>" +
                data[i].name +
                "</option>";
            //console.log(div_data);
            selElem.append(div_data);
        }
    }).catch((error) => {
        //console.log(error);
    });
}

function LoadOperations() {
    var selElem = $('#StepOperation');//should be a select2 dropdown
    if (!selElem.length)
        return;
    selElem.empty();
    var div_data = "<option value=''></option>";
    selElem.append(div_data);

    /*if (operations.length > 0) {
        for (i = 0; i < operations.length; i++) {
            div_data = "<option value='" +
                operations[i].operationId + "'>" +
                operations[i].operation +
                "</option>";
            selElem.append(div_data);
        }
        return;
    }*/
    if (operations.length > 0) {
        let data = operations;
        for (i = 0; i < data.length; i++) {
            div_data = "<option value='" +
                data[i].operationId + "'>" +
                data[i].operation +
                "</option>";
            //console.log(div_data);
            selElem.append(div_data);
        }
        return;
    }

    api.get("/operationlist/operations").then((data) => {
        operations = data;
        for (i = 0; i < data.length; i++) {
            div_data = "<option value='" +
                data[i].operationId + "'>" +
                data[i].operation +
                "</option>";
            //console.log(div_data);
            selElem.append(div_data);
        }
    }).catch((error) => {
        //console.log(error);
    });
}


function ProcessTemplateDataNew(templateId, dataObj) {
    var templateElement = $("#" + templateId).html();
    ////console.log(templateId);
    templateElement = templateElement.replaceAll("{partType}", partType)
    for (var key in dataObj) {
        ////console.log(key + " " + dataObj[key]);
        templateElement = templateElement.replaceAll("{" + key + "}", dataObj[key])
    }
    //console.log(templateElement);
    return templateElement;
}

// JavaScript source code
function DowlonadPartsRoutings() {
    //RoutingListItems
    var tablebody = $("#PartsRoutingsTable tbody");
    $(tablebody).html("");//empty tbody
    //UpdatePurchaseDetailsTableFromPostData
    let i = 0;
    if (dataPartsRoutings.length > 2) {
        let data = dataPartsRoutings;
        for (i = 0; i < data.length; i++) {
            if (!(data[i]['masterPartType'] == partType))
                continue;
            for (var key in data[i]) {
                //console.log(key + "/" + data[i][key]);
            }
            //console.log("================");
            //console.log(partType);
            //console.log("================");
            if (withRouting) {
                if ((data[i]['noOfRoutes'] == 0))
                    continue;
            }
            else {
                if ((data[i]['noOfRoutes'] > 0))
                    continue;
            }
            //if ((data[i]['hasRouting']) != hasRouting)
              //  continue;
            $(tablebody).append(AppUtil.ProcessTemplateDataNew("Parts-Routing-Template", data[i],i));
        }
    }
    else {
        api.getbulk("/routings/routinglistitems").then((data) => {
            //console.log(data);
            dataPartsRoutings = data;
            for (i = 0; i < data.length; i++) {
                if (!(data[i]['masterPartType'] == partType))
                    continue;
                for (var key in data[i]) {
                   // console.log(key + "/" + data[i][key]);
                }
                //console.log("================");
                //console.log(partType);
                //console.log("================");
                if (withRouting) {
                    if ((data[i]['noOfRoutes'] == 0))
                        continue;
                }
                else {
                    if ((data[i]['noOfRoutes'] > 0))
                        continue;
                }
                $(tablebody).append(AppUtil.ProcessTemplateDataNew("Parts-Routing-Template", data[i], i));
            }
        }).catch((error) => {
        });
    }
}

function showElement(elem) {
    elem.style.display = "block";
};
function hideElem(elem) {
    elem.style.display = "none";
};
function hideMachinesSuppliersTable() {
    let machs = document.getElementById("Div_RouteMachines");
    let suplrs = document.getElementById("Div_RouteSubCons");
    hideElem(machs);
    hideElem(suplrs);
};
function getRoutingInfoFromTable() {
    //stepsupplierselect
    var chkdelm = $('input[name=RoutingChk]:checked');
    var currentrow = chkdelm.closest('tr');
    var routingId = $('input[name=RoutingChk]:checked').val();
    var routingName = currentrow.find("td:eq(1)").html();
    RoutingDetails["routingName"] = routingName;
    RoutingDetails["routingId"] = routingId;
    RoutingDetails["stepNumber"] = "";
};
function getRoutingInfoFromTarget(event) {
    //stepsupplierselect
    var relatedTarget = $(event.relatedTarget);
    var routingId = relatedTarget.data("routingid");
    var routingName = relatedTarget.data("routingname");
    RoutingDetails["routingName"] = routingName;
    RoutingDetails["routingId"] = routingId;
    RoutingDetails["stepNumber"] = "";
};

function emptyTables() {
    var tablebody = $("#RouteMachinesTable tbody");
    $(tablebody).html("");//empty tbody
    var tablebody = $("#SubConsTable tbody");
    $(tablebody).html("");//empty tbody
};



function loadSetSuppliers() {
    //debugger;
    var tablebody = $("#RouteSuppliersTable tbody");
    $(tablebody).html("");//empty tbody
    let stepId = RoutingDetails["stepId"];
    //console.log("=====stepId" + stepId);
    api.get("/routings/stepsuppliers?stepId=" + stepId).then((data) => {

        for (i = 0; i < data.length; i++) {
            $(tablebody).append(AppUtil.ProcessTemplateData("RouteSupplierTemplate", data[i]));
        }
        //console.log(data);
        //console.log(tablebody.html());
        //RouteSuppliersTable
        //RouteSupplierTemplate
    }).catch((error) => {
    });
};

function DoRoutingDetailsJob() {
    //getRoutingInfoFromTarget(event);
    $("#DivRoutingName").html("<h5>Routing Name : " + RoutingDetails.routingName + "</h5>");
    $("#DivRoutingName1").html("<h5>Routing Selected : " + RoutingDetails.routingName + "</h5>");
    $('#StepRoutingId').val(RoutingDetails.routingId);
    LoadRoutingSteps(RoutingDetails.routingId);
}

function loadStepMachinesForAdd() {
    var selElem = $('#StepMachine');//should be a select2 dropdown
    if (!selElem.length)
        return;
    selElem.empty();
    var div_data = "<option value=''></option>";
    selElem.append(div_data);
    let stepId = RoutingDetails["stepId"];
    //console.log("stepId" + stepId);
    api.get("/routings/stepmachines?stepId=" + stepId).then((data) => {
        stepMachines = data;
        for (i = 0; i < data.length; i++) {
            div_data = "<option value='" +
                data[i].routingStepMachineId + "'>" +
                data[i].name +
                "</option>";
           // console.log(div_data);
            selElem.append(div_data);
        }
    }).catch((error) => {
    });
};

function SetAssemblyIds() {
    $("#BOMManufacturedPartId").val(RoutingDetails.manufacturedPartId);
    var stepId = $("#StepId").val();
    $("#BOMRoutingStepId").val(stepId);
}
function LoadStepPartsFromData(rData) {
    var tablebody = $("#StepPart-BOMQTY-Table tbody");
    tablebody.html("");
    let i = 0;
    let lastSelectedBOMId = "";
    for (i = 0; i < rData.length; i++) {
        if (rData[i].quantityUsed != "0") {
            $(tablebody).append(AppUtil.ProcessTemplateData("RT_BOMQTY-template", rData[i]));
            if (lastSelectedBOMId == "") {
                lastSelectedBOMId = rData[i]['mpbomId'];
                $("#" + lastSelectedBOMId).attr('checked', true);
            }
        }
    }
   // console.log(rData);
}

function LoadStepParts(partId, stepId) {
    var tablebody = $("#StepPart-BOMQTY-Table tbody");
    tablebody.html("");
    let rData = {};
    let i = 0;
    api.get("/routings/boms?partId=" + partId + "&stepId=" + stepId).then((rData) => {
        for (i = 0; i < rData.length; i++) {
            if (rData[i].quantityUsed != "0") {
                $(tablebody).append(AppUtil.ProcessTemplateData("RT_BOMQTY-template", rData[i]));
            }
        }
        //console.log(rData);
        //  LoadStepPartsFromData(rData);
    }).catch((error) => {
    });
}

function SetBOMEditVals(partId, stepId, partNo, bomId, partDesc, qty) {
    //console.log(partId + "/" + stepId + "/" + partNo + "/" + bomId + "/" + partDesc + "/" + qty);
    SetOp("edit");
    $("#BOMId").val(bomId);
    $("#BOMPartNo").val(partNo);
    $("#BOMPartDescription").val(partDesc);
    $("#QuantityAssembly").val(qty);
    $("#RoutingStepPartId").val(partId);
    //BOMPartNo,BOMPartDescription,QuantityAssembly
    //BOMId
    //RoutingStepPartId
    //BOMRoutingStepId,BOMManufacturedPartId
    SetAssemblyIds();
    document.getElementById("BOMChk_" + bomId).checked = true;
    var chkdelm = $('input[name=BOMChk]:checked');
    var currentrow = chkdelm.closest('tr');
    var qtySelected = currentrow.find("td:eq(4)").html();
    qtyAvailable = parseInt(qtySelected);
    qtyAvailable += qty;
}

function DeleteStepPart(partId, stepId) {
    //int stepId,int stepPartId
    //alert(partId + "/" + stepId);
    let confirmval = confirm("Are your sure you want to delete this BOM?", "Yes", "No");
    if (confirmval) {
        api.get("/routings/deletesteppart?stepId=" + stepId+"&stepPartId="+partId).then((data) => {
            //console.log(data);
            LoadBOMList(stepId);
        }).catch((error) => {
        });
    }
}

function LoadRoutingSteps(routingId) {
    var tablebody = $("#StepTable tbody");
    tablebody.html("");
    let rData = {};
    let i = 0;
    api.get("/routings/routingsteps?routingId=" + routingId).then((rData) => {
        for (i = 0; i < rData.length; i++) {
            $(tablebody).append(AppUtil.ProcessTemplateData("RoutingStepTemplate", rData[i]));
        }
        routingSteps = rData;
        //console.log(rData);
    }).catch((error) => {
    });
}

function LoadBOMList(stepId) {
    //debugger;
    var tablebody = $("#StepPart-BOM-Table tbody");
    tablebody.html("");
    let rData = {};
    let i = 0;
    let manufId = RoutingDetails.manufacturedPartId;
    api.get("/routings/boms?manufId=" + manufId + "&stepId=" + stepId).then((rData) => {
        //console.log(rData);
        for (i = 0; i < rData.length; i++) {
            if (rData[i].quantityUsed == "0") {
                $(tablebody).append(AppUtil.ProcessTemplateData("RT_BOM-template", rData[i]));
            }
        }
        LoadStepPartsFromData(rData);
    }).catch((error) => {
    });

}

function onlyNum() {
    let qa = document.getElementById("QuantityAssembly");
    let qaval = qa.value;

    if (qaval != '') {
        if (isNaN(qaval)) {
            // Set input value empty
            qa.value = "";
            return false;
        } else {
            let iQaVal = parseInt(qaval);
            if (iQaVal < 0) {
                qa.value = "";
                return false;
            }

            return true
        }
    }
}

/**
 * 
 * 
 * @param {any} stepId
 * @param {any} stepNumber
 * @returns
 */

function getAndShowStep(stepId, stepNumber) {
    /*var relatedTarget = $(event.relatedTarget);
    var stepId = relatedTarget.data("stepId");
    var stepNumber = relatedTarget.data("stepNumber");*/
    let data = routingSteps;
    let step = {};
    for (i = 0; i < data.length; i++) {
        if (data[i]["stepId"] == stepId) {
            //console.log("******Found Data*******");
            step = data[i];
            //console.log(data[i]);
            //console.log("*************");
        }
    }
    document.getElementById("FormRoutingStep").reset();
    $('a[href="#rsd"]').tab("show");
    if (partType == "ManufacturedPart") {
        $("#tab-step-parts").hide();
    }
    LoadOperations();
    LoadLocations();
    $("#Status").val(step.status);
    $("#StepId").val(step.stepId);
    $("#StepRoutingId").val(step.routingId);
    $("#StepSequence").val(step.stepSequence);
    $("#NumberOfSimMachines").val(step.numberOfSimMachines);
    RoutingDetails["stepId"] = step.stepId;
    RoutingDetails["stepNumber"] = step.stepNumber;

    $("#StepNumber").val(step.stepNumber);
    $("#StepDescription").val(step.stepDescription);
    let id = step.stepOperation;
    //console.log("sso " + step.stepOperation + "/" + id);
    $("#StepOperation").val(id).trigger('change');
    id = step.stepLocation;
    //console.log("ssl " + step.stepLocation + "/" + id);
    $("#StepLocation").val(id).trigger('change');
    return false;
}

function getLocationId(val) {
    let data = locations;
    //console.log("Comparing..." + val);
    for (i = 0; i < data.length; i++) {
        //console.log("With..." + data[i].name + "/" + data[i].id);
        if (data[i].name == val) {
            return data[i].id;
        }
    }
    return 'NA';
}

function getOperationId(val) {
    let data = operations;
    //console.log("Comparing..." + val);
    for (i = 0; i < data.length; i++) {
        //console.log("With..." + data[i].operation + "/" + data[i].operationId);
        if (data[i].operation == val) {
            return data[i].operationId;
        }
    }
    return 'NA';
}

function loadStepMachines() {
    //debugger;
    var tablebody = $("#RouteMachinesTable tbody");
    $(tablebody).html("");//empty tbody
    let stepId = RoutingDetails["stepId"];
    //console.log("****stepId" + stepId);
    api.get("/routings/stepmachines?stepId=" + stepId).then((data) => {
        for (i = 0; i < data.length; i++) {
            data[i].bgColor = "white"
            data[i].strPreferedMachine = ""
            if (data[i].preferredMachine == 1) {
                data[i].bgColor = "#eee"
                data[i].strPreferedMachine = "Yes"
            }
            $(tablebody).append(AppUtil.ProcessTemplateData("RouteMachinesRowTemplate", data[i]));
        }
        //console.log("****loadStepMachines*****");
        //console.log(data);
        //console.log("*************");
        //console.log(tablebody.html());
        //RouteSuppliersTable
        //RouteSupplierTemplate
    }).catch((error) => {
    });
};

function SetPreferredMachine(event, routingStepId, routingStepMachineId) {
    //alert("Preferred machine" + ":" + routingStepId + "/" + routingStepMachineId);
    var maxMachineCount = $("#NumberOfSimMachines").val();
    api.get("/routings/preferredstepmachine?routingStepId=" + routingStepId + "&routingStepMachineId=" + routingStepMachineId + "&maxMachineCount=" + maxMachineCount).then((data) => {
        //console.log(data);
        //console.log("loadStepMachines..")
        loadStepMachines();
    }).catch((error) => {
    });
}
function EditRoute(routingId,routingName) {
    //alert("Todo..");
    RoutingDetails["routingName"] = routingName;
    RoutingDetails["routingId"] = routingId;
    RoutingDetails["stepNumber"] = "";
    DoRoutingDetailsJob();
    $('a[href="#rou-det"]').tab("show");
    //"#rou-det"
}
function ViewRoute() {
    //alert("Todo..");
}

function EditRoutes(event, noOfRoutes, manufacturedPartId) {
    if (noOfRoutes <= 0)
        return;
    selectedManuPartId = manufacturedPartId;
    window.location.href = "/routings/routingdetails?manufPartId=" + selectedManuPartId + "&partType=" + partType;
}





$(function () {
   // console.log("Ready");
    if (RoutingDetails) {
        partType = RoutingDetails['masterPartType'];
        if (partType == undefined) {
            partType = "ManufacturedPart";
        }
        if (partType == "") {
            partType = "ManufacturedPart";
        }
        //console.log("partType" + partType);
    }
    DowlonadPartsRoutings();
    //LoadBOMList(16);
    LoadOperations();
    LoadLocations();
    //======


   

    $("#CancelDelSubCon").click(function (event) {
        //routings/addnewrouting
        document.getElementById("BtnDelSubConClose").click();
    });

    $('#delete-subcon').on('hide.bs.modal', function (event) {
        if (!subcondeleted)
            return;
        LoadSubCons();
    });
    let subcondeleted = false;
    $("#BtnDelSubConSave").on("click", function (event) {
        //routings/addnewrouting
        var subcondetailsid = $("#DelSubConDetailsId").val();
        var stepid = $("#DelSubConStepId").val();
        api.get("/routings/deletesubcondetails?stepId=" + stepid + "&subConDetailsId=" + subcondetailsid).then((data) => {
           // console.log(data);
            subcondeleted = true;
            document.getElementById("BtnDelSubConClose").click();
        }).catch((error) => {
        });
    });
    $('#delete-subcon').on('show.bs.modal', function (event) {
        var relatedTarget = $(event.relatedTarget);
        var subcondetailsid = relatedTarget.data("subcondetailsid");
        var stepId = relatedTarget.data("stepid");
        var company = relatedTarget.data("company");
        $("#DelSubConDetailsId").val(subcondetailsid);
        $("#DelSubConStepId").val(stepId);
        var elm = document.getElementById("SubConToDelete");
        elm.innerText = company;
    });
    
    $('#add-subcon').on('hide.bs.modal', function (event) {
        //editSubCon = false;
        LoadSubCons();
    });
    $('#add-subcon').on('shown.bs.modal', function (event) {
        ShowAddSubConJob(event);
    });
 
    $('#WithoutRouting').change(function () {
        if (this.checked) {
            hasRouting = false;
        }
        hasRouting = true;
     //   DowlonadPartsRoutings();
    });

    $('#StepMachine').change(function () {
        //debugger;
        let selVal = $(this).val();
        var val = $('input[name=mod-12]:checked').val();
        alert(selVal + "/" + val);
        if (val == "2") {
            let data = stepMachines;
            //console.log(data);
            for (i = 0; i < data.length; i++) {
                if (selVal == data[i].routingStepMachineId) {
                    $("#SetupTime").val(data[i].setupTime);
                    $("#FloorToFloorTime").val(data[i].floorToFloorTime);
                    $("#FirstPieceProcessingTime").val(data[i].firstPieceProcessingTime);
                    $("#NoOfPartsPerLoading").val(data[i].noOfPartsPerLoading);
                    break;
                }
            }
        }
    });

    $('#StepLocation').change(function () {
        //debugger;
        let selVal = $(this).val();
        let selText = $(this).text();
        let machs = document.getElementById("Div_RouteMachines");
        let suplrs = document.getElementById("Div_RouteSubCons");
        $("#NumberOfSimMachines").hide();
        $("#lblNumberOfSimMachines").hide();
        if (partType == "ManufacturedPart") {
            $("#tab-step-parts").hide();
        }
        
        if (selVal == "1")//Inhouse
        {
            showElement(machs);
            hideElem(suplrs);
            //Div_RouteMachines show
            loadStepMachines()
            $("#NumberOfSimMachines").show();
            $("#lblNumberOfSimMachines").show();
        }
        else if (selVal == "2")//SubCon
        {
            //Div_RouteSuppliers show
            hideElem(machs);
            showElement(suplrs);
            //loadSetSuppliers();
            LoadSubCons();
        }
        else {
            hideElem(machs);
            hideElem(suplrs);
        }
        $("#addSubCon").prop("disabled", true);
        $("#addMachine").prop("disabled", true); 
    });

    /*const checkbox = document.getElementById('WithoutRouting')

    checkbox.addEventListener('change', (event) => {
        if (event.currentTarget.checked) {
            hasRouting = false;
            DowlonadPartsRoutings();
        } else {
            hasRouting = true;
            DowlonadPartsRoutings();
        }
    });*/

    $('#BtnSelectBOMForRouting').click(function (event) {
        SetOp("add");
        //if (IsAddOpCalled())
        {
            var bomId = $('input[name=BOMChk]:checked').val();
            var chkdelm = $('input[name=BOMChk]:checked');
            var currentrow = chkdelm.closest('tr');
            var partNo = currentrow.find("td:eq(1)").html();
            var partDesc = currentrow.find("td:eq(2)").html();
            var qty = currentrow.find("td:eq(4)").html();
            qtyAvailable = parseInt(qty);
            if (qtyAvailable <= 0) {
                alert("Quantity not available.");
                return;
            }
            $("#BOMId").val(bomId);
            $("#BOMPartNo").val(partNo);
            $("#BOMPartDescription").val(partDesc);
            $("#QuantityAssembly").val(qtyAvailable);
            SetAssemblyIds();
            //console.log("manufacturedPartId / BOMRoutingStepId / RoutingStepPartId: " + RoutingDetails.manufacturedPartId + "/" + $("#BOMRoutingStepId").val() + "/" + $("#RoutingStepPartId").val());
            //console.log(bomId + ":" + partNo + ":" + partDesc + ":" + qty);
        }
    });

    $('input[type=radio][name=RoutingChk]').change(function () {
        getRoutingInfoFromTable();
        $("#DivRoutingName").html("<h5>Routing Name : " + RoutingDetails.routingName + "</h5>");
        $("#DivRoutingName1").html("<h5>Routing Selected : " + RoutingDetails.routingName + "</h5>");
    });
    $("#RoutingAvailable").click(function (event) {

    });

   

    $("#RoutingDetails").click(function (event) {
        //DoRoutingDetailsJob(event);
    });

    $("#RoutingStepDetails").click(function (event) {
        if (partType == "ManufacturedPart") {
            $("#tab-step-parts").hide();
        }
        $("#tab-step-info").show();
        document.getElementById("FormRoutingStep").reset();
        hideMachinesSuppliersTable();
        //document.getElementById("FormRoutingStep").reset();
        /* RoutingDetails["stepId"] = -1;
         RoutingDetails["stepNumber"] = -1;*/
        emptyTables();
      //  getRoutingInfoFromTable();
        $("#BOMManufacturedPartId").val(RoutingDetails.manufacturedPartId);
        $('#StepRoutingId').val(RoutingDetails.routingId);
    });

   

    function setDialogTitles() {
        //stepModel
        //RoutingDetails
    };
    
    $("#tab-step-info").click(function (event) {
       /* document.getElementById("FormRoutingStep").reset();
        emptyTables();
        var routingid = $('input[name=RoutingChk]:checked').val();
        $('#StepRoutingId').val(routingid);
        hideMachinesSuppliersTable();*/
    });

    $("#tab-step-parts").click(function (event) {

        if ($("#StepId").val() == "0") {
            alert("Please save step info to proceed further.");
            event.preventDefault();
            return;
        }
        else {
            LoadBOMList($("#StepId").val());
        }
    });
    
    
    
    $("#master_partno").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#PartsRoutingsTable tbody tr").filter(function () {
            $(this).toggle($(this.children[0]).text().toLowerCase().indexOf(value) > -1)
        });
    });

    $("#master_description").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#PartsRoutingsTable tbody tr").filter(function () {
            $(this).toggle($(this.children[1]).text().toLowerCase().indexOf(value) > -1)
        });
    }); 
    
    $("#master_co").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#PartsRoutingsTable tbody tr").filter(function () {
            $(this).toggle($(this.children[2]).text().toLowerCase().indexOf(value) > -1)
        });
    });
    


    $('input[type=radio][name=MasterPartType]').change(function () {
        if (this.value == "1") {
            // alert("one clicked");
            partType = "ManufacturedPart";
            spartType = "ManufacturedPart";
            DowlonadPartsRoutings();
            $("#MakefromDiv").show();
        } else {
            partType = "Assembly";
            DowlonadPartsRoutings();
            $("#MakefromDiv").hide();
        }

    });
    $('input[type=radio][name=WithRouting]').change(function () {
        if (this.value == "1") {
            //  alert("three clicked");
            //      loadBOFs();
            withRouting = true;
            DowlonadPartsRoutings();
        } else {
            //  alert("four clicked");
            //     loadSupplierRMS();
            withRouting = false;
            DowlonadPartsRoutings();
        }

    });
    

    $('#preferred-rout').on('show.bs.modal', function (event) {
        var relatedTarget = $(event.relatedTarget);
        var routingid = relatedTarget.data("routingid");
        var origroutingid = relatedTarget.data("origroutingid");
        var manufacturedPartId = relatedTarget.data("manufid");
        var routingName = relatedTarget.data("routingname");
        selectedManuPartId = manufacturedPartId;
        $("#PManufacturedPartId").val(manufacturedPartId);
        $("#PRoutingName").val(routingName);
        $("#PRoutingId").val(routingid);
        $("#POrigRoutingId").val(origroutingid);
    });
    $('#preferred-rout').on('hide.bs.modal', function (event) {
        window.location.href = "/routings/routingdetails?manufPartId=" + selectedManuPartId;
    });

    //
    //<a href="javascript:void(0);"
    //data - routingName="@routing.RoutingName"
    //data - manufid="@routing.ManufacturedPartId"
    //data - origroutingid="@routing.OrigRoutingId"
    //data - routingid="@routing.RoutingId"
    //data - preferredrouting="@routing.PreferredRouting"
    //data - status="@routing.Status" data - toggle="modal"
    //data - target="#delete-rout" class="dropdown-item" > Delete</a >
    //<input hidden class="form-control form-control-sm" id="DelRoutingName" name="RoutingName" type="text" title="Enter the Routing Name ... It has to be Unique" data-plugin="tippy" data-tippy-placement="top">
        //<input type="text" hidden id="DelManufacturedPartId" name="ManufacturedPartId" value="0" />
        //<input type="text" hidden id="DelOrigRoutingId" name="OrigRoutingId" value="0" />
        //<input type="text" hidden id="DelStatus" name="Status" value="Active" />
        //<input type="text" hidden id="DelPreferredRouting" name="PreferredRouting" value="0" />
        //<input type="text" hidden id="DelRoutingId" name="RoutingId" value="0" />
    $('#delete-rout').on('show.bs.modal', function (event) {
        var relatedTarget = $(event.relatedTarget);
        var routingName = relatedTarget.data("routingname");
        var manufid = relatedTarget.data("manufid");
        var origroutingid = relatedTarget.data("origroutingid");
        var routingid = relatedTarget.data("routingid");
        var preferredrouting = relatedTarget.data("preferredrouting");
        var status = relatedTarget.data("status");
        var elm = document.getElementById("RoutingToDelete");
        elm.innerText = routingName;
        //OrigRoutingId
        //PreferredRouting
        //Status
        selectedManuPartId = manufid;
        $("#DelRoutingName").val(routingName);
        $("#DelManufacturedPartId").val(manufid);
        $("#DelOrigRoutingId").val(origroutingid);

        $("#DelStatus").val(status);
        $("#DelRoutingId").val(routingid);
        $("#DelPreferredRouting").val(preferredrouting);
    });
    $('#delete-rout').on('hide.bs.modal', function (event) {
        if (!routdeleted)
            return;
        window.location.href = "/routings/routingdetails?manufPartId=" + selectedManuPartId;
    });
    let routdeleted = false;
    $("#BtnDelRoutingSave").on("click",function (event) {
        //routings/addnewrouting
        var formData = AppUtil.GetFormData("FormDelRoutingName");
        var routingId = $("#DelRoutingId").val();
        alert(routingId);
        api.get("/routings/deleterouting?routingId="+routingId).then((data) => {
           // console.log(data);
            routdeleted = true;
            document.getElementById("BtnDelRoutingClose").click();
        }).catch((error) => {
            AppUtil.HandleError("FormDelRoutingName", error);
        });
    });
    $("#CancelDelRouting").click(function (event) {
        //routings/addnewrouting
        document.getElementById("BtnDelRoutingClose").click();
    });
    

    $('#delete-step').on('show.bs.modal', function (event) {
        var relatedTarget = $(event.relatedTarget);
        var stepId = relatedTarget.data("stepid");
        var stepName = relatedTarget.data("stepnumber");
        var elm = document.getElementById("StepToDelete");
        elm.innerText = stepName + "/" + stepId;

        $("#DeleteStepId").val(stepId);
    });
    $('#delete-step').on('hide.bs.modal', function (event) {
        if (!stepdeleted)
            return;
        selectedManuPartId = RoutingDetails.manufacturedPartId;
        window.location.href = "/routings/routingdetails?manufPartId=" + selectedManuPartId;
    });

    let stepdeleted = false;
    $("#BtnDeleteStep").click(function (event) {
        //routings/addnewrouting
        var stepId = document.getElementById("DeleteStepId").value;
        var formData = AppUtil.GetFormData("FormDeleteStep");
        api.get("/routings/deletestep?stepId=" + stepId).then((data) => {
            stepdeleted = true;
            document.getElementById("BtnDeleteStepClose").click();
        }).catch((error) => {
        });
    });

    $("#CancelDeleteStep").click(function (event) {
        //routings/addnewrouting
        document.getElementById("BtnDeleteStepClose").click();
    });

    $('#edit-routingname').on('show.bs.modal', function (event) {
        var relatedTarget = $(event.relatedTarget);
        var routingName = relatedTarget.data("routingname");
        var origroutingid = relatedTarget.data("origroutingid");
        var routingid = relatedTarget.data("routingid");
        var preferredrouting = relatedTarget.data("preferredrouting");
        var status = relatedTarget.data("status");
        var elm = document.getElementById("RoutingToEdit");
        elm.innerText = routingName;
        var manufid = relatedTarget.data("manufid");
        selectedManuPartId = manufid;
        $("#EdRoutingName").val(routingName);
        $("#EdManufacturedPartId").val(manufid);
        $("#EdOrigRoutingId").val(origroutingid);

        $("#EdStatus").val(status);
        $("#EdPreferredRouting").val(preferredrouting);
        $("#EdRoutingId").val(routingid);
    });
    $('#edit-routingname').on('hide.bs.modal', function (event) {
        if (!routeEdited)
            return;
        window.location.href = "/routings/routingdetails?manufPartId=" + selectedManuPartId;
    });
    let routeEdited = false;
    $("#BtnEdRoutingNameSave").click(function (event) {
        //routings/addnewrouting
        var formData = AppUtil.GetFormData("FormEdRoutingName");
        api.post("/routings/addnewrouting", formData).then((data) => {
           // console.log(data);
            routeEdited = true;
            document.getElementById("BtnEdRoutingNameClose").click();
        }).catch((error) => {
            AppUtil.HandleError("FormEdRoutingName", error);
        });
    });
    $("#CancelEdRoutingName").click(function (event) {
        //routings/addnewrouting
        document.getElementById("BtnEdRoutingNameClose").click();
    });

    $('#alt-rout').on('show.bs.modal', function (event) {
        var relatedTarget = $(event.relatedTarget);
        var routingid = relatedTarget.data("routingid");
        var manufacturedPartId = relatedTarget.data("manufid");
        selectedManuPartId = manufacturedPartId;
        $("#AltManufacturedPartId").val(manufacturedPartId);
        $("#AltOrigRoutingId").val(routingid);
    });
    //$('#alt-rout').on('hide.bs.modal', function (event) {
    //    window.location.href = "/routings/routingdetails?manufPartId=" + selectedManuPartId;
    //});
    
    //$('#routing-new').on('hide.bs.modal', function (event) {
    //    document.getElementById("BtnNewRoutingClose").click();
    //});

    

    $('#routing-new').on('show.bs.modal', function (event) {
        var relatedTarget = $(event.relatedTarget);
        var manufacturedPartId = relatedTarget.data("manufacturedpartid");
        $("#ManufacturedPartId").val(manufacturedPartId);
        selectedManuPartId = manufacturedPartId;
        //makefrom --
        if (spartType === "ManufacturedPart") {
            api.get("/masters/SortedMPMakeFromList?partId=" + selectedManuPartId).then((data) => {
                var sortedMPF = data;
                //console.log(sortedMPF);
                const uniqueMPF = [...new Set(sortedMPF.map(mpm => mpm.mpPartId))].map(mpPartId => {
                    return sortedMPF.find(mpm => mpm.mpPartId === mpPartId);
                });
                $("#MKPartId").empty();
                uniqueMPF.forEach(function (mpm) {
                    $("#MKPartId").append("<option value='" + mpm.mpPartId + "'  name='MKPartId'>" + mpm.inputPartNo + " / " + mpm.mfDescription + "</option>");
                });
            }).catch((error) => {
                AppUtil.HandleError("", error);
            });
        }
     /* var partNo = relatedTarget.data("partno");
        var coName = relatedTarget.data("companyname");
        var partDesc = var partNo = relatedTarget.data("partdescription");
        $("#NRPartNo").val(partNo);
        $("#NRCompanyName").val(coName);
        $("#NRPartDescription").val(partDesc);*/
        //<a href="javascript:void(0);" data-manufacturedPartId="{manufacturedPartId}" 
        //data - partno="{partNo}" data - companyname="{companyName}" data - partdescription="{partDescription}" data - toggle="modal" 
        //data - target="#routing-new" class="dropdown-item" > Create New Routing</a >
    });

    $("#BtnNewRouting").click(function (event) {
        //FormNewRoutingName
        //FormAltRoutingName
        //FormRoutingStep
        //FormStepPart
        var formData = AppUtil.GetFormData("FormNewRoutingName");
        api.post("/routings/addnewrouting", formData).then((data) => {
            //console.log(data);
            window.location.href = "/routings/routingdetails?manufPartId=" + selectedManuPartId;
        }).catch((error) => {
            AppUtil.HandleError("FormNewRoutingName", error);
        });
    });
    
    $("#BtnPRoutingSave").click(function (event) {
        //routings/addnewrouting
        var formData = AppUtil.GetFormData("FormPreferredRouting");
        //PreferredRouting
        api.post("/routings/preferredrouting", formData).then((data) => {
            //console.log(data);
            document.getElementById("BtnPreferredRoutingClose").click();
        }).catch((error) => {
            AppUtil.HandleError("FormPreferredRouting", error);
        });
    });

    $("#BtnAltRoutingSave").click(function (event) {
        //routings/addnewrouting
        var formData = AppUtil.GetFormData("FormAltRoutingName");
        api.post("/routings/altrouting", formData).then((data) => {
            //console.log(data);
            document.getElementById("BtnAltRoutingClose").click();
        }).catch((error) => {
            AppUtil.HandleError("FormAltRoutingName", error);
        });
    });

    
    
    ////SubConWSSubConDetailsId//SubConWSRoutingStepId//SubConWSDetailsId //WorkStepDesc//MachineType//FloorToFloorTime//SetupTime//NoOfPartsPerLoading
    $('#add-machine').on('shown.bs.modal', function (event) {
        if ($("#StepId").val() == "0") {
            alert("Save routing step before adding machine.");
            document.getElementById("Add-Machine-Close").click();
        }
        $.ajax({           
            success: function (data) {
                AddMacOptions();
            }
        });
        document.getElementById("FormRoutingMachine").reset();
        var rTgt = $(event.relatedTarget);
        var addEdit = rTgt.data("addedit");

        var tablebody = $("#TitleTableMachine tbody");
        tablebody.html("");
        $(tablebody).append(AppUtil.ProcessTemplateData("TitleRowMachine", RoutingDetails));
        if (addEdit == "Add") {
            $("#MachineRoutingStepId").val(RoutingDetails["stepId"]);
        }
        else {
            //console.log("-------------");
            //console.log(rTgt.data("setuptime"));
            $("#SetupTime").val(rTgt.data("setuptime"));
            //console.log(rTgt.data("floortofloortime"));
            $("#FloorToFloorTime").val(rTgt.data("floortofloortime"));
            //console.log(rTgt.data("firstpieceprocessingtime"));
            //console.log("-------------");
            $("#FirstPieceProcessingTime").val(rTgt.data("firstpieceprocessingtime"));
            $("#NoOfPartsPerLoading").val(rTgt.data("noofpartsperloading"));
            $("#PreferredMachine").val(rTgt.data("preferredmachine"));
            $("#MachineId").val(rTgt.data("machineid"));
            $("#MachineRoutingStepId").val(rTgt.data("machineroutingstepid"));//maps to StepId
            $("#RoutingStepMachineId").val(rTgt.data("routingstepmachineid"));//maps to Id
        }
        //debugger;
        //RoutingStepMachineId
        //SetupTime//FloorToFloorTime//FirstPieceProcessingTime//
        //NoOfPartsPerLoading//PreferredMachine//MachineId
        //MachineRoutingStepId
        //RoutingStepMachineId
        loadStepMachinesForAdd();
        loadMachinesToTable("AddMachineListTable", "AddMachineListRow");

        if ($("#stepmachine_1").length) {
            $("#stepmachine_1").prop('checked', true);
        }

    });
    //Routing Step Details Filter/Search
    $("#MAC_Plants").change(function () {
        var value = $(this).find("option:selected").text().toLowerCase();
        $("#AddMachineListTable tbody tr").filter(function () {
            $(this).toggle($(this.children[1]).text().toLowerCase().indexOf(value) > -1)
        });
    });

    $("#MAC_Shops").change(function () {
        var value = $(this).find("option:selected").text().toLowerCase();
        $("#AddMachineListTable tbody tr").filter(function () {
            $(this).toggle($(this.children[2]).text().toLowerCase().indexOf(value) > -1)
        });
    });

    $("#MAC_Name").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#AddMachineListTable tbody tr").filter(function () {
            $(this).toggle($(this.children[4]).text().toLowerCase().indexOf(value) > -1)
        });
    });

    //$("#MAC_Type").change(function () {
    //    var value = $(this).find("option:selected").text().toLowerCase();
    //    $("#AddMachineListTable tbody tr").filter(function () {
    //        $(this).toggle($(this.children[4]).text().toLowerCase().indexOf(value) > -1)
    //    });
    //});
    //end---

    $('#delete-machine').on('show.bs.modal', function (event) {
        var relatedTarget = $(event.relatedTarget);
        var machineId = relatedTarget.data("routingstepmachineid");
        var stepId = relatedTarget.data("stepid");
        $("#DelMachineStepId").val(stepId);
        $("#DelMachineId").val(machineId);
        var machinename = relatedTarget.data("machinename");
        var elm = document.getElementById("MachineToDelete");
        elm.innerText = machinename;
        //$("#DelRoutingId").val();
    });
    $("#BtnDelStepMachine").on("click",function (event) {
        var machineId = $("#DelMachineId").val();
        var stepId = $("#DelMachineStepId").val();
        alert(machineId + "/" + stepId);
        api.get("/routings/deletemachine?stepId=" + stepId + "&machineId=" + machineId).then((data) => {
            //console.log(data);
            //console.log(tablebody.html());
            //RouteSuppliersTable
            //RouteSupplierTemplate
            loadStepMachines();
            document.getElementById("BtnDelMachineClose").click();
        }).catch((error) => {
        });
    });
    $("#CancelDelStepMachine").on("click",function (event) {
        //BtnDelMachineClose
        document.getElementById("BtnDelMachineClose").click();
    });

    $("#RoutingAvailable").on("click", function (event) {
        //BtnDelMachineClose
        $('a[href="#rs2"]').tab("show");
    });
    $("#RoutingDetails").on("click", function (event) {
        //BtnDelMachineClose
        if ($('.nav-tabs .active').text().trim() == "RoutingDetails") {
            event.preventDefault();
            return;
        }
        $('a[href="#rs2"]').tab("show");
    });
    $("#RoutingStepDetails").on("click", function (event) {
        if ($('.nav-tabs .active').text().trim() == "RoutingStepDetails") {
            event.preventDefault();
            return;
        }
        $('a[href="#rs2"]').tab("show");
    });

    $('#delete-supplier').on('show.bs.modal', function (event) {
        var relatedTarget = $(event.relatedTarget);
        var machineId = relatedTarget.data("routingstepsupplierid");
        var stepId = relatedTarget.data("stepid");
        var suppliername = "NA";
        var elm = document.getElementById("SupplierToDelete");
        elm.innerText = suppliername;
        //OrigRoutingId
        //PreferredRouting
        //Status
    });

    

    $("#BtnDelStepSupplier").click(function (event) {

    });

    $("#CancelDelStepSupplier").click(function (event) {
        //BtnDelMachineClose
        document.getElementById("BtnDeleteSupplierClose").click();
    });

    $("body").on("change","input[type=radio][name=RadioSubConName]",function () {
        var chkdelm = $('input[name=RadioSubConName]:checked');
        var currentrow = chkdelm.closest('tr');
        var supplierId = chkdelm.val();
        var supplierName = currentrow.find("td:eq(1)").html();
        $("#SubConSupplierId").val(supplierId);
        $("#subconname").text(supplierName);
        //$("#SubConSupplier").val(supplierName);
    });
    
    $('input[type=radio][name=stepsupplierselect]').change(function () {
        var chkdelm = $('input[name=stepsupplierselect]:checked');
        var currentrow = chkdelm.closest('tr');
        var supplierId = $('input[name=stepsupplierselect]:checked').val();
        var supplierName = currentrow.find("td:eq(1)").html();
        $("#SupplierId").val(supplierId);
        $("#Supplier").val(supplierName);
    });

    $('input[type=radio][name=stepmachineselect]').change(function () {
        var chkdelm = $('input[name=stepmachineselect]:checked');
        var currentrow = chkdelm.closest('tr');
        var machineId = $('input[name=stepmachineselect]:checked').val();
        var machinename = currentrow.find("td:eq(4)").html();
        $("#MachineId").val(machineId);
    });
    $("#SaveSubCon").on("click", function (event) {
        //alert("Add SubCons");
        AddSubCon();
    });
    $("#SaveSubConWS").on("click", function (event) {
        //alert("Add SubConsWS");
        let wsid = $("#SubConWSSubConDetailsId").val();
        let stepid = $("#SubConWSRoutingStepId").val();
        if (wsid == "0" || stepid == "0") {
            alert("Please save subcon before entering the work step details.");
            return;
        }
        AddSubConWS();
    });

    $("#SaveRouteSupplier").click(function (event) {
        var chkdelm = $('input[name=stepsupplierselect]:checked');
        var currentrow = chkdelm.closest('tr');
        var supplierId = $('input[name=stepsupplierselect]:checked').val();
        var supplierName = currentrow.find("td:eq(1)").html();
        $("#SupplierId").val(supplierId);
        $("#Supplier").val(supplierName);
        //SupplierRoutingStepId
        //Supplier
        //SupplierId
        //stepsupplierselect
        //alert("Save route supplier");
        //routings/addnewrouting
        

        var formData = AppUtil.GetFormData("FormRoutingSupplier");
        api.post("/routings/savestepsupplier", formData).then((data) => {
            //console.log(data);
            loadSetSuppliers();
            document.getElementById("Add-Supplier-Close").click();
        }).catch((error) => {
            AppUtil.HandleError("FormRoutingSupplier", error);
        });
        event.preventDefault();
    });



    $("#SaveRouteMachine").click(function (event) {
        alert("Save route Machine");
        var chkdelm = $('input[name=stepmachineselect]:checked');
        var currentrow = chkdelm.closest('tr');
        var machineId = $('input[name=stepmachineselect]:checked').val();
        var machinename = currentrow.find("td:eq(4)").html();
        $("#MachineId").val(machineId);
        var formData = AppUtil.GetFormData("FormRoutingMachine");
        api.post("/routings/savestepmachine", formData).then((data) => {
            //console.log(data);
            loadStepMachines();
            document.getElementById("Add-Machine-Close").click();
        }).catch((error) => {
            AppUtil.HandleError("FormRoutingMachine", error);
        });
        event.preventDefault();
    });



    $("#BtnSaveStep").click(function (event) {
        //routings/addnewrouting
        var formData = AppUtil.GetFormData("FormRoutingStep");
        api.post("/routings/savestep", formData).then((data) => {
            stepModel = data;
            RoutingDetails["stepNumber"] = data["stepNumber"];
            RoutingDetails["stepId"] = data["stepId"];
            //console.log("====1=====");
            //console.log(data);
            //console.log("====1-End=====");
            $("#StepId").val(data.stepId);
            $("#BOMRoutingStepId").val(data.stepId);
            document.getElementById('addMachine').removeAttribute('disabled');
            document.getElementById('addSubCon').removeAttribute('disabled');
        }).catch((error) => {
            AppUtil.HandleError("FormRoutingStep", error);
        });
        event.preventDefault();
    });

    $("#BtnAddToStepList").on('click',function (event) {
        var qtyEntered = parseInt($("#QuantityAssembly").val());
        if (qtyEntered > qtyAvailable) {
            alert("Quantity not available.-2");
            return;
        }
        if (qtyEntered <= 0) {
            alert("Quantity not available.");
            return;
        }
        var formData = AppUtil.GetFormData("FormStepPart");
        api.post("/routings/addBomtoassembly", formData).then((data) => {
            //console.log(data);
            LoadBOMList(data.routingStepId);
            //LoadStepParts(data.manufacturedPartId,data.routingStepId);
            document.getElementById("FormStepPart").reset();
            SetAssemblyIds();
        }).catch((error) => {
            AppUtil.HandleError("FormStepPart", error);
        });
        event.preventDefault();
    });


    $("#BtnAddNextStep").click(function (event) {
        //routings/addnewrouting
        //alert("next step... todo...");
        document.getElementById("FormRoutingStep").reset();
        hideMachinesSuppliersTable();
        //getRoutingInfoFromTable();
        $('#StepRoutingId').val(RoutingDetails.routingId);
        $('a[href="#rsd"]').tab("show");
        //"#rou-det"
        if (partType == "ManufacturedPart") {
            $("#tab-step-parts").hide();
        }
    });

});

