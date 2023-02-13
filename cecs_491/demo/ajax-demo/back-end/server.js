
// CORS
/*

Request HTTP Headers:
Origin
Access-Control-Request-Method
Access-Control-Reauest-Headers

Response HTTP Headers:
Access-Control-Allow-Origin
Access-Control-Allow-Methods
Access-Control-Allow-Headers
Access-Control-Expose-Headers
Access-Control-Allow-Credentials
Access-Control-Max-Age

Preflight Request: 
HTTP OPTIONS
Host
Origin
Access-Control-Request-Method

Preflight Response:
204/200
Access-Control-Allow-Origin
Access-Control-Allow-Methods

*/


const express = require('express')
//const cors = require('cors') // Import NPM CORS package
const port = 8080;
const app = express();


// Middleware setup
app.use(express.json())
//app.use(cors()) // Enables ALL CORS request to web server

// Custom middleware to have server send required headers to satisfy CORS policy
app.use(function (request, response, next) {

    response.setHeader('Access-Control-Allow-Origin', 'http://localhost:3000'); 
    response.setHeader('Access-Control-Allow-Methods', 'GET, POST, OPTIONS, PUT, PATCH, DELETE');
    response.setHeader('Access-Control-Allow-Headers', '*'); // * means allow everything

    next();
})


// Web service endpoint setup
app.get('/', (request, response) => {
    response.setHeader('Content-Type', 'application/javascript; charset=UTF-8'); // For JSON MIME type payload

    var randomSize = Math.ceil(Math.random() * 10)
    var data = [];
    
    for(var i = 0; i < randomSize; i++) {
        var randomNumber = Math.floor(Math.random() * 10);

        data.push(randomNumber);
    }

    // Understanding the structure of the JSON data being returned to the front-end is critical for rendering dynamic content
    response.json({
        numbers: data,
        names: [],
        grades: []
    }); 
});

app.post('/', (request, response) => {
    response.setHeader('Content-Type', 'text/html');

    // Example of returning a "view" from the server to the client
    response.send("<h2 style=\"color: green\"><i>POST SUCCESSFUL</i></h2>");
})

app.post('/error', (request, response) => {

    // Example of a server-side error with useful error message
    response.status(500).send('Database is full');
})

// For preflight CORS request
app.options('/*', (request, response) => {
    response.sendStatus(200);
})

// Startup web server
app.listen(port, () => { console.log(`http:\\localhost:${port}`) });