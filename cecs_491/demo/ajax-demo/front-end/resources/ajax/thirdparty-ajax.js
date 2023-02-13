// Exposing get() to the global object ("Public" functions)
function get(url) {
    const ajax = window.axios;

    const configs = {
        method: 'get',
        headers: {

        }
    }; 

    return ajax.get(url, configs);
}

// Exposing send() to the global object ("Public" functions)
function send(url, data) {
    const configs = {
        headers: {
          'content-type': 'application/json'
        }
      }

    return window.axios.post(url, data, configs)
}

// Attaching ajaxClient to the global object
window.ajaxClient = {
    get: get,
    send: send
}