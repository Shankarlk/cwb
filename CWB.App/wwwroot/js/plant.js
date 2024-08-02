
function LoadHolidays(plantId) {
    var tablebody = $("#HolidaysTable tbody");
    $(tablebody).html("");//empty tbody
    api.get("/plant/getholidays?plantId=" + plantId).then((data) => {
        //console.log(data);
        for (i = 0; i < data.length; i++) {
           $(tablebody).append(AppUtil.ProcessTemplateDataNew("HolidayRow", data[i], i));
        }
    }).catch((error) => {
        //console.log(error);
    });
}
/*
"holidayId": 0,
    "plantId": 0,
    "name": "string",
    "holidayDate": "2024-04-22T19:27:49.041Z",
*/

function EditHoliday(holidayId, name, holiDayDateStr, day) {
    //console.log("holidayId : "+holidayId);
    $("#HolidayId").val(holidayId);
    $("#HName").val(name);
    document.getElementById("HolidayDate").value = holiDayDateStr.split("-").reverse().join("-");;
}

function DeleteHoliday(holidayId,name,plantId) {
    var result = confirm("Are you sure you want to delete "+name+" from holiday list?");
    if (result) {
        api.get("/plant/delholiday?holidayId=" + holidayId).then((data) => {
            //console.log(data);
            var plantId = $("HolidayPlantId").val();
            LoadHolidays(plantId);
        }).catch((error) => {
        });
    }
}
function AddHolidayToList() {
    var formData = AppUtil.GetFormData("HolidayForm");
    api.post("/plant/plantholiday", formData).then((data) => {
        var plantId = $("#HolidayPlantId").val();
        LoadHolidays(plantId);
        $("#HolidayId").val("0");
        $("#HName").val("");
    }).catch((error) => {
        AppUtil.HandleError("HolidayForm", error);
    });
}

function GetPlantWD(plantId) {
    api.get("/plant/getplantwd?plantId=" + plantId).then((data) => {
        //console.log(data);
        $("#WDId").val(data.wdId);
        $("#WeeklyOff1").val(data.weeklyOff1);
        $("#WeeklyOff2").val(data.weeklyOff2);
        $("#NoOfShifts").val(data.noOfShifts);
        $("#FirstShiftStartTime").val(data.firstShiftStartTime);
        $("#SecondShiftStartTime").val(data.secondShiftStartTime);
        $("#ThirdShiftStartTime").val(data.thirdShiftStartTime);
        $("#FirstShiftDuration").val(data.firstShiftDuration);
        $("#SecondShiftDuration").val(data.secondShiftDuration);
        $("#ThirdShiftDuration").val(data.thirdShiftDuration);
    }).catch((error) => {
        //console.log(error);
    });
}

function AddWorkingDetails() {
    var formData = AppUtil.GetFormData("WDForm");
    api.post("/plant/plantwd", formData).then((data) => {
        //console.log(data);
        $("#WDId").val(data.wdId);
        $("#WDPlantId").val(data.plantId);
        //document.getElementById("WDForm").reset();
    }).catch((error) => {
        AppUtil.HandleError("WDForm", error);
    });
}

function LoadPlants() {
    var tablebody = $("#PlantTable tbody");
    $(tablebody).html("");//empty tbody
    //PlantRowTemplate
    //PlantTable
    api.getbulk("/plant/getplants").then((data) => {
        //console.log(data);
        for (i = 0; i < data.length; i++) {
            for (var key in data[i]) {
                //        console.log(key);
                //      console.log(data[i][key]);
                //    console.log("*****");
            }
            //console.log("================");
           $(tablebody).append(AppUtil.ProcessTemplateDataNew("PlantRowTemplate", data[i], i));

            //var plantID = data[i].plantId;
            //api.get("/plant/getplantwd?plantId=" + plantID).then((data) => {
            //    console.log(data);
            //    WorkDetails.push(data);
            //}).catch((error) => {
            //    console.log('Error occurred:', error.message);
            //});
        }
       
    }).catch((error) => {
    });
};

function DelPlant(name, plantId) {
    let confirmval = confirm("Are your sure you want to delete this plant? : " + name, "Yes", "No");
    if (confirmval) {
        api.get("/plant/delplant?plantId=" + plantId).then((data) => {
            //console.log(data);
            LoadPlants();
        }).catch((error) => {
            //console.log(error);
        });
    }
};
$(function () {

    //address: "test"
    //isMainPlant: true
    //isProductDesigned: true
    //name: "test"
    //notes: "test"
    //plantId: 1
    //tenantId: 1
    //shop-details
    $("#GEN").on("click", function(){
        $("#tab-001").show();
        $("#tab-002").hide();
        $("#tab-003").hide();
    });
    $("#PWD").on("click", function(){
        $("#tab-001").hide();
        $("#tab-002").show();
        $("#tab-003").hide();
    });
    $("#HLI").on("click", function(){
        $("#tab-001").hide();
        $("#tab-002").hide();
        $("#tab-003").show();
    });
    $('#shop-details').on('shown.bs.modal', function (event) {

        if (IsAddOpCalled()) {
            document.getElementById("PlantForm").reset();
            document.getElementById("WDForm").reset();
            document.getElementById("HolidayForm").reset();
            $("#WDPlantId").val("0");
            $("#HolidayPlantId").val("0");
            $("#HolidayId").val("0");
            $("#WDId").val("0");
            var tablebody = $("#HolidaysTable tbody");
            $(tablebody).html("");
            return;
        }
        $("#GEN").show();
        $("#tab-001").show();
        $("#tab-002").hide();
        $("#tab-003").hide();
        var relatedTarget = $(event.relatedTarget);
        var address = relatedTarget.data("address");
        $("#Address").val(address);
        var isMainPlant = relatedTarget.data("ismainplant");
        var isProductDesigned = relatedTarget.data("isproductdesigned");
        //IsProductDesigned
        //IsMainPlant
        $("#IsMainPlant").prop('checked', false);
        if (isMainPlant) {
            $("#IsMainPlant").prop('checked',true);
        }
        $("#IsProductDesigned").prop('checked', false);
        if (isProductDesigned) {
            $("#IsProductDesigned").prop('checked', true);
        }

        var name = relatedTarget.data("name");
        $("#Name").val(name);
        var notes = relatedTarget.data("notes");
        $("#Notes").val(notes);
        var plantId = relatedTarget.data("plantid");
        //console.log("PlantId " + plantId);
        $("#PlantId").val(plantId);
        $("#WDPlantId").val(plantId);
        $("#HolidayPlantId").val(plantId);
        var elm = document.getElementById("plantname");
        elm.innerText = name;
        LoadHolidays(plantId);
        GetPlantWD(plantId);
        
    });

    $('#shop-details').on('hide.bs.modal', function (event) {
        document.getElementById("PlantForm").reset();
        document.getElementById("WDForm").reset();
        document.getElementById("HolidayForm").reset();
        document.getElementById("plantname").innerHTML = '';
    });

    $("#docname").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#PlantTable tbody tr").filter(function () {
            $(this).toggle($(this.children[0]).text().toLowerCase().indexOf(value) > -1)
        });
    });

    //SaveWorkDetails
    //AddHoliday
    $("#SaveWorkDetails").on('click', function (event) {
        AddWorkingDetails();
        $("#btn-shopdetails-close").prop('disabled', false);
    });
    $("#AddHoliday").on('click', function (event) {
        AddHolidayToList();
    });

    $("#btn-shopdetails-close").on('click', function (event) {
             LoadPlants();
    });
    
    $("#BtnSavePlant").on('click',function (event) {
        var formData = AppUtil.GetFormData("PlantForm");
        api.post("/plant/plant", formData).then((data) => {
           // console.log(data);
           //document.getElementById("btn-shopdetails-close").click();
            //document.getElementById("PlantForm").reset();
            var wd = $("#WDPlantId").val();
            if (wd === "0") {
                $("#btn-shopdetails-close").prop('disabled', true);
            } else {
                $("#btn-shopdetails-close").prop('disabled', false);
            }
            var plantID = data.plantId;
            $("#WDPlantId").val(plantID);
            $("#HolidayPlantId").val(plantID);
            alert("Please Save the Work Details !");
            $("#tab-002").show();
            $("#tab-001").hide();
        }).catch((error) => {
            AppUtil.HandleError("PlantForm", error);
        });
    });
   
    LoadPlants();
});
