function login() {

    var username = document.querySelector("input[type='username']").value;
    var password = document.querySelector("input[type='password']").value;

    var successMessage = document.getElementById("success"); 
    var errorMessage = document.getElementById("error");

    // Lecture:
    // Send user credentials to the server to validate

    if(username === "john" && password === "smith") {
        // Create the authentication cookie
        document.cookie = "username=john;path=/;samesite=strict;";

        
        errorMessage.style.visibility = 'hidden';
        successMessage.style.visibility = 'visible';

        alert("Login Success");
        
        return true;
    } else {

        successMessage.style.visibility = 'hidden';
        errorMessage.style.visibility = 'visible';

        return false;
    }
}
