

//Searching starts here
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


//JQtable to bring back the data
function loaddata(searchCriteria) {
    tempArray = [];

    $('#BooksTable').dataTable({
        "sPaginationType": "full_numbers",
        "bServerSide": true,
        "sAjaxSource": "http://localhost:60730/api/Books/?searchCriteria=" + searchCriteria + "&type=booksinfo",
        "bProcessing": true,
        "bDestroy": true,
        "sServerMethod": "POST",
        "bSort": false,
        "bFilter": false,
        "bAutoWidth": false,
        "aoColumns": [
            { "sName": "ID" },
            { "sName": "Title" },
            { "sName": "Author" },
             {
                 "sName": "TotalInStock", "fnRender": function (oObj) {

                     if (oObj.aData[3] == "Y") {

                         return "<img width='20' height='20' src='../Images/Library/tick.png' />";
                     } else {

                         return "<img width='20' height='20' src='../Images/Library/cross.png' />";
                     }
                 }
             }
             , { "sName": "TotalInStock" },
              { "sName": "TotalAssigned" },

                 {
                     "sName": "ID",
                     "fnRender": function (oObj) {


                         var string = "<div style='text-align: center'>" +
                             "<a><button onclick=\"OpenDialog('" + oObj.aData[0] + "', '" + encodeURIComponent(oObj.aData[1]) + "')\"  type='button'  class='btn btn-sm btn-default btn-icon'>" +
                             "<span class='glyphicon glyphicon-user'></span></button></a>" +
                             "</div>";


                         if (oObj.aData[3].indexOf("cross")!=-1) {
                             string = "<div style='text-align: center'>" +
                             "<a  target='_blank' data-toggle='modal'><button disabled type='button'  class='btn btn-sm btn-default btn-icon'>" +
                             "<span class='glyphicon glyphicon-user'></span></button></a>" +
                             "</div>";
                         }

                         return string;
                     }
                 }

        ]
    });

}