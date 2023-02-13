
function get(url) {

    const options = {
        method: 'GET',
        mode: 'cors',
        cache: 'default',
        credentials: 'same-origin',
        headers: {
            'Content-Type': 'application/json'
        },
        redirect: 'follow',
        referrerPolicy: 'no-referrer-when-downgrade',
        body: ''
    };

    return fetch(url, options);

   // https://developer.mozilla.org/en-US/docs/Web/API/Fetch_API/Using_Fetch#checking_that_the_fetch_was_successful


}

// Exposing send() to the global object ("Public" functions)
function send(url, data) {
    const options = {
        method: 'POST',
        mode: 'cors',
        cache: 'default',
        credentials: 'same-origin',
        headers: {
            'Content-Type': 'application/json'
        },
        redirect: 'follow',
        referrerPolicy: 'no-referrer-when-downgrade',
        body: ''
    };

    return fetch(url, options);
}