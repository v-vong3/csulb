
// Exposing get() to the global object ("Public" functions)
function get(url) {
    const getRequest = new XMLHttpRequest();
    const callback = function (data) { 
        return data;
    };

    handleRequest(getRequest, callback);

    getRequest.open('GET', url, true); // "true" is the default value to make the request an async call
    getRequest.send();

    return callback;
}

// Exposing send() to the global object ("Public" functions)
function send(url, data) {
    const postRequest = new XMLHttpRequest(); 
    const callback = function (data) { 
        return data;
    };

    handleRequest(postRequest, callback);

    postRequest.open('POST', url, true); // "true" is the default value to make the request an async call
    postRequest.send(data);

    return callback;
}

// Exposing handleRequest() to the global object ("Public" functions)
function handleRequest(request, callback) {
    request.onreadystatechange = function () {
        if(request.readyState === XMLHttpRequest.DONE) {
            if(request.status === 200) {
                callback(request.responseXML);
            } else {
                console.log('AJAX error')
            }
        } else {
            // Still pending
        }
    };
}
