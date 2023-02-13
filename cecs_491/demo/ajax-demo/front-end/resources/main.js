'use strict';

// Immediately Invoke Function Execution (IIFE or IFE)
// Protects functions from being exposed to the global object
(function (root, ajaxClient) {
    // Dependency check
    const isValid = root && ajaxClient;

    if(!isValid){
        // Handle missing dependencies
        alert("Missing dependencies");
    }

    const webServiceUrl = 'http://localhost:8080';

    // NOT exposed to the global object ("Private" functions)
    function getDataHandler() {
        var request = ajaxClient.get(webServiceUrl);

         request.then(function (response) {

            const contentElement = document.getElementsByClassName('dynamic-content')[0];
            
            // Dynamically build HTML
            var content = '<ul>';

            var promisePayload = response.data;
            var apiPayload = promisePayload.numbers;

            for(var i = 0; i < apiPayload.length; i++) {
                content += '<li>' + apiPayload[i] + '</li>'
            }

            content += '</ul>'

            /* 
                This was not a production-ready method to dynamically build views.
                Instead, use either createDocumentFragmen, createElement/append or a JS frameworks.
            */
            contentElement.innerHTML = content; 
        });
    }

    // NOT exposed to the global object ("Private" functions)
    function sendDataHandler() {
        var request = ajaxClient.send(webServiceUrl, {
                data: ['Alice', 'Bob', 'John']
            });

        request
            .then(function (response) {
                return request;
            })
            .catch(function (error) {
                console.log("Logging the SEND", request);

                const contentElement = document.getElementsByClassName('dynamic-content')[0];

                contentElement.innerHTML = error; 
            });

        
    }

    root.myApp = root.myApp || {};

    // Show or Hide private functions
    //root.myApp.getData = getDataHandler;
    //root.myApp.sendData = sendDataHandler;

    // Initialize the current view by attaching event handlers 
    function init() {
        // Note that normally you would want to use Event Bubbling to register events for child elements
        // that could grow over time 
        var getDataElement = document.getElementById('get');
        var sendDataElement = document.getElementById('send');

        // Dynamic event registration
        getDataElement.addEventListener('click', getDataHandler);
        sendDataElement.addEventListener('click', sendDataHandler);
    }

    init();

})(window, window.ajaxClient);

