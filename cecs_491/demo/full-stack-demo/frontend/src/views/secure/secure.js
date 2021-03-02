


function loadSecretStuff() {

    if(!hasAccess()) {
        window.location.pathname = "views/error/error.html";
    }

    var list = document.getElementById("data");

    var fragment = document.createDocumentFragment();


    for(var i = 0; i < 90_000; i++) {
        var value = Math.random();
        var childNode = document.createElement("li");

        childNode.innerText = value;
        fragment.appendChild(childNode);

        if(i % 10_000) {
            // wait a few seconds

            setTimeout(function () {
                list.appendChild(fragment);

                fragment = document.createDocumentFragment();
            }, 5000)
            
        }
    }

    // Add the remaining items
    list.appendChild(fragment);
    
}

function parseCookie(cookie) {
    // Return the value of the username in the cookie
    return cookie.split(';').find((x) => x.startsWith("username=")).split("=")[1];
}

function hasAccess() {
    var hasCookie = document.cookie;

    var username = !!hasCookie && parseCookie(hasCookie);

    if(username === "john") {
        return true;
    } else {
        return false;
    }
}


window.onload = loadSecretStuff;