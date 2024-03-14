var APIManager = {
    GetAPISongUrl: function (serviceUrl) {
        return new Promise(function (resolve, reject) {
            $.ajax({
                type: "GET",
                url: serviceUrl,
                dataType: "text",
                success: resolve,
                error: reject
            });
        });
    },

    GetAPIReturn: function (serviceUrl) {
        return new Promise(function (resolve, reject) {
            $.ajax({
                type: "GET",
                url: serviceUrl,
                dataType: "json",
                success: resolve,
                error: reject
            });
        });
    },
    GetAPI: function (serviceUrl, successCallback, errorCallback) {
        $.ajax({
            type: "GET",
            url: serviceUrl,
            dataType: "json",
            success: successCallback,
            error: errorCallback
        });
    },
    PostAPI: function (serviceUrl, data, successCallback, errorCallback) {
        $.ajax({
            type: "POST",
            url: serviceUrl,
            contentType: "application/json",
            data: JSON.stringify(data),
            success: successCallback,
            error: errorCallback
        });
    },
    PutAPI: function (serviceUrl, data, successCallback, errorCallback) {
        $.ajax({
            type: "PUT",
            url: serviceUrl,
            contentType: "application/json",
            data: JSON.stringify(data),
            success: successCallback,
            error: errorCallback
        });
    },
    DeleteAPI: function (serviceUrl, successCallback, errorCallback) {
        $.ajax({
            type: "DELETE",
            url: serviceUrl,
            success: successCallback,
            error: errorCallback
        });
    }
}

var APIManagerSecurity = {
    GetAPISecurityReturn: function (serviceUrl, authToken) {
        return new Promise(function (resolve, reject) {
            $.ajax({
                type: "GET",
                url: serviceUrl,
                headers: {
                    "Authorization": "Bearer " + authToken
                },
                dataType: "json",
                success: resolve,
                error: reject
            });
        });
    },
    GetAPISecurity: function (serviceUrl, authToken, successCallback, errorCallback) {
        $.ajax({
            type: "GET",
            url: serviceUrl,
            headers: {
                "Authorization": "Bearer " + authToken
            },
            dataType: "json",
            success: successCallback,
            error: errorCallback
        });
    },
    PostAPISecurity: function (serviceUrl, authToken, data, successCallback, errorCallback) {
        $.ajax({
            type: "POST",
            url: serviceUrl,
            headers: {
                Authorization: 'Bearer ' + authToken
            },
            contentType: "application/json",
            data: JSON.stringify(data),
            success: successCallback,
            error: errorCallback
        });
    },
    PutAPISecurity: function (serviceUrl, authToken, data, successCallback, errorCallback) {
        $.ajax({
            type: "PUT",
            url: serviceUrl,
            headers: {
                Authorization: 'Bearer ' + authToken
            },
            contentType: "application/json",
            data: JSON.stringify(data),
            success: successCallback,
            error: errorCallback
        });
    },
    DeleteAPISecurity: function (serviceUrl, authToken, data, successCallback, errorCallback) {
        $.ajax({
            type: "DELETE",
            url: serviceUrl,
            headers: {
                Authorization: 'Bearer ' + authToken
            },
            contentType: "application/json",
            data: JSON.stringify(data),
            success: successCallback,
            error: errorCallback
        });
    }
};