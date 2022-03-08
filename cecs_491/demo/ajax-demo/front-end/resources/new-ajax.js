// Exposing get() to the global object ("Public" functions)
function get(url) {
    const getRequest = window.axios;

    return getRequest.get(url);
}

// Exposing send() to the global object ("Public" functions)
function send(url, data) {
    const postRequest = window.axios;

    return postRequest.post(url, data);
}

// Attaching ajaxClient to the global object
window.ajaxClient = {
    get: get,
    send: send
}