/// <reference path="../Helper/Helper.js" />

// Service Manager for Restfull api calls.
var Library_ServiceManager = {
    // Sends a restfull GET request to a specified URL.
    Get: function (url, async, eventName) {
        var returnValue;
        if (async == undefined) {
            async = false;
        }
        $.ajax({
            url: url,
            type: 'GET',
            contentType: 'application/json; charset=utf-8',
            cache: false,
            async: async,
            success: function (result) {
                returnValue = [true, result];
                if (async == true && eventName != undefined) {
                    $(Library_ServiceManager).trigger(eventName, [returnValue]);
                }
            },
            error: function (req, status, error) {
                returnValue = [false, req.responseText];
                if (async == true && eventName != undefined) {
                    $(Library_ServiceManager).trigger(eventName, [returnValue]);
                }
            }
        });

        return returnValue;
    },
    // Sends a restfull POST request to a specified URL with the specified record/data.
    Post: function (url, record, async, eventName) {
        var returnValue;
        if (async == undefined) {
            async = false;
        }
        $.ajax({
            url: url,
            type: 'POST',
            data: record,
            contentType: 'application/json; charset=utf-8',
            cache: false,
            async: async,
            success: function (user, status, XHR) {
                returnValue = [true, XHR];
                if (async == true && eventName != undefined) {
                    $(Library_ServiceManager).trigger(eventName, [returnValue]);
                }
            },
            error: function (req, status, error) {

                if (req.responseText.indexOf("InvalidObjektNRException") == -1) {
                    returnValue = [false, req.responseText];
                    if (async == true && eventName != undefined) {
                        $(Library_ServiceManager).trigger(eventName, [returnValue]);
                    }
                }
                else {
                    CnSHelper.RelocateToWindow('Shared/SignInScreen');

                }
            }
        });

        return returnValue;
    },
    // Sends a restfull PUT request to a specified URL with the specified record/data.
    Put: function (url, record) {
        var returnValue;

        $.ajax({
            url: url,
            type: 'PUT',
            data: record,
            contentType: 'application/json; charset=utf-8',
            cache: false,
            async: false,
            success: function (user) {
                returnValue = [true, ""];
            },
            error: function (req, status, error) {
                returnValue = [false, req.responseText];
            }
        });

        return returnValue;
    },
    // Sends a restfull DELETE request to the specified URL.
    Delete: function (url, displayMessage) {
        var returnValue;
        var loggedInUser = CnSHelper.GetLoggedInUser();
        if (displayMessage == undefined)
            displayMessage = true;
        if (loggedInUser == null) {
            if (displayMessage == true) {
                CnSHelper.RelocateToWindow('Shared/SignInScreen');
            }
            returnValue = [true, ""];
        }
        else {
            $.ajax({
                url: url,
                type: 'DELETE',
                contentType: 'application/json; charset=utf-8',
                cache: false,
                async: false,
                success: function (user) {
                    returnValue = [true, ""];
                },
                error: function (req, status, error) {
                    returnValue = [false, req.responseText];
                }
            })
        };

        return returnValue;
    }
};