
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


//JQtable to load Borrowers Table
function loaddata(searchCriteria) {
    tempArray = [];

    $('#BorrowersTable').dataTable({
        "sPaginationType": "full_numbers",
        "bServerSide": true,
        "sAjaxSource": "http://localhost:60730/api/Borrowers/?searchCriteria=" + searchCriteria + "&type=borrowers",
        "bProcessing": true,
        "bDestroy": true,
        "sServerMethod": "POST",
        "bSort": false,
        "bFilter": false,
        "bAutoWidth": false,
        "aoColumns": [
            { "sName": "ID" },
            { "sName": "FirstName" },
            { "sName": "LastName" }         
          
        ]
    });

}