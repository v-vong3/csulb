(() => {

    // JavaScript Closure

    function isValid(token) {
        var isJwt = token && window.jwt_decode(token);


        if(isJwt) {
            return true;
        }

        return false;
    }

    function authorizeView() {
        console.log("Auth check")
        const token = window.sessionStorage.getItem("token");

        if(!isValid(token)) {
            clearInterval(timeout);
            window.location.assign(window.location.origin);
        }
    }

    var timeout;

    window.onload = function () { 
        timeout = setInterval(function () { authorizeView() }, 30);
     }; 

     console.log(timeout)
})()

function clearToken() {
    console.log("Clearing tokens")
    
    window.localStorage.removeItem("token");
    window.sessionStorage.removeItem("token");
}