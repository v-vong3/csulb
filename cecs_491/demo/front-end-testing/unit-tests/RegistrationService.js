'use strict';

class RegistrationService {
    constructor() {
        this.validations = [this.isValidUsername, this.isValidPassword];
    }
    
    isValidUsername(username) {
        const emailRegex = /^[a-zA-Z0-9]+@[a-zA-Z0-9.]+$/;

        return username && username.toUpperCase && emailRegex.exec(username);
    }

    isValidPassword(password) {
        const minLength = 8;

        return password && password.toUpperCase && password.length >= minLength;
    }


    createUserAccount(username, password) {

        for(let i = 0; i < arguments.length; ++i) {
            if(!this.validations[i](arguments[i])) {
                return false;
            }
        }

        // Make call to server to create account
        //fetch(url).then()
        
        return true;
    }

}

module.exports = new RegistrationService();