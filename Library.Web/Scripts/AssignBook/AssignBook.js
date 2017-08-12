

//Search starts here
function StartSearch(FilterData) {
    var Criteria = PrepareSearchObject(FilterData);
    var jsonSearchCriteria = JSON.stringify(Criteria);
    loaddata(jsonSearchCriteria);
}


function PrepareSearchObject(value) {
    var MainObject = {
        Text: value
    };
    return MainObject;
}

function loaddata(searchCriteria) {
    tempArray = [];
    
    $('#AssignBooksTable').dataTable({
        "sPaginationType": "full_numbers",
        "bServerSide": true,
        "sAjaxSource": "http://localhost:60730/api/AssignBook/?searchCriteria=" + searchCriteria + "&type=assignedbooks",
        "bProcessing": true,
        "bDestroy": true,
        "sServerMethod": "POST",
        "bSort": false,
        "bFilter": false,
        "bAutoWidth": false,
        "aoColumns": [
            { "sName": "Title" },
            { "sName": "Name" },
            { "sName": "AssignedDate" },
             { "sName": "DueDate" },
             //{ "sName": "isCurrentlyAssigned" },
               {
                   "sName": "isCurrentlyAssigned", "fnRender": function (oObj) {

                       if (oObj.aData[4] == "Y") {

                           return "<img width='20' height='20' src='../Images/Library/tick.png' />";
                       } else {

                           return "<img width='20' height='20' src='../Images/Library/cross.png' />";
                       }
                   }
               },
           {
               "sName": "isOverDue", "fnRender": function (oObj) {

                   if (oObj.aData[5] == "Y") {

                       return "<span style='padding:3%;color:red' class='glyphicon glyphicon-warning-sign'></span>";
                   } else {

                       return "<span style='padding:3%; color:green' class='glyphicon glyphicon-time'></span>";
                   }
               }
           },
           {
                "sName": "ID",
                "fnRender": function (oObj) {

                    
                    var string = "<div style='text-align: center'>" +
                        "<a><button onclick=\"DeAssignBook('" + oObj.aData[7] + "', '" + oObj.aData[6] + "')\"  type='button'  class='btn btn-sm btn-default btn-icon'>" +
                        "<span class='glyphicon glyphicon-log-in'></span></button></a>" +
                        "</div>";

                    
                    if (oObj.aData[4].indexOf("tick") != -1) {
                        string = "<div style='text-align: center'>" +
                        "<a  target='_blank' data-toggle='modal'><button disabled type='button'  class='btn btn-sm btn-default btn-icon'>" +
                        "<span class='glyphicon glyphicon-log-in'></span></button></a>" +
                        "</div>";
                    }

                    return string;
                }
            }

        ]
    });

}

//If user returns the book , we call this function to deassign
function DeAssignBook(bookId, BorrowerId) {
    $("#ConfDialog").dialog({
        modal : true,
        buttons: {
            "Confirm": function () {
                var url = 'http://localhost:60730/api/AssignBook?BookId=' + bookId + '&BorrowerId=' + BorrowerId;

                var result = Library_ServiceManager.Get(url);
                if (result[0] == true) {
                    StartSearch("");
                }

                $(this).dialog("close");
            },
            "Cancel": function () {

                $(this).dialog("close");
            }
        }
    });  
}