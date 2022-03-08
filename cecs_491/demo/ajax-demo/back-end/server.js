const express = require('express')
const port = 8080;
const app = express();

// Middleware setup
app.use(express.json())

// Web service endpoint setup
app.get('/', (request, response) => {
    response.append('Content-Type', 'application/javascript; charset=UTF-8');

    var randomSize = Math.floor(Math.random() * 10)
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

    // Example of a server-side error with useful error message
    response.status(500).send('Database is full');
})


app.listen(port, () => { console.log(`http:\\localhost:${port}`) });