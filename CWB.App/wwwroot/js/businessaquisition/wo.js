function loadSO() {
    api.getbulk("/businessaquisition/AllSalesOrders").then((data) => {
        var tablebody = $("#SalesOrders1 tbody");
        $(tablebody).html("");//empty tbody
        console.log(data);
        for (i = 0; i < data.length; i++) {
            $(tablebody).append(AppUtil.ProcessTemplateData("SalesOrderRow1", data[i]));
        }
    }).catch((error) => {
    });
}

function loadWO() {
    api.getbulk("/businessaquisition/AllWorkOrders").then((data) => {
        var tablebody = $("#WorkOrder tbody");
        $(tablebody).html("");//empty tbody
        console.log(data);
        for (i = 0; i < data.length; i++) {
            $(tablebody).append(AppUtil.ProcessTemplateData("WorkOrderRow", data[i]));
        }
    }).catch((error) => {
    });
}
$(function () {
    loadSO();
    $("#btnAG").on("click", function () {
        var checkboxes = $("#SalesOrders1 input[type='checkbox']:checked"); // Select only checked checkboxes
        var selectedRowsData = {};
        var partIdMap = {};
        var SalesorderId = [];
        var WoSoRel = [];
        var WoSOMethod = {};

        checkboxes.each(function (index, checkbox) {
            var row = checkbox.parentNode.parentNode;
            var rowData = {
                salesOrderId: parseInt($(row).find("td:eq(0)").text()),
                wonumber: "",
                partId: parseInt($(row).find("td:eq(2)").text()),
                partType: 0,
                partlevel: 0,
                calcWOQty: parseInt($(row).find("td:eq(7)").text()),
                planCompletionDate: $(row).find("td:eq(11)").text()
                // Add other fields as needed
            };

            // Group by PartId
            if (partIdMap[rowData.partId]) {
                partIdMap[rowData.partId].calcWOQty += rowData.calcWOQty;
                SalesorderId.push([rowData.partId, rowData.salesOrderId]);
                let currentDate = new Date(rowData.planCompletionDate);
                let storedDate = new Date(partIdMap[rowData.partId].planCompletionDate);
                if (currentDate < storedDate) {
                    partIdMap[rowData.partId].planCompletionDate = rowData.planCompletionDate;
                    partIdMap[rowData.partId].salesOrderId = rowData.salesOrderId;
                }
            } else {
                partIdMap[rowData.partId] = rowData;
                SalesorderId.push([rowData.partId, rowData.salesOrderId]);
            }
        });

        selectedRowsData = Object.values(partIdMap);

        console.log(selectedRowsData);

        if (selectedRowsData.length === 1) {
            // Single checkbox selected, post to WOpost
            api.post("/businessaquisition/WOpost", selectedRowsData[0]).then((data) => {
                // Handle success if needed
                loadWO();
                SalesorderId.forEach(function (arr, outerIndex) {
                    arr.forEach(function (ele, i) {
                        if (ele === data.partId) {
                            //WoSoRel.push([arr[i+1], data.woid]);
                            WoSoRel.push({
                                workOrderId: data.woid,
                                salesOrderId: arr[i + 1]
                            });
                        }
                    });
                });
                console.log(WoSoRel);
                WoSOMethod = Object.values(WoSoRel);
                $.ajax({
                    type: "POST",
                    url: '/BusinessAquisition/PostWoSoRel',
                    contentType: "application/json; charset=utf-8",
                    headers: { 'Content-Type': 'application/json' },
                    data: JSON.stringify(WoSOMethod),
                    dataType: "json",
                    success: function (result) {
                        window.locationre = result.url;
                    }
                });
                console.log(WoSOMethod);
            }).catch((error) => {
                AppUtil.HandleError("WOForm", error);
            });

        } else if (selectedRowsData.length > 1) {
            // Multiple checkboxes selected, post to MultiWOpost
            console.log("-- multiplepostwo");

            $.ajax({
                type: "POST",
                url: '/BusinessAquisition/MultipleWOPost',
                contentType: "application/json; charset=utf-8",
                headers: { 'Content-Type': 'application/json' },
                data: JSON.stringify(selectedRowsData),
                dataType: "json",
                success: function (result) {
                    //alert(result);
                    result.forEach(function (a,i) {
                        SalesorderId.forEach(function (arr, outerIndex) {
                            arr.forEach(function (ele, ind) {
                                if (ele === a.partId) {
                                    WoSoRel.push({
                                        workOrderId: a.woid,
                                        salesOrderId: arr[ind + 1]
                                    });
                                }
                            });
                        });
                    });
                    console.log(WoSoRel);
                    WoSOMethod = Object.values(WoSoRel);
                    //--
                    $.ajax({
                        type: "POST",
                        url: '/BusinessAquisition/PostWoSoRel',
                        contentType: "application/json; charset=utf-8",
                        headers: { 'Content-Type': 'application/json' },
                        data: JSON.stringify(WoSOMethod),
                        dataType: "json",
                        success: function (result) {
                            window.locationre = result.url;
                        }
                    });
                    //--
                    window.locationre = result.url;
                    loadWO();
                }
            });

            //api.post("/businessaquisition/MultipleWOPost", Js).then((data) => {
            //api.post("/businessaquisition/MultipleWOPost?listworkOrdersVM="+ JSON.stringify(selectedRowsData)).then((data) => {
            // Handle success if needed
            // }).catch((error) => {
            //   AppUtil.HandleError("WOForm", error);
            //});
        } else {
            alert("Please select at least one row by checking the checkbox.");
        }
    });
});